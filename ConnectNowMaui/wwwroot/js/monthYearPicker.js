// wwwroot/js/monthYearPicker.js  (MODULE VERSION)

// small debounce
function _debounce(fn, wait) { let t; return (...a) => { clearTimeout(t); t = setTimeout(() => fn(...a), wait); }; }

export function init(cfg, dotnetRef) {
    const byId = id => document.getElementById(id);
    const elContainer = byId(cfg.containerId);
    if (!elContainer) return;

    const monthCol = byId(cfg.monthListId);
    const yearCol = byId(cfg.yearListId);
    const preview = byId(cfg.previewId);
    const headerEl = byId(cfg.headerId);
    const saveBtn = byId(cfg.saveBtnId);

    const monthUL = monthCol.querySelector('ul');
    const yearUL = yearCol.querySelector('ul');

    const months = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"];

    const liHeight = cfg.liHeight || 44;
    const buffer = cfg.buffer ?? 20;

    const startYear = cfg.startYear;
    const startMonth = cfg.startMonth; // 1..12
    const lastYear = startYear + (cfg.yearsForward ?? 10);

    // build months
    monthUL.innerHTML = "";
    for (let i = -buffer; i < 12 + buffer; i++) {
        const li = document.createElement('li');
        li.textContent = months[(i + 12) % 12];
        monthUL.appendChild(li);
    }

    // build years (clamped range)
    const years = []; for (let y = startYear; y <= lastYear; y++) years.push(y);
    yearUL.innerHTML = "";
    for (let i = -buffer; i < years.length + buffer; i++) {
        const li = document.createElement('li');
        const idx = Math.min(Math.max(i, 0), years.length - 1);
        li.textContent = years[idx];
        yearUL.appendChild(li);
    }

    const _children = ul => Array.from(ul.children);
    function _selected(col, ul) {
        const idx = Math.round(col.scrollTop / liHeight);
        const lis = _children(ul);
        const i = Math.min(Math.max(idx, 0), lis.length - 1);
        return { index: i, el: lis[i], text: lis[i].textContent };
    }
    function _markSelected(col, ul) {
        _children(ul).forEach(li => li.classList.remove('selected'));
        const { index } = _selected(col, ul);
        _children(ul)[index]?.classList.add('selected');
        col.scrollTo({ top: index * liHeight, behavior: 'auto' });
    }
    function _getMonth1To12() {
        const txt = _selected(monthCol, monthUL).text;
        const idx = months.indexOf(txt);
        return idx >= 0 ? idx + 1 : startMonth;
    }
    function _getYear() {
        const y = parseInt(_selected(yearCol, yearUL).text, 10);
        return Number.isFinite(y) ? y : startYear;
    }
    function _clampToRange(m, y) {
        const cy = Math.min(Math.max(y, startYear), lastYear);
        return { m, y: cy };
    }
    function _updatePreviewAndNotify() {
        let m = _getMonth1To12();
        let y = _getYear();
        ({ m, y } = _clampToRange(m, y));
        const text = `${months[m - 1]} ${y}`;
        preview.textContent = text;
        if (headerEl) headerEl.textContent = text;
        if (dotnetRef && typeof dotnetRef.invokeMethodAsync === 'function') {
            try { dotnetRef.invokeMethodAsync('OnMonthYearChanged', m, y); } catch { }
        }
    }

    const onScroll = _debounce(() => {
        _markSelected(monthCol, monthUL);
        _markSelected(yearCol, yearUL);
        _updatePreviewAndNotify();
    }, 80);
    monthCol.addEventListener('scroll', onScroll);
    yearCol.addEventListener('scroll', onScroll);

    function wheel(col) {
        col.addEventListener('wheel', e => {
            e.preventDefault();
            const dir = e.deltaY > 0 ? 1 : -1;
            col.scrollBy({ top: dir * liHeight, behavior: 'smooth' });
        }, { passive: false });
    }
    wheel(monthCol); wheel(yearCol);

    function drag(col, ul) {
        col.addEventListener('mousedown', e => {
            const startY = e.pageY, startTop = col.scrollTop;
            function move(ev) { col.scrollTop = startTop - (ev.pageY - startY); }
            function up() {
                document.removeEventListener('mousemove', move);
                document.removeEventListener('mouseup', up);
                _markSelected(col, ul);
                _updatePreviewAndNotify();
            }
            document.addEventListener('mousemove', move);
            document.addEventListener('mouseup', up);
        });
    }
    drag(monthCol, monthUL); drag(yearCol, yearUL);

    // initial positions = current month, startYear
    const initialMonthIndex = buffer + (startMonth - 1);
    const initialYearIndex = buffer + 0; // first year
    monthCol.scrollTop = initialMonthIndex * liHeight;
    yearCol.scrollTop = initialYearIndex * liHeight;

    _markSelected(monthCol, monthUL);
    _markSelected(yearCol, yearUL);
    _updatePreviewAndNotify();

    saveBtn?.addEventListener('click', () => {
        const m = _getMonth1To12();
        const y = _getYear();
        if (dotnetRef && typeof dotnetRef.invokeMethodAsync === 'function') {
            try { dotnetRef.invokeMethodAsync('OnMonthYearSaved', m, y); } catch { }
        }
        const el = document.getElementById(cfg.containerId);
        window.bootstrap?.Offcanvas.getInstance(el)?.hide();
    });

    document.getElementById(cfg.containerId)
        ?.addEventListener('shown.bs.offcanvas', _updatePreviewAndNotify);
}

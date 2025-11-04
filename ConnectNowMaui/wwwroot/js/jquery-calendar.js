(function () {
  const owlTabs = document.getElementById("owl-tabs");
  const monYrPicker = document.getElementById("offcanvasMonYrPicker");
  if (!owlTabs && !monYrPicker) return;
  
  $(document).ready(function () {
    // OwlCarousel Logic
    if ($('#owl-tabs').length) {
      const $owlTabs = $('#owl-tabs');
      const today = new Date();
      const currentDay = ("0" + today.getDate()).slice(-2);
      const currentYear = today.getFullYear();
      const currentMonth = today.getMonth();
      const daysInMonth = new Date(currentYear, currentMonth + 1, 0).getDate();
      const dayNames = ['SUN', 'MON', 'TUE', 'WED', 'THU', 'FRI', 'SAT'];
      $owlTabs.empty();
      for (let day = 1; day <= daysInMonth; day++) {
        const date = new Date(currentYear, currentMonth, day);
        const dayName = dayNames[date.getDay()];
        const dayNum = ("0" + day).slice(-2);
        const isToday = dayNum === currentDay;
        const hasEvent = Math.random() < 0.4;
        const eventDot = (isToday ? ' active' : '') + (hasEvent ? ' event-dot' : '');
        //const item = `<a href=""><div class="item tabs${isToday ? ' active' : ''}"><h6>${dayName} <span>${dayNum}</span></h6></div></a>`;
        const item = `<a href=""><div class="item tabs${eventDot}"><h6>${dayName} <span>${dayNum}</span></h6></div></a>`;
        $owlTabs.append(item);
      }
      const $owl = $owlTabs.owlCarousel({
        loop:false, nav:true, dots:false,  margin:8, stagePadding:13, autoWidth:true, responsiveClass:true, onInitialized:scrollToActiveItem
      });
      function scrollToActiveItem() {
        setTimeout(() => {
          const $nonCloned = $owl.find('.owl-item:not(.cloned)');
          let index = $nonCloned.index($nonCloned.find('.item.tabs.active').closest('.owl-item'));
          if (index >= 0) {
            $owl.trigger("to.owl.carousel", [index, 300, true]);
          }
        }, 100);
      }
    }
    // Month/Year Picker
    if ($('#offcanvasMonYrPicker').length) {
      const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
      const liHeight = 44, buffer = 20, currentYear = new Date().getFullYear(), yearRange = 100;
      const yearStart = currentYear - Math.floor(yearRange / 2);
      const monthList = $("#monthList ul");
      const yearList = $("#yearList ul");
      const preview = $('#selectedPreview');
      const monthCol = $('#monthList');
      const yearCol = $('#yearList');
      for (let i = -buffer; i <= months.length + buffer; i++) {
        $('<li>').text(months[(i + 12) % 12]).appendTo(monthList);
      }
      for (let i = -buffer; i <= yearRange + buffer; i++) {
        $('<li>').text(yearStart + ((i + yearRange) % yearRange)).appendTo(yearList);
      }
      function getSelected($col, $list) {
        const idx = Math.round($col.scrollTop() / liHeight);
        const $li = $list.children().eq(idx);
        return { index: idx, text: $li.text(), el: $li };
      }
      function updateSelected($col, $list) {
        const { index } = getSelected($col, $list);
        $list.children().removeClass('selected');
        $list.children().eq(index).addClass('selected');
        $col.stop().animate({ scrollTop: index * liHeight }, 100);
      }
      function updatePreview() {
        preview.text(`${getSelected(monthCol, monthList).text} ${getSelected(yearCol, yearList).text}`);
      }
      function debounce(fn, delay) {
        let timer;
        return function () {
          clearTimeout(timer);
          timer = setTimeout(fn, delay);
        };
      }
      monthCol.on('scroll', debounce(() => {
        updateSelected(monthCol, monthList);
        updatePreview();
      }, 100));
      yearCol.on('scroll', debounce(() => {
        updateSelected(yearCol, yearList);
        updatePreview();
      }, 100));
      $.each([monthCol, yearCol], (_, $col) => {
        $col.on('wheel', function (e) {
          e.preventDefault();
          this.scrollBy({ top: (e.originalEvent.deltaY > 0 ? 1 : -1) * liHeight, behavior: 'smooth' });
        });
        $col.on('mousedown', function (e) {
          const startY = e.pageY, startScroll = $col.scrollTop();
          function move(e) {
            $col.scrollTop(startScroll - (e.pageY - startY));
          }
          function up() {
            $(document).off('mousemove', move).off('mouseup', up);
            updateSelected($col, $col.find('ul'));
            updatePreview();
          }
          $(document).on('mousemove', move).on('mouseup', up);
        });
      });
      $('#savePicker').on('click', function () {
        $('#txt_monthYear').text(preview.text());
        bootstrap.Offcanvas.getInstance(document.getElementById('offcanvasMonYrPicker')).hide();
      });
      const initialMonthIndex = buffer + new Date().getMonth();
      const initialYearIndex = buffer + (yearRange / 2);
      monthCol.scrollTop(initialMonthIndex * liHeight);
      yearCol.scrollTop(initialYearIndex * liHeight);
      updateSelected(monthCol, monthList);
      updateSelected(yearCol, yearList);
      updatePreview();
      $('#txt_monthYear').text(preview.text());
      document.getElementById('offcanvasMonYrPicker').addEventListener('shown.bs.offcanvas', updatePreview);
    }
    // Today's Date element
    const $today = $('#today');
    if ($today.length) {
      const today = new Date();
      $today.text(("0" + today.getDate()).slice(-2));
    }
  });
})();
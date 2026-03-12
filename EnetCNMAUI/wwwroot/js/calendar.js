// wwwroot/js/calendar.js
// Calendar and Month/Year picker functionality

(function () {
  // Run when DOM is ready
  if (typeof jQuery === 'undefined') {
    // Wait for jQuery if not loaded yet
    document.addEventListener('DOMContentLoaded', initCalendar);
    return;
  }
  
  jQuery(document).ready(initCalendar);
  
  function initCalendar() {
    // OwlCarousel Logic for calendar tabs
    if (jQuery('#owl-tabs').length) {
      const $owlTabs = jQuery('#owl-tabs');
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
        const item = `<a href=""><div class="item tabs${eventDot}"><h6>${dayName} <span>${dayNum}</span></h6></div></a>`;
        $owlTabs.append(item);
      }
      
      const $owl = $owlTabs.owlCarousel({
        loop: false, 
        nav: true, 
        dots: false,  
        margin: 8, 
        stagePadding: 13, 
        autoWidth: true, 
        responsiveClass: true, 
        onInitialized: scrollToActiveItem
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
    if (jQuery('#offcanvasMonYrPicker').length) {
      const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
      const liHeight = 44, buffer = 20, currentYear = new Date().getFullYear(), yearRange = 100;
      const yearStart = currentYear - Math.floor(yearRange / 2);
      const monthList = jQuery("#monthList ul");
      const yearList = jQuery("#yearList ul");
      const preview = jQuery('#selectedPreview');
      const monthCol = jQuery('#monthList');
      const yearCol = jQuery('#yearList');
      
      for (let i = -buffer; i <= months.length + buffer; i++) {
        jQuery('<li>').text(months[(i + 12) % 12]).appendTo(monthList);
      }
      for (let i = -buffer; i <= yearRange + buffer; i++) {
        jQuery('<li>').text(yearStart + ((i + yearRange) % yearRange)).appendTo(yearList);
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
      
      jQuery.each([monthCol, yearCol], (_, $col) => {
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
            jQuery(document).off('mousemove', move).off('mouseup', up);
            updateSelected($col, $col.find('ul'));
            updatePreview();
          }
          jQuery(document).on('mousemove', move).on('mouseup', up);
        });
      });
      
      jQuery('#savePicker').on('click', function () {
        jQuery('#txt_monthYear').text(preview.text());
        bootstrap.Offcanvas.getInstance(document.getElementById('offcanvasMonYrPicker')).hide();
      });
      
      const initialMonthIndex = buffer + new Date().getMonth();
      const initialYearIndex = buffer + (yearRange / 2);
      monthCol.scrollTop(initialMonthIndex * liHeight);
      yearCol.scrollTop(initialYearIndex * liHeight);
      updateSelected(monthCol, monthList);
      updateSelected(yearCol, yearList);
      updatePreview();
      jQuery('#txt_monthYear').text(preview.text());
      document.getElementById('offcanvasMonYrPicker').addEventListener('shown.bs.offcanvas', updatePreview);
    }
    
    // Today's Date element
    const $today = jQuery('#today');
    if ($today.length) {
      const today = new Date();
      $today.text(("0" + today.getDate()).slice(-2));
    }
  }
})();

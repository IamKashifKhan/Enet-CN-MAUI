// Theme Switching
document.addEventListener('DOMContentLoaded', () => {
  const themeTrigger = document.getElementById('themeDropdown');
  if (!themeTrigger) return;
  const htmlElement = document.documentElement;
  const bodyElement = document.body;
  const themeIcon = themeTrigger.querySelector('i');
  const themeOptions = document.querySelectorAll('[data-theme-value]');
  const prefersDarkScheme = window.matchMedia("(prefers-color-scheme: dark)").matches;
  let storedTheme = localStorage.getItem('bsTheme');
  let effectiveTheme;
  if (!storedTheme || storedTheme === 'auto') {
    effectiveTheme = prefersDarkScheme ? 'dark' : 'light';
    htmlElement.setAttribute('data-bs-theme', effectiveTheme);
    bodyElement.classList.add(`theme-${effectiveTheme}`);
    themeIcon.className = 'bi bi-circle-half';
    storedTheme = 'auto';
  } else {
    effectiveTheme = storedTheme;
    htmlElement.setAttribute('data-bs-theme', effectiveTheme);
    bodyElement.classList.add(`theme-${effectiveTheme}`);
    if (storedTheme === 'light') themeIcon.className = 'bi bi-sun-fill';
    else if (storedTheme === 'dark') themeIcon.className = 'bi bi-moon-stars-fill';
  }
  themeOptions.forEach(option => {
    option.classList.toggle('active', option.getAttribute('data-theme-value') === storedTheme);
  });
  themeOptions.forEach(option => {
    option.addEventListener('click', function (e) {
      e.preventDefault();
      const selectedTheme = this.getAttribute('data-theme-value');
      const selectedIcon = this.querySelector('i');
      localStorage.setItem('bsTheme', selectedTheme);
      bodyElement.classList.remove('theme-dark', 'theme-light');
      if (selectedTheme === 'auto') {
        const systemPref = prefersDarkScheme ? 'dark' : 'light';
        htmlElement.setAttribute('data-bs-theme', systemPref);
        bodyElement.classList.add(`theme-${systemPref}`);
        themeIcon.className = 'bi bi-circle-half';
      } else {
        htmlElement.setAttribute('data-bs-theme', selectedTheme);
        bodyElement.classList.add(`theme-${selectedTheme}`);
        themeIcon.className = selectedIcon.className;
      }
      themeOptions.forEach(opt => opt.classList.remove('active'));
      this.classList.add('active');
    });
  });
});



	/* Toggle */
$('.toggle-wrapper button').click(function(){
  $('.toggle-wrapper button').removeClass('active');
  $(this).addClass('active');
  $('#offersScreen, #businessScreen').addClass('hidden');
  $('#' + $(this).data('target')).removeClass('hidden');
});

/* Heart */
$(document).on('click','.heart',function(){
  $(this).text($(this).text() === "♡" ? "♥" : "♡");
});


///* Heart Animation */
//$(document).on('click', '.heart', function () {
//  $(this).toggleClass('active');

//  if ($(this).hasClass('active')) {
//    $(this).html('<i class="fa-solid fa-heart"></i>');
//  } else {
//    $(this).html('<i class="fa-regular fa-heart"></i>');
//  }
//});
	
	



// search list item remove
$(document).on('click', '.remove-item', function() {
    $(this).closest('li').fadeOut(200, function() {
        $(this).remove();
    });
});



// Search Range
const distanceRange = document.getElementById('distanceRange');
const rangeValueDisplay = document.getElementById('rangeValue');

function updateSlider() {
    const value = parseFloat(distanceRange.value);
    const min = parseFloat(distanceRange.min) || 0;
    const max = parseFloat(distanceRange.max) || 10;

    // Percentage Calculation
    const percentage = ((value - min) / (max - min)) * 100;

    // Update CSS Variable (Used in CSS background-size)
    distanceRange.style.setProperty('--percent', percentage + '%');

    // Update Display Text
    rangeValueDisplay.textContent = value;
}

// Event Listeners
// 'input' event for real-time update while dragging
distanceRange.addEventListener('input', updateSlider);

// Run on page load to set initial state
window.addEventListener('DOMContentLoaded', updateSlider);







// Business & Offer Toggle Filter Link Change
$(document).on('click', 'button[data-target]', function () {

    $('button[data-target]').removeClass('active');
    $(this).addClass('active');

    var target = $(this).data('target');

    $('.filter-link').attr('data-bs-target', 
        target === 'offersScreen' ? '#filterOffer' : '#filterBusiness'
    );

});





/// Filter Modal
// Get all selectedTags containers
const selectedTagsDivs = document.querySelectorAll('[id^="selectedTags"]');

// Get all clear buttons
const clearAllBtns = document.querySelectorAll('[id^="clearAll"]');

// Get all filter groups (important: each modal/container wrapper)
const filterGroups = document.querySelectorAll('.offcanvas'); 



filterGroups.forEach((group, index) => {

    const selectedTagsDiv = selectedTagsDivs[index];
    const clearBtn = clearAllBtns[index];
    const checkboxes = group.querySelectorAll('.filter-tag input');

    function updateTags() {
        selectedTagsDiv.innerHTML = '';

        checkboxes.forEach(cb => {
            if (cb.checked) {

                const span = document.createElement('span');
                span.className = 'chip';
                span.textContent = cb.value;

                span.onclick = () => {
                    cb.checked = false;
                    updateTags();
                };

                selectedTagsDiv.appendChild(span);
            }
        });
    }

    checkboxes.forEach(cb => {
        cb.addEventListener('change', updateTags);
    });

    clearBtn.addEventListener('click', () => {
        checkboxes.forEach(cb => cb.checked = false);
        updateTags();
    });

    updateTags();

});










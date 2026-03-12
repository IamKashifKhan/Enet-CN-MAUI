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










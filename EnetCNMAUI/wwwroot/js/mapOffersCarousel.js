// wwwroot/js/mapOffersCarousel.js
// Map Offers Carousel functionality

(function () {
  // Initialize when DOM is ready
  function initMapOffersCarousel() {
    // Check if jQuery and OwlCarousel are available
    if (typeof jQuery === 'undefined' || typeof jQuery.fn.owlCarousel === 'undefined') {
      return;
    }

    // Initialize map offers carousel if it exists
    var $mapOffersCarousel = jQuery('.map-offers-carousel');
    if ($mapOffersCarousel.length && !$mapOffersCarousel.hasClass('owl-loaded')) {
      $mapOffersCarousel.owlCarousel({
        loop: true,
        margin: 20,
        nav: false,
        dots: false,
        autoplay: true,
        autoplayTimeout: 5000,
        smartSpeed: 900,
        responsive: {
          0: { items: 1 },
          576: { items: 2 },
          768: { items: 3 },
          1200: { items: 4 }
        }
      });
    }

    // Initialize inner business slider if exists
    var $innerSlider = jQuery('.inner-slider');
    if ($innerSlider.length && !$innerSlider.hasClass('owl-loaded')) {
      $innerSlider.owlCarousel({
        loop: true,
        margin: 15,
        nav: false,
        dots: false,
        autoplay: true,
        autoplayTimeout: 3000,
        smartSpeed: 600,
        responsive: {
          0: { items: 1.2 },
          768: { items: 1.2 }
        }
      });
    }
  }

  // Run on DOM ready
  if (typeof jQuery !== 'undefined') {
    jQuery(document).ready(initMapOffersCarousel);
  } else {
    document.addEventListener('DOMContentLoaded', initMapOffersCarousel);
  }

  // Expose function to refresh carousel
  window.refreshMapOffersCarousel = function () {
    initMapOffersCarousel();
  };
})();

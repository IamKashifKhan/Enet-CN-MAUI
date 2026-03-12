// HomeNew.razor.js
// Blazor-compatible JavaScript for HomeNew page
// Safe for repeated calls from OnAfterRenderAsync / JS interop

window.HomeNew = (function () {
    function init() {
        waitForDependencies(function () {
            initCategoriesSlider();
            initHeroSlider();
            initRedeemedSlider();
            initOffersSlider();
            initSuggestedSlider();
            initToggle();
            initHeartToggle();
            initBusinessAccordion();
            initRangeSlider();
        });
    }

    function refresh() {
        if (typeof jQuery === 'undefined') return;

        // Refresh Owl layout after Blazor re-render
        jQuery('.categories-slider, .hero-slider, .redeemed-slider, .offers-slider, .suggested-slider, .inner-slider')
            .trigger('refresh.owl.carousel');

        jQuery(window).trigger('resize');
    }

    function destroy() {
        if (typeof jQuery === 'undefined') return;

        const selectors = [
            '.categories-slider',
            '.hero-slider',
            '.redeemed-slider',
            '.offers-slider',
            '.suggested-slider',
            '.inner-slider'
        ];

        selectors.forEach(function (selector) {
            jQuery(selector).each(function () {
                const $slider = jQuery(this);
                if ($slider.hasClass('owl-loaded')) {
                    $slider.trigger('destroy.owl.carousel');
                    $slider.removeClass('owl-loaded');
                    $slider.find('.owl-stage-outer').children().unwrap();
                    $slider.removeData();
                }
            });
        });

        jQuery('.toggle-wrapper button').off('click.homenew');
        jQuery(document).off('click.homenew', '.heart');
        jQuery(document).off('click.homenew', '.business-header');
        jQuery('#distanceRange').off('input.homenew');
    }

    function waitForDependencies(callback, retries = 20) {
        if (
            typeof jQuery !== 'undefined' &&
            typeof jQuery.fn !== 'undefined' &&
            typeof jQuery.fn.owlCarousel !== 'undefined'
        ) {
            callback();
            return;
        }

        if (retries <= 0) {
            console.warn('HomeNew: jQuery or OwlCarousel not available.');
            return;
        }

        setTimeout(function () {
            waitForDependencies(callback, retries - 1);
        }, 100);
    }

    function initCategoriesSlider() {
        const $slider = jQuery('.categories-slider');
        if ($slider.length && !$slider.hasClass('owl-loaded')) {
            $slider.owlCarousel({
                loop: true,
                margin: 30,
                nav: false,
                dots: false,
                autoplay: true,
                autoplayTimeout: 3500,
                smartSpeed: 900,
                dotsEach: 1,
                responsive: {
                    0: { items: 3 },
                    480: { items: 4 },
                    768: { items: 5 },
                    991: { items: 6 },
                    1200: { items: 9 }
                }
            });
        }
    }

    function initHeroSlider() {
        const $slider = jQuery('.hero-slider');
        if ($slider.length && !$slider.hasClass('owl-loaded')) {
            $slider.owlCarousel({
                items: 1,
                loop: true,
                nav: false,
                dots: true,
                autoplay: true,
                autoplayTimeout: 4000,
                smartSpeed: 800,
                dotsEach: 1,
                navText: [
                    '<i class="fa fa-chevron-left"></i>',
                    '<i class="fa fa-chevron-right"></i>'
                ]
            });
        }
    }

    function initRedeemedSlider() {
        const $slider = jQuery('.redeemed-slider');
        if ($slider.length && !$slider.hasClass('owl-loaded')) {
            $slider.owlCarousel({
                loop: true,
                margin: 20,
                nav: false,
                dots: false,
                autoplay: true,
                autoplayTimeout: 5000,
                smartSpeed: 900,
                dotsEach: 1,
                stagePadding: 100,
                responsive: {
                    0: { items: 1, stagePadding: 30 },
                    768: { items: 2, stagePadding: 50 },
                    1200: { items: 3, stagePadding: 100 }
                }
            });
        }
    }

    function initOffersSlider() {
        const $slider = jQuery('.offers-slider');
        if ($slider.length && !$slider.hasClass('owl-loaded')) {
            $slider.owlCarousel({
                loop: true,
                margin: 20,
                nav: false,
                dots: false,
                autoplay: true,
                autoplayTimeout: 5000,
                smartSpeed: 900,
                dotsEach: 1,
                stagePadding: 5,
                responsive: {
                    0: { items: 2 },
                    576: { items: 3 },
                    768: { items: 5 },
                    1200: { items: 6 }
                }
            });
        }
    }

    function initSuggestedSlider() {
        const $slider = jQuery('.suggested-slider');
        if ($slider.length && !$slider.hasClass('owl-loaded')) {
            $slider.owlCarousel({
                loop: true,
                margin: 15,
                nav: false,
                dots: false,
                autoplay: true,
                autoplayTimeout: 3000,
                smartSpeed: 600,
                responsive: {
                    0: { items: 1.2 },
                    576: { items: 1.2 },
                    768: { items: 1.2 }
                }
            });
        }
    }

    function initToggle() {
        jQuery('.toggle-wrapper button')
            .off('click.homenew')
            .on('click.homenew', function () {
                jQuery('.toggle-wrapper button').removeClass('active');
                jQuery(this).addClass('active');

                jQuery('#offersScreen, #businessScreen').addClass('hidden');

                const target = jQuery(this).data('target');
                if (target) {
                    jQuery('#' + target).removeClass('hidden');
                }
            });
    }

    function initHeartToggle() {
        jQuery(document)
            .off('click.homenew', '.heart')
            .on('click.homenew', '.heart', function () {
                const $this = jQuery(this);
                const $icon = $this.find('i');

                if ($icon.length) {
                    if ($icon.hasClass('fa-solid')) {
                        $icon.removeClass('fa-solid').addClass('fa-regular');
                    } else {
                        $icon.removeClass('fa-regular').addClass('fa-solid');
                    }
                }

                $this.toggleClass('active');
            });
    }

    function initBusinessAccordion() {
        jQuery(document)
            .off('click.homenew', '.business-header')
            .on('click.homenew', '.business-header', function () {
                const $parent = jQuery(this).closest('.business-item');
                const $body = $parent.find('.business-body');

                if ($parent.hasClass('active')) {
                    $parent.removeClass('active');
                    return;
                }

                jQuery('.business-item').removeClass('active');
                $parent.addClass('active');

                if ($body.length && !$body.data('owl-initialized')) {
                    const $innerSlider = $body.find('.inner-slider');

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

                    $body.data('owl-initialized', true);
                }
            });
    }

    function initRangeSlider() {
        const $rangeInput = jQuery('#distanceRange');
        const $rangeValue = jQuery('#rangeValue');

        if ($rangeInput.length && $rangeValue.length) {
            $rangeInput
                .off('input.homenew')
                .on('input.homenew', function () {
                    $rangeValue.text(jQuery(this).val());
                });
        }
    }

    return {
        init: init,
        refresh: refresh,
        destroy: destroy
    };
})();
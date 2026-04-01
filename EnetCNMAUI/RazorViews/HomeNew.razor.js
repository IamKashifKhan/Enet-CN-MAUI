export class Helpers {
    static dotNetHelper;

    static setDotNetHelper(value) {
        Helpers.dotNetHelper = value;
    }

    static async setItemsOnSelectDate(sdate) {
        await Helpers.dotNetHelper.invokeMethodAsync('SetItemsOnSelectDate', sdate);
    }

    static async openDetailModal(id) {
        await Helpers.dotNetHelper.invokeMethodAsync('OpenDetailModal', id);
    }
}

window.Helpers = Helpers;

function initOwl(selector, options) {
    const $elements = typeof selector === "string" ? $(selector) : selector;

    if (!$elements || !$elements.length) return;

    $elements.each(function () {
        const $this = $(this);

        if ($this.hasClass('owl-loaded')) {
            return;
        }

        $this.owlCarousel(options);
    });
}

export function initCategoriesSlider() {
    initOwl('.categories-slider', {
        loop: true,
        margin: 30,
        nav: false,
        dots: false,
        autoplay: false,
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

export function initOffcanvasCategoriesSlider() {
    initOwl('.offcanvas-categories-slider', {
        loop: true,
        margin: 20,
        nav: false,
        dots: false,
        autoplay: false,
        smartSpeed: 800,
        responsive: {
            0: { items: 3 },
            480: { items: 4 },
            768: { items: 5 }
        }
    });
}

export function initHeroSlider() {
    initOwl('.hero-slider', {
        items: 1,
        loop: true,
        nav: false,
        dots: true,
        autoplay: false,
        autoplayTimeout: 4000,
        smartSpeed: 800,
        dotsEach: 1,
        navText: [
            '<i class="fa fa-chevron-left"></i>',
            '<i class="fa fa-chevron-right"></i>'
        ]
    });
}

export function initRedeemedSlider() {
    initOwl('.redeemed-slider', {
        loop: true,
        margin: 20,
        nav: false,
        dots: false,
        autoplay: false,
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

export function initOffersSlider() {
    initOwl('.offers-slider', {
        loop: true,
        margin: 20,
        nav: false,
        dots: false,
        autoplay: false,
        autoplayTimeout: 5000,
        smartSpeed: 900,
        dotsEach: 1,
        stagePadding: 5,
        responsive: {
            0: { items: 2 },
            576: { items: 3 },
            768: { items: 4 },
            1200: { items: 5 }
        }
    });
}

export function initFeaturedOffersSlider() {
    initOwl('.featured-offers-slider', {
        loop: true,
        margin: 20,
        nav: false,
        dots: false,
        autoplay: false,
        autoplayTimeout: 5000,
        smartSpeed: 900,
        stagePadding: 80,
        responsive: {
            0: { items: 1, stagePadding: 20 },
            768: { items: 2, stagePadding: 40 },
            1200: { items: 3, stagePadding: 80 }
        }
    });
}

export function initSuggestedSlider() {
    initOwl('.suggested-slider', {
        loop: true,
        margin: 15,
        nav: false,
        dots: false,
        autoplay: false,
        autoplayTimeout: 3000,
        smartSpeed: 600,
        responsive: {
            0: { items: 1.2 },
            576: { items: 1.2 },
            768: { items: 1.2 }
        }
    });
}

export function initToggle() {
    $(document).off('click', '.toggle-wrapper button');
    $(document).on('click', '.toggle-wrapper button', function () {
        $('.toggle-wrapper button').removeClass('active');
        $(this).addClass('active');
        $('#offersScreen, #businessScreen').addClass('hidden');
        $('#' + $(this).data('target')).removeClass('hidden');
    });
}

export function initBusinessAccordion() {
    $(document).off('click', '.business-header');
    $(document).on('click', '.business-header', function () {
        const parent = $(this).closest('.business-item');
        const body = parent.find('.business-body');

        if (parent.hasClass('active')) {
            parent.removeClass('active');
        } else {
            $('.business-item').removeClass('active');
            parent.addClass('active');

            if (!body.data('owl-initialized')) {
                initOwl(body.find('.inner-slider'), {
                    loop: true,
                    margin: 15,
                    nav: false,
                    dots: false,
                    autoplay: false,
                    autoplayTimeout: 3000,
                    smartSpeed: 600,
                    responsive: {
                        0: { items: 1.2 },
                        768: { items: 1.2 }
                    }
                });

                body.data('owl-initialized', true);
            }
        }
    });
}

export function initHeartAnimation() {
    $(document).off('click', '.heart');
    $(document).on('click', '.heart', function () {
        $(this).toggleClass('active');

        if ($(this).hasClass('active')) {
            $(this).html('<i class="fa-solid fa-heart"></i>');
        } else {
            $(this).html('<i class="fa-regular fa-heart"></i>');
        }
    });
}

export function showOffcanvas(selector) {
    const el = document.querySelector(selector);
    if (!el) return;
    // Requires Bootstrap JS to be loaded on the page
    const instance = bootstrap.Offcanvas.getOrCreateInstance(el);
    instance.show();
}
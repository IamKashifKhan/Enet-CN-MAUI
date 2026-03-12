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

// OwlCarousel Initializations - Export functions to be called on demand
export function initCategoriesSlider() {
    $('.categories-slider').owlCarousel({
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

export function initHeroSlider() {
    $('.hero-slider').owlCarousel({
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
    $('.redeemed-slider').owlCarousel({
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
    $('.offers-slider').owlCarousel({
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
            768: { items: 5 },
            1200: { items: 6 }
        }
    });
}

export function initSuggestedSlider() {
    $('.suggested-slider').owlCarousel({
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
    $('.toggle-wrapper button').click(function () {
        $('.toggle-wrapper button').removeClass('active');
        $(this).addClass('active');
        $('#offersScreen, #businessScreen').addClass('hidden');
        $('#' + $(this).data('target')).removeClass('hidden');
    });
}

export function initHeart() {
    $(document).on('click', '.heart', function () {
        $(this).text($(this).text() === "♡" ? "♥" : "♡");
    });
}

export function initBusinessAccordion() {
    $('.business-header').on('click', function () {
        const parent = $(this).closest('.business-item');
        const body = parent.find('.business-body');

        if (parent.hasClass('active')) {
            parent.removeClass('active');
        } else {
            $('.business-item').removeClass('active');
            parent.addClass('active');

            if (!body.data('owl-initialized')) {
                body.find('.inner-slider').owlCarousel({
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
    $(document).on('click', '.heart', function () {
        $(this).toggleClass('active');
        if ($(this).hasClass('active')) {
            $(this).html('<i class="fa-solid fa-heart"></i>');
        } else {
            $(this).html('<i class="fa-regular fa-heart"></i>');
        }
    });
}

// Initialize all sliders and handlers on demand
export function initAllSliders() {
    initCategoriesSlider();
    initHeroSlider();
    initRedeemedSlider();
    initOffersSlider();
    initSuggestedSlider();
    initToggle();
    initHeart();
    initBusinessAccordion();
    initHeartAnimation();
}

// Auto-initialize on DOM ready
$(document).ready(function () {
    initAllSliders();
});

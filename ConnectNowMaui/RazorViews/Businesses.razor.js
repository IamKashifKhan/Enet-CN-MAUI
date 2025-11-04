export class Helpers {
    static dotNetHelper;

    static setDotNetHelper(value) {
        Helpers.dotNetHelper = value;
    }

   
}
window.Helpers = Helpers;

export function initCatSlider() {
    const commonOptions = { // Configuration
        type: 'slider', startAt: 0, focusAt: 0, perView: 6, gap: 10, breakpoints: { 9999: { perView: 6 } }
    };
    const initSlider = (selector, onMount = null) => { // Initializer
        const element = document.querySelector(selector);
        if (element) {
            const glide = new Glide(element, commonOptions);
            if (onMount) glide.on('mount.before', () => onMount(element));
            glide.mount();
        }
    };
    const adjustSlideWidths = (sliderElement) => { // Width Adjustment
        setTimeout(() => {
            const slidesContainer = sliderElement.querySelector('.glide__slides');
            const slides = slidesContainer.querySelectorAll('.glide__slide');
            let totalWidth = 0;
            slides.forEach(slide => {
                const style = window.getComputedStyle(slide);
                totalWidth += slide.offsetWidth + parseFloat(style.marginLeft || 0) + parseFloat(style.marginRight || 0);
            });
            slidesContainer.style.width = `${totalWidth}px`;
        }, 0);
    };
    initSlider('.bus-cat-main', adjustSlideWidths); // Bus-Cat-Main
    initSlider('.bus-cat-sub', adjustSlideWidths); // Bus-Cat-SUB
}


export function initToggleSwitch() {
 
    // Toggle for Grid/List View of Business
    const toggle = document.getElementById('card_toggle');
    const container = document.getElementById('card_container');
    if (toggle && container) {
        toggle.addEventListener('change', () => {
            const isGrid = toggle.checked;
            container.classList.toggle('card-grid', isGrid);
            container.classList.toggle('card-list', !isGrid);
            container.querySelectorAll('.card').forEach(card => {
                const a = card.querySelector('a');
                if (!a) return;
                const title = a.querySelector('.card-title');
                const img = a.querySelector('.card-img');
                const loc = a.querySelector('.card-loc');
                const offer = a.querySelector('.card-offer');
                if (!(title && img && loc && offer)) return;
                const locOfferWrapper = loc.parentElement === offer.parentElement ? loc.parentElement : null;
                if (!locOfferWrapper) return;
                while (a.firstChild) a.removeChild(a.firstChild);
                if (isGrid) { // Grid: title + div > img + div > loc + offer
                    a.appendChild(title);
                    const newWrapper = document.createElement('div');
                    newWrapper.appendChild(img);
                    newWrapper.appendChild(locOfferWrapper);
                    a.appendChild(newWrapper);
                } else { // List: img + div > title + div > loc + offer
                    a.appendChild(img);
                    const newWrapper = document.createElement('div');
                    newWrapper.appendChild(title);
                    newWrapper.appendChild(locOfferWrapper);
                    a.appendChild(newWrapper);
                }
            });
        });
    }


}

export function owlCarouselstart() {
    var $owl = $(".bus-cat-main #owl-tabs, .bus-cat-sub #owl-tabs");
    $owl.owlCarousel({
        loop: false, nav: false, dots: false, margin: 10, stagePadding: 13, autoWidth: true, responsiveClass: true
    });
}



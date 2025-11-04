window.setAppTheme = function (appTheme) {
    localStorage.setItem("theme", appTheme);
};

// Automatically apply theme-dark to <body> before Blazor starts
document.addEventListener("DOMContentLoaded", function () {

    const theme = localStorage.getItem("theme") || "light";

    document.body.classList.add(`theme-${theme}`);
    document.documentElement.className = `theme-${theme}`;
});

window.applyThemeClass = function () {
    const theme = localStorage.getItem("theme") || "light";
    const themeClass = `theme-${theme}`;
    // Remove existing theme classes
    document.body.classList.remove("theme-dark", "theme-light");
    document.documentElement.classList.remove("theme-dark", "theme-light");
    // Add new theme class
    document.body.classList.add(themeClass);
    document.documentElement.classList.add(themeClass);
    // Force layout reflow on iOS to ensure theme class takes effect
    void document.body.offsetHeight; // This line forces a reflow
    requestAnimationFrame(() => {
        // Optional: re-apply class just in case
        document.body.classList.add(themeClass);
        document.documentElement.classList.add(themeClass);
        // Notify Blazor
        //DotNet.invokeMethodAsync("ApexConnect", "ThemeUpdatedEvent");
    });
}





// Theme Switching
document.addEventListener('DOMContentLoaded', () => {
    const htmlElement = document.documentElement;
    const bodyElement = document.body;
    const themeTrigger = document.getElementById('themeDropdown');
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

// Sticky Header on Scroll-Y DOWN > 9 / UP < 9
document.addEventListener('DOMContentLoaded', (event) => {
    const headerElement = document.querySelector('header');
    let lastScrollY = window.scrollY;
    window.addEventListener('scroll', function () {
        let currentScrollY = window.scrollY;
        if (currentScrollY > lastScrollY && currentScrollY > 9) { // greater than 9px
            headerElement.classList.add('transi_head');
        } else if (currentScrollY < lastScrollY && currentScrollY < 9) { // less than 9px
            headerElement.classList.remove('transi_head');
        }
        lastScrollY = currentScrollY;
    });
});

// Tooltip "aktivieren"
document.addEventListener('DOMContentLoaded', (event) => {
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
});

// Toggle Password View
const togglePassword = document.querySelector('#togglePassword');
const password = document.querySelector('[type=password]');
if (togglePassword && password) {
    togglePassword.addEventListener('click', () => {
        const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
        password.setAttribute('type', type);
        togglePassword.classList.toggle('bi-eye');
        togglePassword.classList.toggle('bi-eye-slash');
    });
}

// Hover Zoom for Offers Card Image
const imageSizeCache = new Map();
document.querySelectorAll('.offers .card-img').forEach(card => {
    const imageUrl = card.style.backgroundImage.slice(5, -2);
    const img = new Image();
    img.src = imageUrl;
    img.onload = function () {
        const elementWidth = card.getBoundingClientRect().width;
        const elementHeight = card.getBoundingClientRect().height;
        const imgWidth = img.width;
        const imgHeight = img.height;
        const elementRatio = elementWidth / elementHeight;
        const imgRatio = imgWidth / imgHeight;
        let baseWidth, baseHeight;
        if (imgRatio > elementRatio) {
            baseHeight = elementHeight;
            baseWidth = (elementHeight * imgRatio);
        } else {
            baseWidth = elementWidth;
            baseHeight = (elementWidth / imgRatio);
        }
        const newWidth = baseWidth * 1.03;
        const newHeight = baseHeight * 1.03;
        const altWidth = baseWidth * 1.05;
        const altHeight = baseHeight * 1.05;
        if (card.parentElement.tagName.toLowerCase() === 'a') {
            card.style.setProperty('--hover-background-size', `${newWidth}px ${newHeight}px`);
        } else {
            card.style.setProperty('--hover-background-size', `${altWidth}px ${altHeight}px`);
        }
    };
});

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

// Glide-JS Configuration
document.addEventListener('DOMContentLoaded', () => {
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
});

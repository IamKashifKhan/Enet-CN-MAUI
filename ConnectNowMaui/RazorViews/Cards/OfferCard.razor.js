export function showOffcanvas(selector) {
    const el = document.querySelector(selector);
    if (!el) return;
    // Requires Bootstrap JS to be loaded on the page
    const instance = bootstrap.Offcanvas.getOrCreateInstance(el);
    instance.show();
}

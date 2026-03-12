// wwwroot/js/gmapsInterop.js
// Google Maps Interop - ensures gmapsInterop is available globally
// This file is loaded to make sure the Google Maps interop functions are available

// The actual implementation is in map.js which gets loaded after this
// This is a placeholder to prevent 404 errors

(function () {
    // Wait for map.js to load and provide gmapsInterop
    function waitForGmapsInterop() {
        if (window.gmapsInterop) {
            // Already available
            return;
        }
        
        // Poll for gmapsInterop to become available
        var attempts = 0;
        var maxAttempts = 50; // 5 seconds max wait
        
        var interval = setInterval(function() {
            attempts++;
            if (window.gmapsInterop || attempts >= maxAttempts) {
                clearInterval(interval);
            }
        }, 100);
    }
    
    // Run on DOM ready
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', waitForGmapsInterop);
    } else {
        waitForGmapsInterop();
    }
})();

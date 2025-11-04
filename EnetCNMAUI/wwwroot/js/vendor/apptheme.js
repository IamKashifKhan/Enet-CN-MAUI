window.setAppTheme = function (appTheme) {
    localStorage.setItem("theme", appTheme);
};

// Automatically apply theme-dark to <body> before Blazor starts
document.addEventListener("DOMContentLoaded", function () {
    const theme = localStorage.getItem("theme") || "light";
    document.body.classList.add(`theme-${theme}`);
});

window.onerror = function (message, source, lineno, colno, error) {
    console.error("Global JS Error:", message, source, error);
};

window.applyThemeClass = function () {

    const theme = localStorage.getItem("theme") || "light";
    const themeClass = `theme-${theme}`;

    // Remove existing theme classes if any
    document.body.classList.remove("theme-dark", "theme-light");

    // Add the current theme class
    document.body.classList.add(themeClass);

    // Toggle Password View
    //const togglePassword = document.querySelector('#togglePassword');
    //const password = document.querySelector('[type=password]');
    //if (togglePassword && password) {
    //    togglePassword.addEventListener('click', () => {

    //        // Toggle the type attribute
    //        const type = password.getAttribute('type') === 'text' ? 'password' : 'text';
    //        password.setAttribute('type', type);

    //        // Toggle the icon class
    //        togglePassword.classList.toggle('bi-eye');
    //        togglePassword.classList.toggle('bi-eye-slash');
    //    });
    //}


    // Send theme updated event
   // DotNet.invokeMethodAsync("EnetCNMAUI", "ThemeUpdatedEvent");
}


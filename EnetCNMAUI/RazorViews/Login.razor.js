export function setPasswordViewToggle() {
    // Toggle Password View
    const togglePassword = document.querySelector('#togglePassword');
    const password = document.querySelector('[type=password]');
    if (togglePassword && password) {
        togglePassword.addEventListener('click', () => {

            // Toggle the type attribute
            const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
            password.setAttribute('type', type);

            // Toggle the icon class
            togglePassword.classList.toggle('bi-eye');
            togglePassword.classList.toggle('bi-eye-slash');
        });
    }
}
export class Helpers {
    static dotNetHelper;

    static setDotNetHelper(value) {
        Helpers.dotNetHelper = value;
    }

    static async resetTabCount(n) {

        await Helpers.dotNetHelper.invokeMethodAsync('resetTabCount', n);
    }
    static async callApiService(n) {

        await Helpers.dotNetHelper.invokeMethodAsync('callApiService', n);
    }
}
window.Helpers = Helpers;

export function initTabs() {


    var currentTab = 0; // Current tab is set to be the first tab (0)
    showTab(currentTab); // Display the current tab

    function showTab(n) {
        // This function will display the specified tab of the form...
        var x = document.getElementsByClassName("tab");
        x[n].style.display = "block";
        //... and fix the Previous/Next buttons:
        if (n == 0) {
            document.getElementById("prevBtn").style.display = "none";
        } else {
            document.getElementById("prevBtn").style.display = "inline";
        }
        if (n == (x.length - 1)) {
            document.getElementById("nextBtn").innerHTML = "Continue";
        } else {
            document.getElementById("nextBtn").innerHTML = "Next";
        }
        //... and run a function that will display the correct step indicator:
        fixStepIndicator(n+1)
        setPasswordViewToggle();
    }

    function nextPrev(n) {
        // This function will figure out which tab to display
        var x = document.getElementsByClassName("tab");
        // Exit the function if any field in the current tab is invalid:
        if (n == 1 && !validateForm()) return false;
        // Hide the current tab:
        x[currentTab].style.display = "none";
        // Increase or decrease the current tab by 1:
        currentTab = currentTab + n;
        // if you have reached the end of the form...
        if (currentTab >= x.length) {
            // ... the form gets submitted:
            document.getElementById("regForm").submit();
            return false;
        }
        // Otherwise, display the correct tab:
        showTab(currentTab);
    }

    function validateForm() {
        // This function deals with validation of the form fields
        var x, y, i, valid = true;
        x = document.getElementsByClassName("tab");
        y = x[currentTab].getElementsByTagName("input");
        // A loop that checks every input field in the current tab:
        for (i = 0; i < y.length; i++) {
            // If a field is empty...
            if (y[i].value == "") {
                // add an "invalid" class to the field:
                y[i].className += " invalid";
                // and set the current valid status to false
                valid = false;
            }
        }
        // If the valid status is true, mark the step as finished and valid:
        if (valid) {
            document.getElementsByClassName("step")[currentTab].className += " finish";
        }
        return valid; // return the valid status
    }

    function fixStepIndicator(n) {
        // This function removes the "active" class of all steps...
        var i, x = document.getElementsByClassName("step");
        for (i = 0; i < x.length; i++) {
            x[i].className = x[i].className.replace(" active", "");
        }
        //... and adds the "active" class on the current step:
        x[n].className += " active";
    }



    // Toggle Password View
  

}

export function nextPrev(n, currentTab) {
    // This function will figure out which tab to display
    var x = document.getElementsByClassName("tab");
    // Exit the function if any field in the current tab is invalid:
    if (n == 1 && !validateForm(currentTab)) {
        Helpers.resetTabCount(n);
        return false;
    };
    // Hide the current tab:
    x[currentTab].style.display = "none";
    // Increase or decrease the current tab by 1:
    currentTab = currentTab + n;
    Helpers.callApiService(currentTab);
    // if you have reached the end of the form...
    if (currentTab >= x.length) {
        // ... the form gets submitted:
        document.getElementById("regForm").submit();
        return false;
    }
    // Otherwise, display the correct tab:
    showTab(currentTab);

}

export function showTab(n) {
    // This function will display the specified tab of the form...
    var x = document.getElementsByClassName("tab");
    x[n].style.display = "block";
    //... and fix the Previous/Next buttons:
    if (n == 0) {
        document.getElementById("prevBtn").style.display = "none";
    } else {
        document.getElementById("prevBtn").style.display = "inline";
    }
    if (n == (x.length - 1)) {
        document.getElementById("nextBtn").innerHTML = "Continue";
    } else {
        document.getElementById("nextBtn").innerHTML = "Next";
    }
    //... and run a function that will display the correct step indicator:
    fixStepIndicator(n)
}



export function validateForm(currentTab) {
    // This function deals with validation of the form fields
    var x, y, i, valid = true;
    x = document.getElementsByClassName("tab");
    y = x[currentTab].getElementsByTagName("input");

    // A loop that checks every input field in the current tab:
    for (i = 0; i < y.length; i++) {
        // Remove previous "invalid" class
        y[i].className = y[i].className.replace(" invalid", "");

        // If a field is empty...
        //if (y[i].value.trim() == "") {
        //    // Add an "invalid" class to the field:
        //    y[i].className += " is-invalid";
        //    // Set the current valid status to false
        //    valid = false;
        //}

        if (y[i].type === "tel" && y[i].id === "phone") {
            const phonePattern = /^(\+?1\s?)?(\([0-9]{3}\)|[0-9]{3})[\s\-]?[0-9]{3}[\s\-]?[0-9]{4}$/;
            if (!phonePattern.test(y[i].value.trim())) {
                y[i].className += " is-invalid";
                valid = false;
            } else {
                y[i].className = y[i].className.replace(" is-invalid", "");
            }
        }

        else if (y[i].type === "text" && (y[i].placeholder === "First Name" || y[i].placeholder === "Last Name")) {
            const namePattern = /^[a-zA-Z]+$/; // Single word, alphabets only
            if (!namePattern.test(y[i].value.trim())) {
                y[i].className += " is-invalid";
                valid = false;
            } else {
                y[i].className = y[i].className.replace(" is-invalid", "");
            }
        }

        else if (y[i].type === "text" && y[i].id === "code") {
            const codePattern = /^\d{6}$/; // Exactly 6 digits
            if (!codePattern.test(y[i].value.trim())) {
                y[i].className += " is-invalid";
                valid = false;
            } else {
                y[i].className = y[i].className.replace(" is-invalid", "");
            }
        }




        else if (y[i].type === "text" && (y[i].placeholder === "First Name" || (y[i].placeholder === "Last Name"))) {
            // Validate full name (ensure it has at least two words)
            const namePattern = /^[a-zA-Z]+(?: [a-zA-Z]+)+$/;
            if (!namePattern.test(y[i].value)) {
                y[i].className += " is-invalid";
                valid = false;
            }
        }

        else if (y[i].type === "email" && y[i].placeholder === "Email Address") {
            const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
            if (!emailPattern.test(y[i].value.trim())) {
                y[i].className += " is-invalid";
                valid = false;
            }
        }

        else if (y[i].id === "zipcode") {
            const zipPattern = /^\d{5}(-\d{4})?$/; // Supports 5-digit and ZIP+4 (like 12345 or 12345-6789)
            if (!zipPattern.test(y[i].value.trim())) {
                y[i].className += " is-invalid";
                valid = false;
            }
        }
        else if (y[i].type === "checkbox" && y[i].id === "termsCheck") {
            if (!y[i].checked) {
                y[i].className += " is-invalid";
                valid = false;
            } else {
                y[i].className = y[i].className.replace(" is-invalid", "");
            }
        }



    }

    // Password matching validation
    const password = document.getElementById("password");
    const confirmPassword = document.getElementById("confirm-password");

    if (password && confirmPassword) {
        if (password.value !== confirmPassword.value) {
            password.className += " is-invalid";
            confirmPassword.className += " is-invalid";
            valid = false;
            //alert("Passwords do not match."); // Optionally, show an alert
        }
    }

    // If the valid status is true, mark the step as finished and valid:
    if (valid) {
        document.getElementsByClassName("step")[currentTab].className += " finish";
    }
    return valid; // return the valid status
}


export function fixStepIndicator(n) {
    // This function removes the "active" class of all steps...
    var i, x = document.getElementsByClassName("step");
    for (i = 0; i < x.length; i++) {
        x[i].className = x[i].className.replace(" active", "");
    }
    //... and adds the "active" class on the current step:
    x[n].className += " active";
}

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

export function validatePhone(selector) {
    const input = document.querySelector(selector);
    if (!input) return;

    const value = input.value.trim();
    const pattern = /^\+?[0-9]{10,15}$/; // Accepts international-style numbers

    input.classList.remove("is-valid", "is-invalid");
    if (pattern.test(value)) {
        input.classList.add("is-valid");
    } else {
        input.classList.add("is-invalid");
    }
}



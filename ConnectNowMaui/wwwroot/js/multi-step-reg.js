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
    document.getElementById("nextBtn").innerHTML = "Submit";
  } else {
    document.getElementById("nextBtn").innerHTML = "Next";
  }
  //... and run a function that will display the correct step indicator:
  fixStepIndicator(n)
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
  var x, y, i, valid = true;
  x = document.getElementsByClassName("tab");
  y = x[currentTab].getElementsByTagName("input");

  for (i = 0; i < y.length; i++) {
    const input = y[i];

    // Skip checkbox and radio inputs
    if (input.type === "checkbox" || input.type === "radio" || input.classList.contains("otp-input")) continue;

    // Initial validation check
    if (input.value.trim() === "") {
      input.classList.remove("is-valid");
      input.classList.add("is-invalid");
      valid = false;
    } else {
      input.classList.remove("is-invalid");
      input.classList.add("is-valid");
    }

    // Add real-time validation listener only once
    if (!input.hasAttribute("data-listener-added")) {
      input.addEventListener("input", function () {
        if (this.value.trim() === "") {
          this.classList.remove("is-valid");
          this.classList.add("is-invalid");
        } else {
          this.classList.remove("is-invalid");
          this.classList.add("is-valid");
        }
      });
      input.setAttribute("data-listener-added", "true");
    }
  }

  // Add 'finish' class to step indicator only once
  if (valid) {
    var stepEl = document.getElementsByClassName("step")[currentTab];
    if (!stepEl.classList.contains("finish")) {
      stepEl.classList.add("finish");
    }
  }

  return valid;
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

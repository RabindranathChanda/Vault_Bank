const form = document.querySelector("form"),
    nextBtn = document.getElementById("<%= NextButton.ClientID %>"),
    backBtn = document.getElementById("<%= BackButton.ClientID %>"),
    allInput = form.querySelectorAll(".first input, .first select");

nextBtn.addEventListener("click", (event) => {
    let allFilled = true;
    allInput.forEach(input => {
        if (input.value.trim() === "") {
            allFilled = false;
        }
    });
    if (allFilled) {
        form.classList.add('secActive');
    }
    event.preventDefault(); // Prevent default form submission
});

backBtn.addEventListener("click", (event) => {
    form.classList.remove('secActive');
    event.preventDefault(); // Prevent default form submission
});





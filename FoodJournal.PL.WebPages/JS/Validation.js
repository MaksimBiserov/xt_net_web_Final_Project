
function validateMinValue() {
    let message = "";

    if (document.getElementById("minValue").validity.rangeUnderflow) {
        message = "The value cannot be less than 0";
        alert(message);
    }
}

function validateLogin() {
    let message = "";
    let field = document.getElementById("charLogin");
    let fieldData = field.value;

    if (fieldData.length > 12 || fieldData.length < 4) {
        message = "Login must contain between 4 and 12 characters";
        alert(message);
    }
}

function validatePassword() {
    let message = "";
    let field = document.getElementById("charPassword");
    let fieldData = field.value;

    if (fieldData.length > 12 || fieldData.length < 6) {
        message = "Password must contain between 6 and 12 characters";
        alert(message);
    }
}

function validateField() {
    let message = "";
    let field = document.getElementById("charField");
    let fieldData = field.value;

    if (fieldData.length > 30 || fieldData.length < 2) {
        message = "Field must contain between 2 and 30 characters";
        alert(message);
    }
}
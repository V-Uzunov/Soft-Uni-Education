function validate() {
    let username = $('#username');
    let email = $('#email');
    let password = $('#password');
    let confirmPassword = $('#confirm-password');
    let companyCheckbox = $('#company');
    let companyNumber = $('#companyNumber');
    let companyInfo = $('#companyInfo');
    let submitBtn = $('#submit');
    let validationDiv = $('#valid');
    let isValid = true;
    companyCheckbox.change(function () {
        if (companyCheckbox.is(':checked')) {
            companyInfo.css('display', 'block');
        } else {
            companyInfo.css('display', 'none');
        }
    });

    submitBtn.click((ev)=>{
        ev.preventDefault();
        validationParams();
        if (isValid) {
            validationDiv.css('display', 'block');
        }else{
            validationDiv.css('display', 'none');
        }
        isValid = true;
    });

    function validationParams() {
        let usernamePattern = /^[A-Za-z\d]{3,20}$/g;
        let passwordPattern = /^\w{5,15}$/g;
        let confirmPasswordPattern = /^\w{5,15}$/g;
        let emailPattern = /^.*?@.*?\..*$/g;
        validator(username, usernamePattern);
        validator(email, emailPattern);
        if (password.val() === confirmPassword.val()) {
            validator(password, passwordPattern);
            validator(confirmPassword, confirmPasswordPattern);
        } else {
            confirmPassword.css('border', 'solid red');
            password.css('border', 'solid red');
            isValid =false;
        }
        if (companyCheckbox.is(':checked')) {
            validateCompanyInfo();
        }
    }

    function validateCompanyInfo() {
        let numValue = +companyNumber.val();
        if (1000 <= numValue && numValue <= 9999) {
            companyNumber.css('border', 'none');
        }else{
            companyNumber.css('border', 'solid red');
            isValid =false;
        }
    }

    function validator(input, pattern) {
        if (pattern.test(input.val())) {
            input.css('border', 'none');
        }else{
            input.css('border', 'solid red');
            isValid =false;
        }
    }
}

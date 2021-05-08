$('#form-payment').submit(function (e) {
    e.preventDefault();
    var a = $('#info-account-number').val();
    var div = document.getElementById('error-noti');
    if (a.length !== 14) {
        div.innerHTML = "Số tài khoản không chính xác";
    }
    else {
        $(this).unbind('submit').submit()
    }
})
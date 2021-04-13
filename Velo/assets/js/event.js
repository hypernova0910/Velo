//function agreePolicy() {
//    var footerFixed = document.querySelector('.welcome-footer-fixed-bottom')
//    var container = footerFixed.parentElement
//    container.removeChild(footerFixed)
//}

$('.welcome-footer__btn-child').click(function () {
    $('.welcome-footer-fixed-bottom').remove()
})

function closeEventListeners() {
    $('.form-container').click(function (e) {
        if (!e.target.closest('.form')) {
            //$('.form-container').remove()
            $('.form-container').addClass('hidden')
            const scrollY = document.body.style.top;
            document.body.style.position = '';
            document.body.style.top = '';
            window.scrollTo(0, parseInt(scrollY || '0') * -1);
            $('body').css('padding-right', '0px')
        }
    })

    $('.form-close').click(function () {
        //$('.form-container').remove()
        $('.form-container').addClass('hidden')
        const scrollY = document.body.style.top;
        document.body.style.position = '';
        document.body.style.top = '';
        window.scrollTo(0, parseInt(scrollY || '0') * -1);
        $('body').css('padding-right', '0px')
    })
}

$('#btn-sign-in').click(function () {
    $('#form-sign-in').parent().removeClass('hidden')
    const scrollY = window.scrollY
    $('body').css('position', 'fixed')
    $('body').css('top', `-${scrollY}px`)
    $('body').css('padding-right', '15px')
    closeEventListeners()
})

$('#btn-sign-up').click(function () {
    $('#form-sign-up').parent().removeClass('hidden')
    const scrollY = window.scrollY
    $('body').css('position', 'fixed')
    $('body').css('top', `-${scrollY}px`)
    $('body').css('padding-right', '15px')
    closeEventListeners()
})

//$('#SignUp').click(function() {
//    var uid = $("#id").val();
//    var name = $("#name").val();
//    var pwd1 = $("#password1").val();
//    var pwd2 = $("#password_confirmation").val();
//    var email = $("#email1").val();
//    var birthday = $("#birthday").val();
//    var gender = $("#gender").val();
//    var nationality = $("#nation").val();
//    var hobby = $("#hobby").val();
//})

$(document).ready(function () {

    var readURL = function (input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('.profile-pic').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }
    }

    $(".form-avatar").on('change', function () {
        readURL(this);
    });

    $(".upload-button").on('click', function () {
        $(".form-avatar").click();
    });
});
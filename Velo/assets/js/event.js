//function agreePolicy() {
//    var footerFixed = document.querySelector('.welcome-footer-fixed-bottom')
//    var container = footerFixed.parentElement
//    container.removeChild(footerFixed)
//}

$('.welcome-footer__btn-child').click(function () {
    $('.welcome-footer-fixed-bottom').remove()
})

$(document).on('click', '.form-container', function (e) {
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

$(document).on('click', '.form-close', function (e) {
    //$('.form-container').remove()
    $('.form-container').addClass('hidden')
    const scrollY = document.body.style.top;
    document.body.style.position = '';
    document.body.style.top = '';
    window.scrollTo(0, parseInt(scrollY || '0') * -1);
    $('body').css('padding-right', '0px')
})

<<<<<<< HEAD
$('#btn-sign-in').click(function () {
=======
$(document).on('click', '#btn-sign-in', function (e) {
    //$('body').append(
    //    `<div class="bg-dark form-container container-level-2">
    //        <form action="" method="POST" class="form" id="form-sign-in">
    //            <h2 class="form__heading">Đăng nhập Velo</h2>
    //            <p class="form__desc">Nơi tình yêu kết trái</p>

    //            <div class="spacer"></div>

    //            <div class="form-group">
    //                <label for="email" class="form-label">Email</label>
    //                <input id="email" name="email" type="text" placeholder="VD: email@domain.com" class="form-control">
    //                <span class="form-message"></span>
    //            </div>

    //            <div class="form-group">
    //                <label for="password" class="form-label">Mật khẩu</label>
    //                <input id="password" name="password" type="password" placeholder="Nhập mật khẩu" class="form-control">
    //                <span class="form-message"></span>
    //            </div>

    //            <button class="form-submit">Đăng nhập</button>

    //            <div class="form-close">
    //                <i class="fas fa-times"></i>
    //            </div>
    //        </form>
    //    </div>`
    //)
    //$('body').css('overflow', 'hidden')
>>>>>>> 0f74f67667f08a8bf0506de4fc3637e4f1fdb444
    $('#form-sign-in').parent().removeClass('hidden')
    const scrollY = window.scrollY
    $('body').css('position', 'fixed')
    $('body').css('top', `-${scrollY}px`)
    $('body').css('padding-right', '15px')
    //closeEventListeners()
})

$('#btn-sign-up').click(function () {
    $('#form-sign-up').parent().removeClass('hidden')
    const scrollY = window.scrollY
    $('body').css('position', 'fixed')
    $('body').css('top', `-${scrollY}px`)
    $('body').css('padding-right', '15px')
    //closeEventListeners()
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
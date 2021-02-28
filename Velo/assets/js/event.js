//function agreePolicy() {
//    var footerFixed = document.querySelector('.welcome-footer-fixed-bottom')
//    var container = footerFixed.parentElement
//    container.removeChild(footerFixed)
//}

$('.welcome-footer__btn-child').click(function () {
    $('.welcome-footer-fixed-bottom').remove()
})

$('#btn-sign-in').click(function () {
    $('body').append(
        `<div class="bg-dark form-container">
            <form action="" method="POST" class="form" id="form-sign-in">
                <h3 class="form__heading">Đăng nhập Velo</h3>
                <p class="form__desc">Nơi tình yêu kết trái</p>

                <div class="spacer"></div>

                <div class="form-group">
                    <label for="email" class="form-label">Email</label>
                    <input id="email" name="email" type="text" placeholder="VD: email@domain.com" class="form-control">
                    <span class="form-message"></span>
                </div>

                <div class="form-group">
                    <label for="password" class="form-label">Mật khẩu</label>
                    <input id="password" name="password" type="password" placeholder="Nhập mật khẩu" class="form-control">
                    <span class="form-message"></span>
                </div>

                <button class="form-submit">Đăng nhập</button>

                <div class="form-close">
                    <i class="fas fa-times"></i>
                </div>
            </form>
        </div>`
    )

    $('.form-container').click(function (e) {
        if (!e.target.closest('.form')) {
            $('.form-container').remove()
        }
    })

    $('.form-close').click(function () {
        $('.form-container').remove()
    })
})
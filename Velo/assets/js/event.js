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
            $('.form-container').remove()
            const scrollY = document.body.style.top;
            document.body.style.position = '';
            document.body.style.top = '';
            window.scrollTo(0, parseInt(scrollY || '0') * -1);
            $('body').css('padding-right', '0px')
        }
    })

    $('.form-close').click(function () {
        $('.form-container').remove()
        const scrollY = document.body.style.top;
        document.body.style.position = '';
        document.body.style.top = '';
        window.scrollTo(0, parseInt(scrollY || '0') * -1);
        $('body').css('padding-right', '0px')
    })
}

$('#btn-sign-in').click(function () {
    $('body').append(
        `<div class="bg-dark form-container container-level-2">
            <form action="" method="POST" class="form" id="form-sign-in">
                <h2 class="form__heading">Đăng nhập Velo</h2>
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
    //$('body').css('overflow', 'hidden')
    const scrollY = window.scrollY
    $('body').css('position', 'fixed')
    $('body').css('top', `-${scrollY}px`)
    $('body').css('padding-right', '15px')
    closeEventListeners()
})

$('#btn-sign-up').click(function () {
    $('body').append(
        `<div class="bg-dark form-container container-level-2">
        <form action="" method="POST" class="form" id="form-sign-up">
            <h2 class="form__heading">Đăng ký Velo</h2>
            <p class="form__desc">Chào mừng bạn đến với Velo</p>

            <div class="spacer"></div>

            <div class="form-line">
                <div class="form-group">
                    <label for="id" class="form-label">Tên đăng nhập</label>
                    <input id="id" name="id" type="text" placeholder="Tên đăng nhập" class="form-control">
                    <span class="form-message"></span>
                </div>
                <div class="form-group">
                    <label for="name" class="form-label">Họ tên</label>
                    <input id="name" name="name" placeholder="Họ tên" type="text" class="form-control">
                    <span class="form-message"></span>
                </div>
            </div>

            <div class="form-line">
                <div class="form-group">
                    <label for="password" class="form-label">Mật khẩu</label>
                    <input id="password" name="password" type="password" placeholder="Nhập mật khẩu" class="form-control">
                    <span class="form-message"></span>
                </div>
                <div class="form-group">
                    <label for="password_confirmation" class="form-label">Xác nhận mật khẩu</label>
                    <input id="password_confirmation" name="password_confirmation" placeholder="Nhập lại mật khẩu" type="password" class="form-control">
                    <span class="form-message"></span>
                </div>
            </div>

            <div class="form-line">
                <div class="form-group">
                    <label for="birthday" class="form-label">Ngày sinh</label>
                    <input id="birthday" name="birthday" placeholder="Ngày sinh" type="date" class="form-control">
                    <span class="form-message"></span>
                </div>
                <div class="form-group">
                    <label for="email" class="form-label">Email</label>
                    <input id="email" name="email" type="email" placeholder="VD: email@domain.com" class="form-control">
                    <span class="form-message"></span>
                </div>
            </div>

            <div class="form-line">
                <div class="form-group">
                    <label for="nationality" class="form-label">Quốc tịch</label>
                    <select id="nation" name="nation" class="form-control">
                        <option value="1">Việt Nam</option>
                        <option value="2">Thái Lan</option>
                        <option value="3">Trung Quốc</option>
                        <option value="4">Nhật Bản</option>
                        <option value="5">Hàn Quốc</option>
                        <option value="6">Mỹ</option>
                        <option value="7">Canada</option>
                        <option value="8">Brazil</option>
                        <option value="9">Italiy</option>
                        <option value="10">Pháp</option>
                        <option value="11">Đức</option>
                        <option value="12">Nga</option>
                        <option value="13">Nam Phi</option>
                    </select>
                    <span class="form-message"></span>
                </div>

                <div class="form-group">
                    <label for="hobby" class="form-label">Sở thích</label>
                    <input id="hobby" name="hobby" type="text" placeholder="Sở thích" class="form-control" list="hobbies">
                    <datalist id="hobbies">
                        <option value="Ẩm thực"></option>
                        <option value="Làm đẹp"></option>
                        <option value="Thời trang"></option>
                        <option value="Nghiên cứu"></option>
                        <option value="Thể thao"></option>
                        <option value="Du lịch"></option>
                        <option value="Công nghệ"></option>
                        <option value="Động vật"></option>
                    </datalist>
                    <span class="form-message"></span>
                </div>
            </div>

            <button class="form-submit">Đăng ký</button>

            <div class="form-close">
                <i class="fas fa-times"></i>
            </div>
        </form>
    </div>`
    )
    const scrollY = window.scrollY
    $('body').css('position', 'fixed')
    $('body').css('top', `-${scrollY}px`)
    $('body').css('padding-right', '15px')
    closeEventListeners()
})
$('.navbar-btn').on('click', function (e) {
    $('.btn-active').removeClass('btn-active')
    $(e.target).addClass('btn-active')
    //console.log($(e.target))
})

$('#recent').on('click', function (e) {
    //$('.nav-area .field').remove()
    $.ajax({
        url: "/Velo/Recent/" + $('#id-user').val()
    }).done(function (rs) {
        $('.field').html(rs)
    }).fail(function (err) {
        console.log(err)
    })
})

$('#message').on('click', function (e) {
    //$('.nav-area .field').remove()
    //console.log($('#id-user').val())
    $.ajax({
        url: "/Velo/Message/" + $('#id-user').val(),
    }).done(function (rs) {
        $('.field').html(rs)
    }).fail(function (err) {
        console.log(err)
    })
})

$('#notification').on('click', function (e) {
    //console.log($('#id-user').val())
    //$('.nav-area .field').remove()
    $.ajax({
        url: "/Velo/Notification/" + $('#id-user').val()
    }).done(function (rs) {
        $('.field').html(rs)
    }).fail(function (err) {
        console.log(err)
    })
})

$('#edit').on('click', function (e) {
    $('.personal-info-area').empty()
    $.ajax({
        url: "/Velo/Edit/" + $('#id-user').val(),
    }).done(function (rs) {
        $('.personal-info-area').append(rs)
    }).fail(function (err) {
        console.log(err)
    })
})

$('#form-edit').submit(function (e) {
    e.preventDefault();
    var a = $('#name').val();
    var b = $('#password1').val();
    var c = $('#birthday').val();
    var d = $('#nation').val();
    var e = $('#hobby').val();
    var f = $('#password_confirmation').val();
    var g = $('#email1').val()
    var div = document.getElementById('spacer');
    if (a === "" || b === "" || c === "" || d === "" || e === "" || g === "") {
        div.innerHTML = "Thông tin chưa đầy đủ";
    }
    else if (b !== f) {
        div.innerHTML = "Mật khẩu không khớp";
    }
    else {
        $(this).unbind('submit').submit()
    }
})

$(function () {
    $.ajax({
        url: "/Velo/Recent/" + $('#id-user').val()
    }).done(function (rs) {
        $('.field').html(rs)
    }).fail(function (err) {
        console.log(err)
    })

    $.ajax({
        url: "/Velo/Photos/" + $('#id-user').val()
    }).done(function (rs) {
        $('.scroll-photos-area').html(rs)
    }).fail(function (err) {
        console.log(err)
    })
})

//function myFunction(id) {
//    document.getElementById(id).classList.toggle("show");
//}
//var buttons = document.getElementsByClassName('info-frame');
//var contents = document.getElementsByClassName('account-info');
//for (var i = 0; i < buttons.length; i++) {
//    buttons[i].addEventListener("click", function () {
//        //lấy value của button
//        var id = this.title;
//        //ẩn tất cả các menu con đang được hiển thị
//        for (var i = 0; i < contents.length; i++) {
//            contents[i].classList.remove("show");
//        }
//        //hiển thị menu vừa được click
//        myFunction(id);
//    });
//}
//window.addEventListener("click", function () {
//    if (!event.target.matches('.info-frame') && !event.target.matches('.account-info-detail') ) {
//        for (var i = 0; i < contents.length; i++) {
//            contents[i].classList.remove("show");
//        }
//    }
//});

//$('.log-out').on('click', function (e) {

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

//$('.chat-input input').keyup(function (e) {
//    if ($(this).val() == '')
//        $(this).removeAttr('good');
//    else
//        $(this).attr('good', '');
//});


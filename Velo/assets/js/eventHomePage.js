$('.navbar-btn').on('click', function (e) {
    $('.btn-active').removeClass('btn-active')
    $(e.target).addClass('btn-active')
    console.log($(e.target))
})

$('#recent').on('click', function (e) {
    $('.nav-area .field').remove()
    $.ajax({
        url: "/Velo/Recent",
    }).done(function (rs) {
        $('.nav-area').append(rs)
    }).fail(function (e) {
        console.log(err)
    })
})

$('#message').on('click', function (e) {
    $('.nav-area .field').remove()
    $.ajax({
        url: "/Velo/Message",
    }).done(function (rs) {
        
        $('.nav-area').append(rs)
    }).fail(function (e) {
        console.log(err)
    })
})

$('#notification').on('click', function (e) {
    $('.nav-area .field').remove()
    $.ajax({
        url: "/Velo/Notification",
    }).done(function (rs) {
        $('.nav-area').append(rs)
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

$(function () {
    $.ajax({
        url: "/Velo/Photos/" + $('#id-user').val(),
    }).done(function (rs) {
        $('.scroll-photos-area').append(rs)
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


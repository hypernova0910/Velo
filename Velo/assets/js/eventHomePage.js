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

//$('.chat-input input').keyup(function (e) {
//    if ($(this).val() == '')
//        $(this).removeAttr('good');
//    else
//        $(this).attr('good', '');
//});


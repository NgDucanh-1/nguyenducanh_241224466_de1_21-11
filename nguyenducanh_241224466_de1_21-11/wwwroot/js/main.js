// AssetHub - hiệu ứng giao diện cơ bản (nút "lên đầu trang")
$(function () {
    $(window).on('scroll', function () {
        $('.to-top').toggle($(this).scrollTop() > 200);
    });
    $('.to-top').on('click', function () {
        $('html, body').animate({ scrollTop: 0 }, 400);
    });
    $('.search-box input').on('focus', function () { $(this).select(); });

});
$(function () {
    $(document).on('click', '.loai-link', function (e) {
        e.preventDefault();
        var $a = $(this);
        if ($('#main-content').length === 0) { location.href = '/'; return; }
        $.get($a.data('url'), function (html) { $('#main-content').html(html); });
        $('.menu li').removeClass('active');
        $a.closest('li').addClass('active');
    });
});


$(document).ready(function() {
    
    var currentUrl = window.location.pathname;
    $('.nav-item .nav-link').each(function() {
        var linkUrl = $(this).attr('href');
        if (currentUrl === linkUrl || (currentUrl.startsWith(linkUrl) && linkUrl !== '/' && linkUrl.length > 1)) {
            $(this).addClass('active');
        }
    });
    
    setTimeout(function() {
        $('.alert').alert('close');
    }, 5000);
});

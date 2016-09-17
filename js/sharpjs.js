var reject = $("#license-reject");
var accept = $("#license-acceptbtn");
var licensing = $("#licensing-agreement");
var finaldownloadSection = $("#final-download-section");
finaldownloadSection.hide();


reject.click(function() {
    licensing.fadeOut(500, function() {
        licensing.empty();
        licensing.show();
        licensing.html('<div class="text-center"><h2>We\'re sorry we couldn\'t help you today.<h2> <h5>Maybe you should go check out some more projects.</h5> <a href="https://github.com/0xFireball" class="btn btn-default btn-lg">Take me away</a></div>');
    });
});


accept.click(function() {
    licensing.fadeOut(500, function() {
        licensing.empty();
        licensing.show();
        licensing.html('<div class="text-center"><h2>Great! Thanks for using SharpJS!</h2></div>');
        finaldownloadSection.fadeIn(500, function() {
            $('html, body').animate({
                scrollTop: finaldownloadSection.offset().top
            }, 460, "");
        });
    });
});
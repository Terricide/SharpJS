var overlay = $("<div/>", {id:"sjs-loader-overlay"});
var $j = $;
var loader = null;
var loaderText = null;

jQuery.fn.center = function () {
    this.css("position","absolute");
    this.css("top", Math.max(0, (($(window).height() - $(this).outerHeight()) / 2) + $(window).scrollTop()) + "px");
    this.css("left", Math.max(0, (($(window).width() - $(this).outerWidth()) / 2) + $(window).scrollLeft()) + "px");
    return this;
}

function resizeOverlay()
{
	//overlay.width = window.innerWidth;
	//overlay.height = window.innerHeight;
}
window.onresize = resizeOverlay;


// Create a large overlay for progress
function createProgressBarOverlay()
{
	resizeOverlay();
	$(".sharpjs-ccontainer").hide();
	$("body").append(overlay);
	loader = $('<div class="loader"><div id="loader-text"></div><div class="loader-inner ball-pulse"><div></div><div></div><div></div></div></div>');
	overlay.append(loader);
	
	//Text
	loaderText = $("#loader-text");
	loaderText.text("Preparing");
	loader.center();
}

// Remove the overlay when everything's done loading (if it worked!)
function removeProgressOverlay()
{
	overlay.fadeOut(400, "swing", function() {
		$j(".sharpjs-ccontainer").show();
	});
}


// A really nice-looking progress bar alternative
function updateSleekProgressBar(prefix, suffix, bytesLoaded, bytesTotal) {
	if (prefix == "Starting") //This is our cue that loading is done
	{
		removeProgressOverlay();
	}
	//alert("");
	var infoText = prefix;
	var updateText = function(txt) {
		loaderText.text(txt);
		loader.center();
	};
	
	var progressString;
	if (suffix === null) {
      progressString = prefix;
    } else {
      progressString = prefix + Math.floor(bytesLoaded) + suffix + " / " + Math.floor(bytesTotal) + suffix;
    }
	updateText(progressString);    
}

$(document).ready(function() {
	createProgressBarOverlay();
	onLoad(); //Run JSIL load
	/*
	setTimeout(function() {
		removeProgressOverlay();
	}, 1000);
	*/
});
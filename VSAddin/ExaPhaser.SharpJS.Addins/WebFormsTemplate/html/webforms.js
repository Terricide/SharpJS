jq = $;
$(document).on('mousedown', '.winform', function(event) {
	$ = jq;
    $('.winform').zIndex(1);
    $(this).zIndex(1000);
});
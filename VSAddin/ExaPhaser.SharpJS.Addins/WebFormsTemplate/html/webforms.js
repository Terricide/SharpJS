jq = $;
function windowFocused(event)
{
	$ = jq;
    $('.winform').zIndex(1);
    $(this).zIndex(1000);
}
$(document).on('mousedown', '.winform', windowFocused);
$(document).on('focus', '.winform', windowFocused);
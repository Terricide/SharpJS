function resizeCanvas()
{
	var canvas = document.getElementById('canvas');
	if (canvas)
	{
		canvas.width = window.innerWidth;
		canvas.height = window.innerHeight;
	}
}
resizeCanvas();
window.onresize = resizeCanvas
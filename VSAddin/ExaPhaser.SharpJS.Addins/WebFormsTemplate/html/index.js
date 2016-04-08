function resizeCanvas()
{
	var canvas = document.getElementById('canvas');
	canvas.width = window.innerWidth;
	canvas.height = window.innerHeight;
}
window.onresize = resizeCanvas;
resizeCanvas();
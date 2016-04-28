namespace System.Drawing
{
    public class Font
    {
        public FontStyle FontStyle { get; set; }
        public GraphicsUnit GraphicsUnit { get; set; }
        public byte GDICharSet { get; set; }
        public string FontName { get; set; }
        public float FontSize { get; set; }

        public Font(string fontName, float fontSize, FontStyle fontStyle = FontStyle.Regular, GraphicsUnit graphicsUnit = GraphicsUnit.Point, byte gdiCharSet = 0)
        {
            FontName = fontName;
            FontSize = fontSize;
            FontStyle = fontStyle;
            GraphicsUnit = graphicsUnit;
            GDICharSet = gdiCharSet;
        }
    }
}
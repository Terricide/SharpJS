namespace SharpJS.Dom.Elements
{
    public class FileUploadElement : Element
    {
        public FileUploadElement() : base("input")
        {
            this["type"] = "file";
        }

        public bool Hidden
        {
            set { Style = value ? "display:none;" : "display:inline;"; }
        }
    }
}
using System.ComponentModel;
using ExaPhaser.WebForms.Controls;

namespace System.Windows.Forms
{
    public class PictureBox : Control, ISupportInitialize
    {
        private readonly ImageView _imageView;

        public PictureBox()
        {
            _imageView = new ImageView();
            WebFormsControl = _imageView;
        }

        public string SourceUri
        {
            get { return _imageView.SourceURI; }
            set { _imageView.SourceURI = value; }
        }

        [WebFormsCompatStubOnly]
        public void BeginInit()
        {
        }

        [WebFormsCompatStubOnly]
        public void EndInit()
        {
        }
    }
}
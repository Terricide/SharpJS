using SharpJS.Dom;

namespace System.Windows.Forms
{
    public class MessageBox
    {
        #region Public Methods

        public static void Show(string message)
        {
            JSLibrary.Alert(message);
        }

        #endregion Public Methods
    }
}
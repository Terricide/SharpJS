using SharpJS.Dom;

namespace System.Diagnostics
{
    public class Process
    {
        #region Public Methods

        /// <summary>
        /// Opens a URL in a popup window.
        /// </summary>
        /// <param name="url"></param>
        public static void Start(string url)
        {
            JSLibrary.OpenLinkInNewTab(url);
        }

        #endregion Public Methods
    }
}
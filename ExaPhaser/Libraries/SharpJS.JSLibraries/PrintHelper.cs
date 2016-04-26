using JSIL;
using SharpJS.Dom;

namespace SharpJS.JSLibraries
{
    public static class PrintHelper
    {
        #region Public Methods

        public static void Print(Element elementToPrint)
        {
            Verbatim.Expression(@"
                    var printPreview = window.open('about:blank', 'print_preview', 'resizable=yes,scrollbars=yes,status=yes');
                    var printDocument = printPreview.document;
                    printDocument.open();
                    printDocument.write('<!DOCTYPE html>'+
                    '<html>'+
                        $0.innerHTML+
                    '</html>');
                    printDocument.close();
                    printPreview.print();", elementToPrint.InnerHtml);
        }

        #endregion Public Methods
    }
}
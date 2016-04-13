using System.Collections.ObjectModel;
using JSIL.Dom;

namespace ExaPhaser.WebForms.Controls
{
    public class ElementGroup : Collection<Element>
    {
        public ElementGroup(Collection<Element> existingCollection) : base(existingCollection)
        {
        }

        public ElementGroup() : base()
        {
        }
    }
}
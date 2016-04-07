using JSIL.Dom;

namespace ExaPhaser.WebForms
{
    public abstract class Control
    {
        private Element _container;

        public Element ContainerElement
        {
            get { return _container; }
            set { _container = value; }
        }
    }
}
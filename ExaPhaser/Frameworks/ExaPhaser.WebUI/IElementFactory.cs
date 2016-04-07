using JSIL.Dom;

namespace ExaPhaser.WebUI
{
    public interface IElementFactory<T>
    {
        Element CreateElement(T item);
    }
}
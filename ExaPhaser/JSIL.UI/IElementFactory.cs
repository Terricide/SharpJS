using JSIL.Dom;

namespace JSIL.UI
{
    public interface IElementFactory<T>
    {
        Element CreateElement(T item);
    }
}
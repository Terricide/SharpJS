namespace System.Xml.Serialization
{
    public interface IXmlSerializable
    {
        void ReadXml(XmlReader reader);
    }
}
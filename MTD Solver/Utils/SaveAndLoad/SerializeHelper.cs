using System.IO;
using System.Xml.Serialization;

namespace MTD_Solver.Utils
{
  public static class SerializeHelper
  {
    public static string SerializeToXmlStr(object obj)
    {
      var serializer = new XmlSerializer(obj.GetType());
      var writer = new StringWriter();
      serializer.Serialize(writer, obj);
      return writer.ToString();
    }

    public static T DeserializeFromXmlStr<T>(string xmlStr)
    {
      var serializer = new XmlSerializer(typeof(T));
      var reader = new StringReader(xmlStr);
      return (T)serializer.Deserialize(reader);
    }
  }
}

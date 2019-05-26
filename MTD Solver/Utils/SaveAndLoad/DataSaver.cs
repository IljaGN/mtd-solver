using MTD_Solver.Configs;
using MTD_Solver.Models;
using System.Xml;

namespace MTD_Solver.Utils
{
  class DataSaver
  {
    private XmlWriterSettings settings;

    public DataSaver()
    {
      settings = new XmlWriterSettings();
      settings.Indent = true;
    }

    public void Save(WindowData data, AppConfig config)
    {
      var property = new Property(config, data);
      string xmlProperty = SerializeHelper.SerializeToXmlStr(property);
      using (var writer = XmlWriter.Create(App.PROPERTY_FILE_NAME, settings))
      {
        var doc = new XmlDocument();
        doc.LoadXml(xmlProperty);
        doc.Save(writer);
      }
    }
  }
}

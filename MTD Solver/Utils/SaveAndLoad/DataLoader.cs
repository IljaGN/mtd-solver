using MTD_Solver.Configs;
using MTD_Solver.Models;
using System.Xml;

namespace MTD_Solver.Utils
{
  class DataLoader
  {
    private WindowData windowData;
    private AppConfig appConfig;

    public void Load()
    {
      Property property = null;
      try
      {
        var doc = new XmlDocument();
        doc.Load(App.PROPERTY_FILE_NAME);
        string xmlProperty = doc.LastChild.OuterXml;
        property = SerializeHelper.DeserializeFromXmlStr<Property>(xmlProperty);
      }
      catch
      {
        property = Property.GetDefault();
      }
      finally
      {
        windowData = property.WindowData;
        appConfig = property.AppConfig;
      }
    }

    public WindowData GetWindowData()
    {
      return windowData;
    }

    public AppConfig GetAppConfig()
    {
      return appConfig;
    }
  }
}

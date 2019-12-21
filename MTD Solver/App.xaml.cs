using MTD_Solver.Configs;
using MTD_Solver.Models;
using MTD_Solver.Utils;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace MTD_Solver
{
  public partial class App : Application
  {
    public const string PROPERTY_FILE_NAME = "Property.xml";
    public static AppConfig AppConfig { get; private set; }
    public static WindowData WindowData { get; private set; }

    static App()
    {
      FrameworkElement.LanguageProperty.OverrideMetadata(
            typeof(FrameworkElement),
            new FrameworkPropertyMetadata(
                XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)
                ));
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
      var loader = new DataLoader();
      loader.Load();
      AppConfig = loader.GetAppConfig();
      WindowData = loader.GetWindowData();
    }

    private void Application_Exit(object sender, ExitEventArgs e)
    {
      var saver = new DataSaver();
      saver.Save(WindowData, AppConfig);
    }
  }
}

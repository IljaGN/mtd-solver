using MTD_Solver.Api;
using MTD_Solver.Configs;
using MTD_Solver.Models;
using MTD_Solver.Utils;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace MTD_Solver.View
{
  public partial class MainWindow : Window
  {
    public List<UiType> ComboBoxOptions => UiType.Get();
    public WindowData WindowData { get; set; }

    public ExchangerIn In { get; set; } = new ExchangerIn();
    public ExchangerOut Out { get; set; } = new ExchangerOut();
    private IHeatExchanger exchanger;
    private IExchangerSettings exchangerSettings;

    public MainWindow()
    {
      var loader = new DataLoader();
      loader.Load();
      WindowData = loader.GetWindowData();
      CreateAndBindExchanger();

      InitializeComponent();
      var assembly = Assembly.GetExecutingAssembly();
      string name = assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
      string version = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
      Title = $"Test Version: {name} {version}";
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      exchanger.Execute();
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      CreateAndBindExchanger();
    }

    private void CreateAndBindExchanger()
    {
      exchanger = ExchangerFactory.Create(WindowData.ExchangerType, exchangerSettings);
      exchanger.BindSourceData(In);
      exchanger.BindResultData(Out);
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      exchangerSettings = WindowData.GetCurrentExchangerSettings();
    }

    private void MainWindow_Closed(object sender, System.EventArgs e)
    {
      var saver = new DataSaver();
      saver.Save(WindowData, new AppConfig());
    }
  }
}

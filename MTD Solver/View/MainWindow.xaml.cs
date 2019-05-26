using MTD_Solver.Api;
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

    public MainWindow()
    {
      InitializeWindowData();
      InitializeComponent();
      var assembly = Assembly.GetExecutingAssembly();
      string name = assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
      string version = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
      Title = $"Test Version: {name} {version}";
    }

    private void InitializeWindowData()
    {
      WindowData = App.WindowData;
      WindowData.InitializeExchangersSettings();
      CreateAndBindExchanger();
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
      IExchangerSettings settings = WindowData.GetCurrentExchangerSettings();
      exchanger = ExchangerFactory.Create(WindowData.ExchangerType, settings);
      exchanger.BindSourceData(In);
      exchanger.BindResultData(Out);
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      CreateAndBindExchanger();
    }
  }
}

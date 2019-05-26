using MTD_Solver.Api;
using MTD_Solver.Models;
using MTD_Solver.Models.Exchangers;
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

    public ExchangerIn In { get; set; }
    public ExchangerOut Out { get; set; }
    private IHeatExchanger exchanger;
    private IExchangerSettings exchangerSettings;

    public MainWindow()
    {
      In = new ExchangerIn();
      Out = new ExchangerOut();
      WindowData = new WindowData();
      CreateExchanger();

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
      CreateExchanger();
    }

    private void CreateExchanger()
    {
      exchanger = ExchangerFactory.Create(WindowData.ExchangerType, exchangerSettings);
      exchanger.BindSourceData(In);
      exchanger.BindResultData(Out);
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      exchangerSettings = WindowData.GetCurrentExchangerSettings();
    }
  }
}

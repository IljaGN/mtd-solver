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
      Title = $"{name} {version}";
    }

    private void InitializeWindowData()
    {
      WindowData = App.WindowData;
      WindowData.InitializeExchangersSettings();
      CreateAndBindExchanger();
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      CreateAndBindExchanger();
      exchanger.Execute();
    }

    private void BtnApply_Click(object sender, RoutedEventArgs e)
    {
      CreateAndBindExchanger();
      exchanger.Execute();
    }

    private void CreateAndBindExchanger()
    {
      IExchangerSettings settings = WindowData.GetCurrentExchangerSettings();
      exchanger = ExchangerFactory.Create(WindowData.ExchangerType, settings);
      exchanger.BindSourceData(In);
      exchanger.BindResultData(Out);
    }

    private void MtdInput_ValueChanged(object sender, RoutedPropertyChangedEventArgs<string> e)
    {
      exchanger.Execute();
    }
  }
}

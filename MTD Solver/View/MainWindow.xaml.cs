using MTD_Solver.Api;
using MTD_Solver.Models;
using MTD_Solver.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace MTD_Solver.View
{
  public partial class MainWindow : Window, INotifyPropertyChanged
  {
    public List<UiType> ComboBoxOptions => UiType.Get();
    public UiType ComboBoxSelected { get; set; }

    public bool IsButtonEnabled => exchanger != null;

    public ExchangerIn In { get; set; }
    public ExchangerOut Out { get; set; }
    private IHeatExchanger exchanger;
    private IExchangerSettings exchangerSettings;

    public MainWindow()
    {
      In = new ExchangerIn();
      Out = new ExchangerOut();

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
      exchanger = ExchangerFactory.Create(ComboBoxSelected.Type, exchangerSettings);
      exchanger.BindSourceData(In);
      exchanger.BindResultData(Out);
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsButtonEnabled)));
    }
    public event PropertyChangedEventHandler PropertyChanged;  //TODO: delete!
  }
}

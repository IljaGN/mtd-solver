using MTD_Solver.Api;
using MTD_Solver.Models;
using MTD_Solver.Utils;
using MTD_Solver.View.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MTD_Solver.View
{
  public partial class MainWindow : Window, INotifyPropertyChanged
  {
    private IHeatExchanger exchanger;
    public ExchangerIn In { get; set; }
    public ExchangerOut Out { get; set; }
    private IExchangerSettings exchangerSettings;

    public List<EcxhangerType> ComboBoxOptions => Exchanger.GetTypes();
    public EcxhangerType ComboBoxSelected { get; set; }

    public bool IsButtonEnabled => exchanger != null;

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

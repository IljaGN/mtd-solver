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

namespace MTD_Solver
{
  public partial class MainWindow : Window
  {
    public ExchangerOut Out { get; set; }
    public List<string> ComboBoxOptions { get; set; }

    public MainWindow()
    {
      Out = new ExchangerOut();
      ComboBoxOptions = Exchanger.GetCaptions();

      InitializeComponent();
      var assembly = Assembly.GetExecutingAssembly();
      string name = assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
      string version = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
      Title = $"Test Version: {name} {version}";
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
    }
  }
}

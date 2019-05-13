using System.Windows;

namespace MTD_Solver.View.Exchangers
{
  public partial class ShellAndTubeSettings : Window
  {
    public int ShellCount { get; set; }

    public ShellAndTubeSettings()
    {
      ShellCount = 1;
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      ((MainWindow)Owner).exchangerSettings = ShellCount;
      Close();
    }
  }
}

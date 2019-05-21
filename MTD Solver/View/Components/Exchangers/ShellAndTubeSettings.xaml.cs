using System.Windows.Controls;

namespace MTD_Solver.View.Components.Exchangers
{
  public partial class ShellAndTubeSettings : UserControl
  {
    public int ShellCount { get; set; }

    public ShellAndTubeSettings()
    {
      ShellCount = 1;
      InitializeComponent();
    }
  }
}

using System.Windows;
using System.Windows.Controls;

namespace MTD_Solver.View.Components.Exchangers
{
  public partial class ShellAndTubeSettings : UserControl
  {
    public int ShellsCount
    {
      get { return (int)GetValue(ShellsCountProperty); }
      set { SetValue(ShellsCountProperty, value); }
    }
    public static readonly DependencyProperty ShellsCountProperty = DependencyProperty.Register(
      nameof(ShellsCount),
      typeof(int),
      typeof(ShellAndTubeSettings),
      new PropertyMetadata(1)
      );

    public ShellAndTubeSettings()
    {
      InitializeComponent();
    }
  }
}

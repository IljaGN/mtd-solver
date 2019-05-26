using MTD_Solver.Models.Exchangers;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MTD_Solver.View.Components.Exchangers
{
  public partial class CrossFlowSettings : UserControl
  {
    public List<UiPassCount> PassCountOptions => UiPassCount.Get();
    public List<UiFluidsBehavior> FluidsBehaviorOptions => UiFluidsBehavior.Get();
    public PassCount PassCountSelected { get; set; }
    public FluidsBehavior FluidsBehaviorSelected { get; set; }

    public CrossFlowSettings()
    {
      InitializeComponent();
    }
  }
}

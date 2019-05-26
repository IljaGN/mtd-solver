using MTD_Solver.Models.Exchangers;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MTD_Solver.View.Components.Exchangers
{
  public partial class CrossFlowSettings : UserControl
  {
    public List<UiPassCount> PassCountOptions => UiPassCount.Get();
    public List<UiFluidsBehavior> FluidsBehaviorOptions => UiFluidsBehavior.Get();

    public PassCount PassCountSelected
    {
      get { return (PassCount)GetValue(PassCountSelectedProperty); }
      set { SetValue(PassCountSelectedProperty, value); }
    }
    public static readonly DependencyProperty PassCountSelectedProperty = DependencyProperty.Register(
      nameof(PassCountSelected),
      typeof(PassCount),
      typeof(CrossFlowSettings),
      new PropertyMetadata(PassCount.ONE)
      );

    public FluidsBehavior FluidsBehaviorSelected
    {
      get { return (FluidsBehavior)GetValue(FluidsBehaviorSelectedProperty); }
      set { SetValue(FluidsBehaviorSelectedProperty, value); }
    }
    public static readonly DependencyProperty FluidsBehaviorSelectedProperty = DependencyProperty.Register(
      nameof(FluidsBehaviorSelected),
      typeof(FluidsBehavior),
      typeof(CrossFlowSettings),
      new PropertyMetadata(FluidsBehavior.ONE_MIXED)
      );

    public CrossFlowSettings()
    {
      InitializeComponent();
    }
  }
}

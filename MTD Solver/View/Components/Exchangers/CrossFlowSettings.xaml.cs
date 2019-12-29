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
    public List<UiShellFluidAcrossTubes> ShellFluidAcrossTubesOptions => UiShellFluidAcrossTubes.Get();

    public PassCount PassCountSelected
    {
      get { return (PassCount)GetValue(PassCountSelectedProperty); }
      set { SetValue(PassCountSelectedProperty, value); }
    }
    public static readonly DependencyProperty PassCountSelectedProperty = DependencyProperty.Register(
      nameof(PassCountSelected),
      typeof(PassCount),
      typeof(CrossFlowSettings),
      new PropertyMetadata(PassCount.ONE, new PropertyChangedCallback(OnPassCountSelectedChanged))
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

    public ShellFluidAcrossTubes ShellFluidAcrossTubesSelected
    {
      get { return (ShellFluidAcrossTubes)GetValue(ShellFluidAcrossTubesSelectedProperty); }
      set { SetValue(ShellFluidAcrossTubesSelectedProperty, value); }
    }
    public static readonly DependencyProperty ShellFluidAcrossTubesSelectedProperty = DependencyProperty.Register(
      nameof(ShellFluidAcrossTubesSelected),
      typeof(ShellFluidAcrossTubes),
      typeof(CrossFlowSettings),
      new PropertyMetadata(ShellFluidAcrossTubes.FIRST)
      );

    public CrossFlowSettings()
    {
      InitializeComponent();
    }

    private static void OnPassCountSelectedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    {
      CrossFlowSettings control = obj as CrossFlowSettings;
      control.OnPassCountSelectedChanged();
    }

    protected virtual void OnPassCountSelectedChanged()
    {
      if (PassCountSelected == PassCount.TWO)
      {
        FluidsBehaviorSelected = FluidsBehavior.ONE_MIXED;
      }
    }
  }
}

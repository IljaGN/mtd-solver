using System.Collections.Generic;
using MTD_Solver.Models.Exchangers;
using MTD_Solver.Properties;
using MTD_Solver.Utils;

namespace MTD_Solver.View.Components.Exchangers
{
  public class UiFluidsBehavior : UiEnum<FluidsBehavior>
  {
    private UiFluidsBehavior(FluidsBehavior type, string caption) : base(type, caption) { }

    public static List<UiFluidsBehavior> Get()
    {
      return new List<UiFluidsBehavior>
      {
        new UiFluidsBehavior(FluidsBehavior.BOTH_UNMIXED, Resources.Unmixed),
        new UiFluidsBehavior(FluidsBehavior.ONE_MIXED, Resources.OneMixed),
        new UiFluidsBehavior(FluidsBehavior.BOTH_MIXED, Resources.BothMixed)
      };
    }
  }
}

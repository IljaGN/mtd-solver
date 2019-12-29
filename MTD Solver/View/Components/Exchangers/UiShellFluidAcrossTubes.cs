using System.Collections.Generic;
using MTD_Solver.Models.Exchangers;
using MTD_Solver.Properties;
using MTD_Solver.Utils;

namespace MTD_Solver.View.Components.Exchangers
{
  public class UiShellFluidAcrossTubes : UiEnum<ShellFluidAcrossTubes>
  {
    private UiShellFluidAcrossTubes(ShellFluidAcrossTubes type, string caption) : base(type, caption) { }

    public static List<UiShellFluidAcrossTubes> Get()
    {
      return new List<UiShellFluidAcrossTubes>
      {
        new UiShellFluidAcrossTubes(ShellFluidAcrossTubes.FIRST, Resources.FirstTubeBundle),
        new UiShellFluidAcrossTubes(ShellFluidAcrossTubes.SECOND, Resources.SecondTubeBundle)
      };
    }
  }
}

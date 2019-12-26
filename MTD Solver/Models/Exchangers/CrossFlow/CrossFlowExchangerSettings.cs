using MTD_Solver.Api;

namespace MTD_Solver.Models.Exchangers
{
  public class CrossFlowExchangerSettings : IExchangerSettings
  {
    public PassCount Pass { get; set; }
    public FluidsBehavior Fluids { get; set; }
    public ShellFluidAcrossTubes FluidAcrossTubes { get; set; }
  }

  public enum PassCount
  {
    ONE,
    TWO
  }

  public enum FluidsBehavior
  {
    BOTH_UNMIXED,
    ONE_MIXED,
    BOTH_MIXED
  }

  public enum ShellFluidAcrossTubes
  {
    FIRST,
    SECOND
  }
}

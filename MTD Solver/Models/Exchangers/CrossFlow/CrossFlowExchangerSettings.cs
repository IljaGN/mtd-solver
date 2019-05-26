using MTD_Solver.Api;

namespace MTD_Solver.Models.Exchangers
{
  public class CrossFlowExchangerSettings : IExchangerSettings
  {
    public PassCount Pass { get; set; }
    public FluidsBehavior Fluids { get; set; }
  }

  public enum PassCount
  {
    ONE,
    TWO
  }

  public enum FluidsBehavior
  {
    UNMIXED,
    ONE_MIXED,
    BOTH_MIXED
  }
}

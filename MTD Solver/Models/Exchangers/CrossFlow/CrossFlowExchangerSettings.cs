using MTD_Solver.Api;

namespace MTD_Solver.Models.Exchangers
{
  public class CrossFlowExchangerSettings : IExchangerSettings
  {
    public PassCount Pass { get; set; } = PassCount.ONE;
    public FluidsBehavior Fluids { get; set; } = FluidsBehavior.ONE_MIXED;
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

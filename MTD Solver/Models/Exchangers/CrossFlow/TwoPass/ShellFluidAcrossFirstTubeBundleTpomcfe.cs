namespace MTD_Solver.Models.Exchangers
{
  class ShellFluidAcrossFirstTubeBundleTpomcfe : TwoPassOneMixedBaseCfe
  {
    protected override double LnValue()
    {
      double numerator = q + p;
      double denominator = q + p * Sqrt(1 - q - p);
      return numerator / denominator;
    }
  }
}

namespace MTD_Solver.Models.Exchangers
{
  class ShellFluidAcrossSecondTubeBundleTpomcfe : TwoPassOneMixedBaseCfe
  {
    protected override double LnValue()
    {
      return p == q
        ? (2D - q) / (2D * (1D - q))
        : (Sqrt(v_D_1_p(q)) - qDp) / (1 - qDp);
    }
  }
}

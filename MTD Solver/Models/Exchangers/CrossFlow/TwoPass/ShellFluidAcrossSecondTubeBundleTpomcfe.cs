namespace MTD_Solver.Models.Exchangers
{
  class ShellFluidAcrossSecondTubeBundleTpomcfe : TwoPassOneMixedBaseCfe
  {
    protected override double LnValue()
    {
      double radical = Sqrt(v_D_1_p(q));
      return (radical - qDp) / (1 - qDp);
    }
  }
}

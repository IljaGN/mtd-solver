namespace MTD_Solver.Models.Exchangers
{
  class SinglePassOneMixedCfe : CrossFlowBaseExchanger
  {
    protected override double r()
    {
      double denominator = 1D - qDp * Ln(v_D_1_p());
      return q / Ln(1D / denominator);
    }
  }
}

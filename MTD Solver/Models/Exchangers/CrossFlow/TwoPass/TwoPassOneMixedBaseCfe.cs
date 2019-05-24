namespace MTD_Solver.Models.Exchangers
{
  abstract class TwoPassOneMixedBaseCfe : CrossFlowBaseExchanger
  {
    protected override double r()
    {
      double denominator = 1D - qDp * Ln(LnValue());
      return q / (2D * Ln(1D / denominator));
    }

    abstract protected double LnValue();
  }
}

namespace MTD_Solver.Models.Exchangers
{
  abstract class CrossFlowBaseExchanger : CompositeBaseExchanger
  {
    protected double q => innerExchangerResult.P;
    protected double p => innerExchangerResult.R * innerExchangerResult.P;
    protected double qDp => 1 / innerExchangerResult.R;
    protected double r0 => (p - q) / Ln(v_D_1_p(q));

    protected double v_D_1_p()
    {
      return v_D_1_p(0);
    }

    protected double v_D_1_p(double value)
    {
      return (1 - value) / (1 - p);
    }

    protected override double DefineCorrectionFactor(ExchangerOut data)
    {
      return r0 / r();
    }

    abstract protected double r();
  }
}

namespace MTD_Solver.Models.Exchangers
{
  abstract class CrossFlowBaseExchanger : CompositeBaseExchanger
  {
    protected double q => innerExchangerResult.P;
    protected double p => innerExchangerResult.R * innerExchangerResult.P;
    protected double qDp => 1D / innerExchangerResult.R;

    protected double v_D_1_p()
    {
      return v_D_1_p(0);
    }

    protected double v_D_1_p(double value)
    {
      return (1D - value) / (1D - p);
    }

    protected override double DefineCorrectionFactor(ExchangerOut data)
    {
      return r() / r0();
    }

    private double r0()
    {
      return p == q
        ? 1D - q
        : (p - q) / Ln(v_D_1_p(q));
    }

    abstract protected double r();
  }
}

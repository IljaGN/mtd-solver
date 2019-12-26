namespace MTD_Solver.Models.Exchangers
{
  class SinglePassBothMixedCfe : CrossFlowBaseExchanger
  {
    protected override double r()
    {
      return r(r0());
    }

    private double r(double initialApproximation)
    {
      double oldR = initialApproximation;
      double newR = ClarifyR(initialApproximation);
      while (Abs(newR - oldR) > 0.001)
      {
        oldR = newR;
        newR = ClarifyR(newR);
      }
      return newR;
    }

    private double ClarifyR(double r)
    {
      double parP = Par(p, r);
      double parQ = Par(q, r);
      double bs = parP + parQ - 1;
      return Pow(bs, -1);
    }

    private double Par(double v, double r)
    {
      double vDr = v / r;
      return vDr / l_e_pow_v(vDr);
    }

    private double l_e_pow_v(double value)
    {
      return 1 - Exp(-value);
    }
  }
}

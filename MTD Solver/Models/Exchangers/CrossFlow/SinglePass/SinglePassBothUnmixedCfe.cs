namespace MTD_Solver.Models.Exchangers
{
  class SinglePassBothUnmixedCfe : CrossFlowBaseExchanger
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
      double pDr = p / r;
      double qDr = q / r;
      double sum = 0D;
      for (int u = 0; u < 3; u++)
      {
        for (int v = 0; v < 4; v++)
        {
          sum += Pow(-1, u + v) * CombinationUV(u, v) * Pow(pDr, u) * Pow(qDr, v);
        }
      }
      return sum;
    }

    private double CombinationUV(int u , int v)
    {
      int upp = u + 1;
      int vpp = v + 1;
      double uf2 = Pow(Factorial(u), 2);
      double vf2 = Pow(Factorial(v), 2);
      double denominator = uf2 * upp * vf2 * vpp;
      return Factorial(u + v) / denominator;
    }
  }
}

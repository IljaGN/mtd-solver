namespace MTD_Solver.Models.Exchangers
{
  class ShellAndTubeExchanger : CompositeBaseExchanger
  {
    private readonly int shellCount;

    public ShellAndTubeExchanger(ShellAndTubeExchangerSettings settings)
    {
      shellCount = settings.ShellCount;
    }

    protected override double DefineCorrectionFactor(ExchangerOut data)
    {
      double P = GetCorrectionP(data);
      double rad_r2_1 = Sqrt(Pow(data.R, 2) + 1D);
      double _2p_1_r = 2D / P - 1D - data.R;
      double numerator = rad_r2_1 * Lg((1D - P) / (1D - P * data.R)) / (data.R - 1D);
      double denominator = Lg((_2p_1_r + rad_r2_1) / (_2p_1_r - rad_r2_1));
      return numerator / denominator;
    }

    private double GetCorrectionP(ExchangerOut data)
    {
      double _1_pr = 1D - data.P * data.R;
      double _1_p = 1D - data.P;
      double quotient = _1_pr / _1_p;
      double radical = Pow(quotient, 1D / shellCount);
      return (radical - 1D) / (radical - data.R);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTD_Solver.Models.Exchangers
{
  class ShellAndTubeExchanger : CompositeBaseExchanger
  {
    public override void Execute()
    {
      base.Execute();
      ExchangerOut pivotData = GetInnerExchangerResult();
      double correctionFactor = GetCorrectionFactor(pivotData);
      result.Update(pivotData.P, pivotData.R, correctionFactor, pivotData.Mtd);
    }

    private double GetCorrectionFactor(ExchangerOut data)
    {
      double P = GetCorrectionP(data);
      double rad_r2_1 = Math.Sqrt(Math.Pow(data.R, 2) + 1);
      double _2p_1_r = 2 / P - 1 - data.R;
      double numerator = rad_r2_1 * Math.Log10((1 - P) / (1 - P * data.R)) / (data.R - 1);
      double denominator = Math.Log10((_2p_1_r + rad_r2_1) / (_2p_1_r - rad_r2_1));
      return numerator / denominator;
    }

    private double GetCorrectionP(ExchangerOut data)
    {
      double _1_pr = 1 - data.P * data.R;
      double _1_p = 1 - data.P;
      double quotient = _1_pr / _1_p;
      double radical = Math.Pow(quotient, 1 / 3);
      return (radical - 1) / (radical - data.R);
    }
  }
}

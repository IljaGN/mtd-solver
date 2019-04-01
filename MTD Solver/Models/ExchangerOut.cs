using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTD_Solver.Models
{
  class ExchangerOut
  {
    public double P { get; private set; }
    public double R { get; private set; }
    public double CorrectionFactor { get; private set; }
    public double Mtd { get; private set; }
    public double CorrectionMtd => Mtd * CorrectionFactor;

    public void Update(double P, double R, double correctionFactor, double mtd)
    {
      this.P = P;
      this.R = R;
      this.CorrectionFactor = correctionFactor;
      this.Mtd = mtd;
    }
  }
}

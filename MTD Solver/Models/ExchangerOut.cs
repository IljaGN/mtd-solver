using MTD_Solver.Api;

namespace MTD_Solver.Models
{
  public class ExchangerOut : NotifyPropertyChangedBase
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

      AllPropertiesChanged();
    }

    private void AllPropertiesChanged()
    {
      foreach (var propertyInfo in GetType().GetProperties())
      {
        OnPropertyChanged(propertyInfo.Name);
      }
    }
  }
}

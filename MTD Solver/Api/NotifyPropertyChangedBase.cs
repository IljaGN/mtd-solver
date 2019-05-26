using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MTD_Solver.Api
{
  public class NotifyPropertyChangedBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string nameProperty = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
    }
  }
}

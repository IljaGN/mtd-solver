using MTD_Solver.Api;
using MTD_Solver.Models.Exchangers;
using System.Collections.Generic;

namespace MTD_Solver.Models
{
  public class WindowData
  {
    public Type ExchangerType { get; set; }
    public ShellAndTubeExchangerSettings ShellAndTubeSettings { get; set; }
    public CrossFlowExchangerSettings CrossFlowSettings { get; set; }

    private Dictionary<Type, IExchangerSettings> exchangersSettings = new Dictionary<Type, IExchangerSettings>();

    public void InitializeExchangersSettings()
    {
      exchangersSettings.Add(Type.SHELL_AND_TUBE, ShellAndTubeSettings);
      exchangersSettings.Add(Type.CROSS_FLOW, CrossFlowSettings);
    }

    public IExchangerSettings GetCurrentExchangerSettings()
    {
      exchangersSettings.TryGetValue(ExchangerType, out IExchangerSettings settings);
      return settings;
    }
  }
}

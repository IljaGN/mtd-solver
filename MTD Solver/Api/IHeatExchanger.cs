using MTD_Solver.Models;

namespace MTD_Solver.Api
{
  interface IHeatExchanger
  {
    void SetSourceData(ExchangerIn data);
    void Execute();
    ExchangerOut GetResult();
  }
}

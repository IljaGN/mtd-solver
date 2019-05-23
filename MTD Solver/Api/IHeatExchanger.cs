using MTD_Solver.Models;

namespace MTD_Solver.Api
{
  interface IHeatExchanger
  {
    void BindSourceData(ExchangerIn data);
    void BindResultData(ExchangerOut data);
    void Execute();
  }
}

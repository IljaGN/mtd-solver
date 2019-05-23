using MTD_Solver.Api;

namespace MTD_Solver.Models.Exchangers
{
  abstract class CompositeBaseExchanger : IHeatExchanger
  {
    private IHeatExchanger exchanger;
    protected ExchangerOut innerExchangerResult;
    protected ExchangerOut result;

    public CompositeBaseExchanger()
    {
      exchanger = new CountercurrentExchanger();
      innerExchangerResult = new ExchangerOut();
      exchanger.BindResultData(innerExchangerResult);
    }

    public void BindSourceData(ExchangerIn data)
    {
      exchanger.BindSourceData(data);
    }

    public void BindResultData(ExchangerOut data)
    {
      result = data;
    }

    public virtual void Execute()
    {
      exchanger.Execute();
    }
  }
}

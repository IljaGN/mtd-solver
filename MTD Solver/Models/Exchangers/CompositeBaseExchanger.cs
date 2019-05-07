using MTD_Solver.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTD_Solver.Models.Exchangers
{
  abstract class CompositeBaseExchanger : IHeatExchanger
  {
    private IHeatExchanger exchanger;
    protected ExchangerOut result;

    public CompositeBaseExchanger()
    {
      exchanger = new CountercurrentExchanger();
      result = new ExchangerOut();
    }

    public void SetSourceData(ExchangerIn data)
    {
      exchanger.SetSourceData(data);
    }

    public virtual void Execute()
    {
      exchanger.Execute();
    }

    public ExchangerOut GetResult()
    {
      return result;
    }

    protected ExchangerOut GetInnerExchangerResult()
    {
      return exchanger.GetResult();
    }
  }
}

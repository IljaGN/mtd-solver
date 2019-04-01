using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTD_Solver.Models.Exchangers
{
  abstract class CompositeBaseExchanger : IHeatExchanger
  {
    private CountercurrentExchanger countercurrent;
    protected ExchangerOut result;

    public CompositeBaseExchanger()
    {
      countercurrent = new CountercurrentExchanger();
      result = new ExchangerOut();
    }

    public void SetSourceData(ExchangerIn data)
    {
      countercurrent.SetSourceData(data);
    }

    public virtual void Execute()
    {
      countercurrent.Execute();
      ExchangerOut pivotData = countercurrent.GetResult();
    }

    public ExchangerOut GetResult()
    {
      return result;
    }

    protected ExchangerOut GetCountercurrentExchangerResult()
    {
      return countercurrent.GetResult();
    }
  }
}

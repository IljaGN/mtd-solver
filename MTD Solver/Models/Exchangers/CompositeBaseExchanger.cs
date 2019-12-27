using System;
using MTD_Solver.Api;
using MTD_Solver.Utils;

namespace MTD_Solver.Models.Exchangers
{
  abstract class CompositeBaseExchanger : IHeatExchanger
  {
    private readonly MathFactorialCalculator mathFactorial;

    private IHeatExchanger exchanger;
    protected ExchangerOut innerExchangerResult;
    protected ExchangerOut result;

    public CompositeBaseExchanger()
    {
      mathFactorial = new MathFactorialCalculator();

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
      ExchangerOut ir = innerExchangerResult;
      result.Update(ir.P, ir.R, DefineCorrectionFactor(ir), ir.Mtd);
    }

    protected double Sqrt(double value)
    {
      return Math.Sqrt(value);
    }

    protected double Lg(double value)
    {
      return Math.Log10(value);
    }

    protected double Ln(double value)
    {
      return Math.Log(value);
    }

    protected double Pow(double _base, double power)
    {
      return Math.Pow(_base, power);
    }

    protected double Exp(double power)
    {
      return Math.Exp(power);
    }

    protected double Abs(double value)
    {
      return Math.Abs(value);
    }

    protected int Factorial(int value)
    {
      return mathFactorial.Calculate(value);
    }

    abstract protected double DefineCorrectionFactor(ExchangerOut data);
  }
}

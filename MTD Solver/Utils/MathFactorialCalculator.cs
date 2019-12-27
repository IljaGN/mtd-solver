using System;

namespace MTD_Solver.Utils
{
  class MathFactorialCalculator
  {
    private const string FACTORIAL_ARG = "Factorial Argument";

    private readonly int[] factorialCalculationTable = new int[13];
    private readonly int minValue;
    private readonly int maxValue;

    public MathFactorialCalculator()
    {
      factorialCalculationTable[0] = 1;
      for (int i = 1; i < factorialCalculationTable.Length; i++)
      {
        factorialCalculationTable[i] = factorialCalculationTable[i - 1] * i;
      }

      minValue = 0;
      maxValue = factorialCalculationTable.Length - 1;
    }

    public int Calculate(int value)
    {
      Validate(value);
      return factorialCalculationTable[value];
    }

    private void Validate(int value)
    {
      if (value < minValue)
      {
        ThrowArgumentException($"Argument value({value}) is less than minimum value({minValue})");
      }

      if (value > maxValue)
      {
        ThrowArgumentException($"Argument value({value}) is greater than maximum value({maxValue})");
      }
    }

    private void ThrowArgumentException(string msg)
    {
      throw new ArgumentException(msg, FACTORIAL_ARG);
    }
  }
}

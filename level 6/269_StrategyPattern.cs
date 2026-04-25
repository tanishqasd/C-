using System;

namespace Level5_DDD
{
    // 269. Strategy Pattern for Business Rules.
    // This allows you to switch business logic at runtime. 
    // E.g., Different tax calculation strategies for different states.

    public interface ITaxStrategy { decimal Calculate(decimal amount); }

    public class MaharashtraTax : ITaxStrategy { public decimal Calculate(decimal amount) => amount * 0.18m; }
    public class GujaratTax : ITaxStrategy { public decimal Calculate(decimal amount) => amount * 0.12m; }

    public class TaxCalculator
    {
        private ITaxStrategy _strategy;
        public void SetStrategy(ITaxStrategy strategy) => _strategy = strategy;
        public decimal GetTotal(decimal amount) => amount + _strategy.Calculate(amount);
    }

    class Program
    {
        static void Main()
        {
            var calc = new TaxCalculator();
            calc.SetStrategy(new MaharashtraTax());
            Console.WriteLine($"Total in Maharashtra: {calc.GetTotal(1000)}");
        }
    }
}
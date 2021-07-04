using System;
using System.Linq;

namespace Liskov_Substitution
{
    public abstract class Calculator
    {
        private readonly int[] _numbers;
        protected Calculator(int[] numbers)
        {
            _numbers = numbers;
        }
        public int[] GetNumbers() => _numbers;
        public abstract int Calculate();
    }
    public class SumCalculator : Calculator
    {
        public SumCalculator(int[] numbers) : base(numbers)
        {
        }
        public override int Calculate() => GetNumbers().Sum();
    }
    public class EvenNumberCalculator : Calculator
    {
        public EvenNumberCalculator(int[] numbers) : base(numbers)
        {
        }
        public override int Calculate() => GetNumbers().Where(x => x % 2 == 0).Sum();
    }


    /*public class SumCalculator
    {
        protected readonly int[] _numbers;

        public SumCalculator(int[] numbers)
        {
            _numbers = numbers;
        }
        public virtual int Calculate() => _numbers.Sum();
    }*/

    /*public class EvenNumbersSumCalculator : SumCalculator
    {
        public EvenNumbersSumCalculator(int[] numbers) : base(numbers)
        {
        }

        public override int Calculate()
        {
            return _numbers.Where(x => x % 2 == 0).Sum();
        }
    }*/

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };
            //upcasting
            Calculator sum = new SumCalculator(numbers);
            Console.WriteLine($"The sum of all the numbers: {sum.Calculate()}");

            Console.WriteLine();

            Calculator evenSum = new EvenNumberCalculator(numbers);
            //upcasting
            Console.WriteLine($"The sum of all the even numbers: {evenSum.Calculate()}");
        }
    }
}

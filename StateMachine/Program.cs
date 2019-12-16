using System;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine
{
    enum State
    {
        AvgCalculator,
        MinCalculator,
        MaxCalculator,
        SumCalculator
    }

    class Calculator
    {
        public Func<int[], double> Calculate;

        private static Func<int[], double> CalculateAvg = (numbers) => numbers.Average();
        private static Func<int[], double> CalculateMin = (numbers) => numbers.Min();
        private static Func<int[], double> CalculateMax = (numbers) => numbers.Max();
        private static Func<int[], double> CalculateSum = (numbers) => numbers.Sum();

        private Dictionary<State, Func<int[], double>> stateDictionary = new Dictionary<State, Func<int[], double>>() 
        {
            { State.AvgCalculator, CalculateAvg },
            { State.MinCalculator, CalculateMin },
            { State.MaxCalculator, CalculateMax },
            { State.SumCalculator, CalculateSum }
        };

        private State state;
        public State State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                Calculate = stateDictionary[state];
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4 };
            var calculator = new Calculator();

            calculator.State = State.SumCalculator;
            Console.WriteLine(calculator.Calculate(numbers));

            calculator.State = State.MinCalculator;
            Console.WriteLine(calculator.Calculate(numbers));

            calculator.State = State.MaxCalculator;
            Console.WriteLine(calculator.Calculate(numbers));

            calculator.State = State.AvgCalculator;
            Console.WriteLine(calculator.Calculate(numbers));
        }
    }
}

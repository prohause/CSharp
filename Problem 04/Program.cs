using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var cups = new Queue<int>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            var bottles = new Stack<int>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var wasted = 0;

            while (cups.Any() && bottles.Any())
            {
                var currentCup = cups.Peek();
                var currentBottle = bottles.Pop();
                if (currentBottle >= currentCup)
                {
                    cups.Dequeue();
                    wasted += currentBottle - currentCup;
                }
                else
                {
                    while (bottles.Any() && currentBottle < currentCup)
                    {
                        currentBottle += bottles.Pop();
                    }

                    if (currentBottle >= currentCup)
                    {
                        cups.Dequeue();
                        wasted += currentBottle - currentCup;
                    }
                }
            }

            Console.WriteLine(bottles.Any()
                ? $"Bottles: {string.Join(" ", bottles)}"
                : $"Cups: {string.Join(" ", cups)}");
            Console.WriteLine($"Wasted litters of water: {wasted}");
        }
    }
}

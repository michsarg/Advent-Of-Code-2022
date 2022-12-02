using System.Linq;
using System.Reflection;
using System.IO;

namespace SolverLibrary
{
    public class Solvers
    {
        public void Solver01A()
        {
            Console.WriteLine("Challenge: 1A");

            string directory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(directory, @"..\..\..\data\01input.txt");
            var lines = File.ReadLines(filePath);

            int currentTotal = 0;
            int highestTotal = 0;

            foreach (var line in lines)
            {
                if (line == "")
                {
                    if (currentTotal > highestTotal) highestTotal = currentTotal;
                    currentTotal = 0;
                    continue;
                }
                else
                {
                    currentTotal += int.Parse(line);
                }
            }
            Console.Write("Highest Total:");
            Console.Write(highestTotal);
        }

        public void Solver01B()
        {
            Console.WriteLine("Challenge: 1B");

            string directory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(directory, @"..\..\..\data\01input.txt");
            var lines = File.ReadLines(filePath);

            int currentTotal = 0;
            List<int> calories = new List<int>();
            foreach (var line in lines)
            {
                if (line == "")
                {
                    calories.Add(currentTotal);
                    currentTotal = 0;
                    continue;
                }
                else
                {
                    currentTotal += int.Parse(line);
                }
            }
            var results = calories.OrderByDescending(num => num);

            int topThreeTotal = 0;
            int count = 0;
            foreach(int value in results)
            {
                if (count < 3)
                {
                    topThreeTotal += value;
                    Console.WriteLine("Top" + (count+1) + ": " + value);
                }
                else break;
                count += 1;
            }

            Console.Write("Total:");
            Console.WriteLine(topThreeTotal);
        }


    }
}
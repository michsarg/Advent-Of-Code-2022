﻿using System.Linq;
using System.Reflection;
using System.IO;
using System.ComponentModel.DataAnnotations;

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
            foreach (int value in results)
            {
                if (count < 3)
                {
                    topThreeTotal += value;
                    Console.WriteLine("Top" + (count + 1) + ": " + value);
                }
                else break;
                count += 1;
            }

            Console.Write("Total:");
            Console.WriteLine(topThreeTotal);
        }

        public void Solver02A()
        {
            Console.WriteLine("Challenge: 2A");

            string directory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(directory, @"..\..\..\data\02input.txt");
            var lines = File.ReadLines(filePath);

            int playerScore = 0;
            int opponentScore = 0;

            int playerTotal = 0;
            int opponentTotal = 0;


            foreach (var line in lines)
            {
                playerScore = 0;
                opponentScore = 0;

                Console.WriteLine(line);

                //hand score
                if (line.Contains('A')) opponentScore += 1; // rock
                if (line.Contains('B')) opponentScore += 2; // paper
                if (line.Contains('C')) opponentScore += 3; // scissors

                if (line.Contains('X')) playerScore += 1; // rock
                if (line.Contains('Y')) playerScore += 2; // paper
                if (line.Contains('Z')) playerScore += 3; // scissors

                // game results
                // if draw
                if (playerScore == opponentScore)
                {
                    playerScore += 3;
                    opponentScore += 3;
                    Console.WriteLine("match");
                }

                // if win
                // rock beats scissors
                if (line.Contains("A Z")) opponentScore += 6;
                if (line.Contains("C X")) playerScore += 6;

                // scissors beats paper
                if (line.Contains("C Y")) opponentScore += 6;
                if (line.Contains("B Z")) playerScore += 6;

                // paper beats rock
                if (line.Contains("B X")) opponentScore += 6;
                if (line.Contains("A Y")) playerScore += 6;

                Console.WriteLine("P" + playerScore);
                Console.WriteLine("O" + opponentScore);

                playerTotal += playerScore;
                opponentTotal += opponentScore;

            }

            Console.WriteLine("playerTotal:" + playerTotal);
            Console.WriteLine("opponentTotal:" + opponentTotal);
        }

        public void Solver02B()
        {
            Console.WriteLine("Challenge: 2B");

            string directory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(directory, @"..\..\..\data\02input.txt");
            var lines = File.ReadLines(filePath);

            int playerScore = 0;
            int opponentScore = 0;

            int playerTotal = 0;
            int opponentTotal = 0;


            foreach (var line in lines)
            {
                playerScore = 0;
                opponentScore = 0;

                Console.WriteLine(line);

                //hand score
                if (line.Contains('A')) opponentScore += 1; // rock
                if (line.Contains('B')) opponentScore += 2; // paper
                if (line.Contains('C')) opponentScore += 3; // scissors

                // player lose, opponent win
                if (line.Contains('X'))
                {
                    opponentScore += 6;
                    if (line.Contains('A')) playerScore += 3;
                    if (line.Contains('B')) playerScore += 1;
                    if (line.Contains('C')) playerScore += 2;

                }

                // draw
                if (line.Contains('Y')) // draw
                {
                    opponentScore += 3;
                    playerScore = opponentScore;

                }

                // player win
                if (line.Contains('Z'))
                {
                    playerScore += 6;
                    if (line.Contains('A')) playerScore += 2;
                    if (line.Contains('B')) playerScore += 3;
                    if (line.Contains('C')) playerScore += 1;

                }


                Console.WriteLine("P" + playerScore);
                Console.WriteLine("O" + opponentScore);

                playerTotal += playerScore;
                opponentTotal += opponentScore;

            }

            Console.WriteLine("playerTotal:" + playerTotal);
            Console.WriteLine("opponentTotal:" + opponentTotal);
        }

        public void Solver03A()
        {
            Console.WriteLine("Challenge: 3A");

            string directory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(directory, @"..\..\..\data\03input.txt");
            var lines = File.ReadLines(filePath);
            int totalPriority = 0;
            foreach (string line in lines )             
            {
                int len = line.Length;
                int halfLen = (line.Length/ 2);
                char[] first = (line.ToCharArray(0, halfLen));
                char[] second = (line.ToCharArray( halfLen, halfLen ));

                foreach (char c in first)
                {
                    if (Array.Exists(second, element => element == c))
                    {
                        Console.Write(c + " ");
                        //convert to value
                        int value = 0;
                        if (Char.IsUpper(c))
                            value = ((int)c) - 38;
                        else 
                            value = ((int)c) - 96;

                        Console.WriteLine(value);
                        totalPriority += value;
                        break;
                    }
                }
            }
            Console.WriteLine("totalPriority: " + totalPriority);

        }

        public void Solver03B()
        {
            Console.WriteLine("Challenge: 3B");

            string directory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(directory, @"..\..\..\data\03input.txt");
            var lines = File.ReadAllLines(filePath);
            int totalPriority = 0;
            int linesLength = File.ReadLines(filePath).Count();

            Console.WriteLine(linesLength);

            for (int i = 0; i<linesLength; i += 3)
            {

                foreach(char c1 in lines[i])
                {
                    if (lines[i + 1].Contains(c1) && lines[i + 2].Contains(c1))
                    {
                        Console.WriteLine(c1);
                        int value = 0;
                        if (Char.IsUpper(c1))
                            value = ((int)c1) - 38;
                        else
                            value = ((int)c1) - 96;

                        Console.WriteLine(value);
                        totalPriority += value;
                        break;
                    }
                }

            }

            Console.WriteLine("totalPriority: " + totalPriority);

        }
    }
}
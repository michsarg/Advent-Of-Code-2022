using System.Linq;
using System.Reflection;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Collections;
using System.Runtime.ExceptionServices;

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
            foreach (string line in lines)
            {
                int len = line.Length;
                int halfLen = (line.Length / 2);
                char[] first = (line.ToCharArray(0, halfLen));
                char[] second = (line.ToCharArray(halfLen, halfLen));

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

            for (int i = 0; i < linesLength; i += 3)
            {

                foreach (char c1 in lines[i])
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

        public void Solver04A()
        {
            Console.WriteLine("Challenge: 4A");

            string directory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(directory, @"..\..\..\data\04input.txt");
            var lines = File.ReadLines(filePath);

            int rangeMatch = 0;

            foreach (var line in lines)
            {
                Console.WriteLine(line);
                char[] delimiters = { ',', '-' };
                string[] numArray = line.Split(delimiters);
                Console.Write(numArray[0] + " ");
                Console.Write(numArray[1] + " ");
                Console.Write(numArray[2] + " ");
                Console.Write(numArray[3] + " ");


                if (
                        (
                        int.Parse(numArray[0]) >= int.Parse(numArray[2]) &&
                        int.Parse(numArray[1]) <= int.Parse(numArray[3])
                        ) ||
                        (
                        int.Parse(numArray[0]) <= int.Parse(numArray[2]) &&
                        int.Parse(numArray[1]) >= int.Parse(numArray[3])
                        )
                    )
                {
                    Console.Write(" rangeMatched");
                    rangeMatch++;
                };

                Console.WriteLine();

            }
            Console.WriteLine("rangeMatch:" + rangeMatch);
        }

        public void Solver04B()
        {
            Console.WriteLine("Challenge: 4B");

            string directory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(directory, @"..\..\..\data\04input.txt");
            var lines = File.ReadLines(filePath);

            int rangeMatch = 0;

            foreach (var line in lines)
            {
                Console.WriteLine(line);
                char[] delimiters = { ',', '-' };
                string[] numArray = line.Split(delimiters);
                Console.Write(numArray[0] + " ");
                Console.Write(numArray[1] + " ");
                Console.Write(numArray[2] + " ");
                Console.Write(numArray[3] + " ");
                Console.WriteLine("");

                if ((
                    int.Parse(numArray[0]) >= int.Parse(numArray[2]) &&
                    int.Parse(numArray[0]) <= int.Parse(numArray[3])
                    ) || (
                    int.Parse(numArray[1]) <= int.Parse(numArray[2]) &&
                    int.Parse(numArray[1]) >= int.Parse(numArray[3])
                    ) || (
                    int.Parse(numArray[2]) >= int.Parse(numArray[0]) &&
                    int.Parse(numArray[2]) <= int.Parse(numArray[1])
                    ) || (
                    int.Parse(numArray[3]) <= int.Parse(numArray[0]) &&
                    int.Parse(numArray[3]) >= int.Parse(numArray[1])
                   ))

                {
                    Console.Write(" rangeMatched");
                    rangeMatch++;
                };

            }
            Console.WriteLine("Matches: " + rangeMatch);
        }

        public void Solver05A()
        {
            Console.WriteLine("Challenge: 5A");

            string directory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(directory, @"..\..\..\data\05input.txt");
            var lines = File.ReadAllLines(filePath);
            int linesLength = File.ReadLines(filePath).Count();

            //Stack<char> stack1 = new Stack<char>();
            //stack1.Push( 'Z');
            //stack1.Push( 'N' );

            //Stack<char> stack2 = new Stack<char>();
            //stack2.Push('M');
            //stack2.Push('C');
            //stack2.Push('D');

            //Stack<char> stack3 = new Stack<char>();
            //stack3.Push('P');

            Stack<char> stack1 = new Stack<char>();
            stack1.Push('P');
            stack1.Push('F');
            stack1.Push('M');
            stack1.Push('Q');
            stack1.Push('W');
            stack1.Push('G');
            stack1.Push('R');
            stack1.Push('T');

            Stack<char> stack2 = new Stack<char>();
            stack2.Push('H');
            stack2.Push('F');
            stack2.Push('R');

            Stack<char> stack3 = new Stack<char>();
            stack3.Push('P');
            stack3.Push('Z');
            stack3.Push('R');
            stack3.Push('V');
            stack3.Push('G');
            stack3.Push('H');
            stack3.Push('S');
            stack3.Push('D');

            Stack<char> stack4 = new Stack<char>();
            stack4.Push('Q');
            stack4.Push('H');
            stack4.Push('P');
            stack4.Push('B');
            stack4.Push('F');
            stack4.Push('W');
            stack4.Push('G');

            Stack<char> stack5 = new Stack<char>();
            stack5.Push('P');
            stack5.Push('S');
            stack5.Push('M');
            stack5.Push('J');
            stack5.Push('H');

            Stack<char> stack6 = new Stack<char>();
            stack6.Push('M');
            stack6.Push('Z');
            stack6.Push('T');
            stack6.Push('H');
            stack6.Push('S');
            stack6.Push('R');
            stack6.Push('P');
            stack6.Push('L');

            Stack<char> stack7 = new Stack<char>();
            stack7.Push('P');
            stack7.Push('T');
            stack7.Push('H');
            stack7.Push('N');
            stack7.Push('M');
            stack7.Push('L');

            Stack<char> stack8 = new Stack<char>();
            stack8.Push('F');
            stack8.Push('D');
            stack8.Push('Q');
            stack8.Push('R');

            Stack<char> stack9 = new Stack<char>();
            stack9.Push('D');
            stack9.Push('S');
            stack9.Push('C');
            stack9.Push('N');
            stack9.Push('L');
            stack9.Push('P');
            stack9.Push('H');



            //interpret moves
            for (int i = 10; i < linesLength; i++)
            {
                Console.WriteLine(lines[i]);

                //get moveCount
                int moveCount = 0;
                if (Char.IsDigit(lines[i][5]))
                {
                    if (Char.IsDigit(lines[i][6]))
                        moveCount = int.Parse(lines[i].Substring(5, 2));
                    else
                        moveCount = int.Parse(lines[i].Substring(5, 1));
                }
                Console.WriteLine("moveCount: " + moveCount);

                //get moveFrom
                int moveFrom = 0;
                if (Char.IsDigit(lines[i][12]))
                    moveFrom = int.Parse(lines[i].Substring(12, 1));
                else if (Char.IsDigit(lines[i][13]))
                    moveFrom = int.Parse(lines[i].Substring(13, 1));
                Console.WriteLine("moveFrom: " + moveFrom);

                //get moveTo
                int moveTo = 0;
                if (Char.IsDigit(lines[i][17]))
                    moveTo = int.Parse(lines[i].Substring(17, 1));
                else if (Char.IsDigit(lines[i][18]))
                    moveTo = int.Parse(lines[i].Substring(18, 1));
                Console.WriteLine("moveTo: " + moveTo);


                //Execute move
                for (int j = 0; j < moveCount; j++)
                {
                    if (moveFrom == 1)
                    {
                        if (moveTo == 2) stack2.Push(stack1.Pop());
                        if (moveTo == 3) stack3.Push(stack1.Pop());
                        if (moveTo == 4) stack4.Push(stack1.Pop());
                        if (moveTo == 5) stack5.Push(stack1.Pop());
                        if (moveTo == 6) stack6.Push(stack1.Pop());
                        if (moveTo == 7) stack7.Push(stack1.Pop());
                        if (moveTo == 8) stack8.Push(stack1.Pop());
                        if (moveTo == 9) stack9.Push(stack1.Pop());
                    }
                    else if (moveFrom == 2)
                    {
                        if (moveTo == 1) stack1.Push(stack2.Pop());
                        if (moveTo == 3) stack3.Push(stack2.Pop());
                        if (moveTo == 4) stack4.Push(stack2.Pop());
                        if (moveTo == 5) stack5.Push(stack2.Pop());
                        if (moveTo == 6) stack6.Push(stack2.Pop());
                        if (moveTo == 7) stack7.Push(stack2.Pop());
                        if (moveTo == 8) stack8.Push(stack2.Pop());
                        if (moveTo == 9) stack9.Push(stack2.Pop());
                    }
                    else if (moveFrom == 3)
                    {
                        if (moveTo == 1) stack1.Push(stack3.Pop());
                        if (moveTo == 2) stack2.Push(stack3.Pop());
                        if (moveTo == 4) stack4.Push(stack3.Pop());
                        if (moveTo == 5) stack5.Push(stack3.Pop());
                        if (moveTo == 6) stack6.Push(stack3.Pop());
                        if (moveTo == 7) stack7.Push(stack3.Pop());
                        if (moveTo == 8) stack8.Push(stack3.Pop());
                        if (moveTo == 9) stack9.Push(stack3.Pop());
                    }
                    else if (moveFrom == 4)
                    {
                        if (moveTo == 1) stack1.Push(stack4.Pop());
                        if (moveTo == 2) stack2.Push(stack4.Pop());
                        if (moveTo == 3) stack3.Push(stack4.Pop());
                        if (moveTo == 5) stack5.Push(stack4.Pop());
                        if (moveTo == 6) stack6.Push(stack4.Pop());
                        if (moveTo == 7) stack7.Push(stack4.Pop());
                        if (moveTo == 8) stack8.Push(stack4.Pop());
                        if (moveTo == 9) stack9.Push(stack4.Pop());
                    }
                    else if (moveFrom == 5)
                    {
                        if (moveTo == 1) stack1.Push(stack5.Pop());
                        if (moveTo == 2) stack2.Push(stack5.Pop());
                        if (moveTo == 3) stack3.Push(stack5.Pop());
                        if (moveTo == 4) stack4.Push(stack5.Pop());
                        if (moveTo == 6) stack6.Push(stack5.Pop());
                        if (moveTo == 7) stack7.Push(stack5.Pop());
                        if (moveTo == 8) stack8.Push(stack5.Pop());
                        if (moveTo == 9) stack9.Push(stack5.Pop());
                    }
                    else if (moveFrom == 6)
                    {
                        if (moveTo == 1) stack1.Push(stack6.Pop());
                        if (moveTo == 2) stack2.Push(stack6.Pop());
                        if (moveTo == 3) stack3.Push(stack6.Pop());
                        if (moveTo == 4) stack4.Push(stack6.Pop());
                        if (moveTo == 5) stack5.Push(stack6.Pop());
                        if (moveTo == 7) stack7.Push(stack6.Pop());
                        if (moveTo == 8) stack8.Push(stack6.Pop());
                        if (moveTo == 9) stack9.Push(stack6.Pop());
                    }
                    else if (moveFrom == 7)
                    {
                        if (moveTo == 1) stack1.Push(stack7.Pop());
                        if (moveTo == 2) stack2.Push(stack7.Pop());
                        if (moveTo == 3) stack3.Push(stack7.Pop());
                        if (moveTo == 4) stack4.Push(stack7.Pop());
                        if (moveTo == 5) stack5.Push(stack7.Pop());
                        if (moveTo == 6) stack6.Push(stack7.Pop());
                        if (moveTo == 8) stack8.Push(stack7.Pop());
                        if (moveTo == 9) stack9.Push(stack7.Pop());
                    }
                    else if (moveFrom == 8)
                    {
                        if (moveTo == 1) stack1.Push(stack8.Pop());
                        if (moveTo == 2) stack2.Push(stack8.Pop());
                        if (moveTo == 3) stack3.Push(stack8.Pop());
                        if (moveTo == 4) stack4.Push(stack8.Pop());
                        if (moveTo == 5) stack5.Push(stack8.Pop());
                        if (moveTo == 6) stack6.Push(stack8.Pop());
                        if (moveTo == 7) stack7.Push(stack8.Pop());
                        if (moveTo == 9) stack9.Push(stack8.Pop());
                    }
                    else if (moveFrom == 9)
                    {
                        if (moveTo == 1) stack1.Push(stack9.Pop());
                        if (moveTo == 2) stack2.Push(stack9.Pop());
                        if (moveTo == 3) stack3.Push(stack9.Pop());
                        if (moveTo == 4) stack4.Push(stack9.Pop());
                        if (moveTo == 5) stack5.Push(stack9.Pop());
                        if (moveTo == 6) stack6.Push(stack9.Pop());
                        if (moveTo == 7) stack7.Push(stack9.Pop());
                        if (moveTo == 8) stack8.Push(stack9.Pop());
                    }
                }


            }


            // result
            Console.Write("Stack1: ");
            foreach (char c in stack1) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack2: ");
            foreach (char c in stack2) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack3: ");
            foreach (char c in stack3) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack4: ");
            foreach (char c in stack4) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack5: ");
            foreach (char c in stack5) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack6: ");
            foreach (char c in stack6) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack7: ");
            foreach (char c in stack7) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack8: ");
            foreach (char c in stack8) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack9: ");
            foreach (char c in stack9) Console.Write(c);
            Console.WriteLine();

        }

        public void Solver05B()
        {
            Console.WriteLine("Challenge: 5B");

            string directory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(directory, @"..\..\..\data\05input.txt");
            var lines = File.ReadAllLines(filePath);
            int linesLength = File.ReadLines(filePath).Count();

            //Stack<char> stack1 = new Stack<char>();
            //stack1.Push('Z');
            //stack1.Push('N');

            //Stack<char> stack2 = new Stack<char>();
            //stack2.Push('M');
            //stack2.Push('C');
            //stack2.Push('D');

            //Stack<char> stack3 = new Stack<char>();
            //stack3.Push('P');

            Stack<char> stack1 = new Stack<char>();
            stack1.Push('P');
            stack1.Push('F');
            stack1.Push('M');
            stack1.Push('Q');
            stack1.Push('W');
            stack1.Push('G');
            stack1.Push('R');
            stack1.Push('T');

            Stack<char> stack2 = new Stack<char>();
            stack2.Push('H');
            stack2.Push('F');
            stack2.Push('R');

            Stack<char> stack3 = new Stack<char>();
            stack3.Push('P');
            stack3.Push('Z');
            stack3.Push('R');
            stack3.Push('V');
            stack3.Push('G');
            stack3.Push('H');
            stack3.Push('S');
            stack3.Push('D');

            Stack<char> stack4 = new Stack<char>();
            stack4.Push('Q');
            stack4.Push('H');
            stack4.Push('P');
            stack4.Push('B');
            stack4.Push('F');
            stack4.Push('W');
            stack4.Push('G');

            Stack<char> stack5 = new Stack<char>();
            stack5.Push('P');
            stack5.Push('S');
            stack5.Push('M');
            stack5.Push('J');
            stack5.Push('H');

            Stack<char> stack6 = new Stack<char>();
            stack6.Push('M');
            stack6.Push('Z');
            stack6.Push('T');
            stack6.Push('H');
            stack6.Push('S');
            stack6.Push('R');
            stack6.Push('P');
            stack6.Push('L');

            Stack<char> stack7 = new Stack<char>();
            stack7.Push('P');
            stack7.Push('T');
            stack7.Push('H');
            stack7.Push('N');
            stack7.Push('M');
            stack7.Push('L');

            Stack<char> stack8 = new Stack<char>();
            stack8.Push('F');
            stack8.Push('D');
            stack8.Push('Q');
            stack8.Push('R');

            Stack<char> stack9 = new Stack<char>();
            stack9.Push('D');
            stack9.Push('S');
            stack9.Push('C');
            stack9.Push('N');
            stack9.Push('L');
            stack9.Push('P');
            stack9.Push('H');



            //interpret moves
            for (int i = 10; i < linesLength; i++)
            {
                Console.WriteLine(lines[i]);

                //get moveCount
                int moveCount = 0;
                if (Char.IsDigit(lines[i][5]))
                {
                    if (Char.IsDigit(lines[i][6]))
                        moveCount = int.Parse(lines[i].Substring(5, 2));
                    else
                        moveCount = int.Parse(lines[i].Substring(5, 1));
                }
                Console.WriteLine("moveCount: " + moveCount);

                //get moveFrom
                int moveFrom = 0;
                if (Char.IsDigit(lines[i][12]))
                    moveFrom = int.Parse(lines[i].Substring(12, 1));
                else if (Char.IsDigit(lines[i][13]))
                    moveFrom = int.Parse(lines[i].Substring(13, 1));
                Console.WriteLine("moveFrom: " + moveFrom);

                //get moveTo
                int moveTo = 0;
                if (Char.IsDigit(lines[i][17]))
                    moveTo = int.Parse(lines[i].Substring(17, 1));
                else if (Char.IsDigit(lines[i][18]))
                    moveTo = int.Parse(lines[i].Substring(18, 1));
                Console.WriteLine("moveTo: " + moveTo);


                //Execute move
                
                Stack <char> stackPlus= new Stack<char>();


            if (moveFrom == 1)
            {
                // pop/push to stackPlus
                for (int k = 0; k < moveCount; k++) stackPlus.Push(stack1.Pop());
                // pop/push to moveTo
                if (moveTo == 2) for (int l = 0; l < moveCount; l++) stack2.Push(stackPlus.Pop());
                if (moveTo == 3) for (int l = 0; l < moveCount; l++) stack3.Push(stackPlus.Pop());
                if (moveTo == 4) for (int l = 0; l < moveCount; l++) stack4.Push(stackPlus.Pop());
                if (moveTo == 5) for (int l = 0; l < moveCount; l++) stack5.Push(stackPlus.Pop());
                if (moveTo == 6) for (int l = 0; l < moveCount; l++) stack6.Push(stackPlus.Pop());
                if (moveTo == 7) for (int l = 0; l < moveCount; l++) stack7.Push(stackPlus.Pop());
                if (moveTo == 8) for (int l = 0; l < moveCount; l++) stack8.Push(stackPlus.Pop());
                if (moveTo == 9) for (int l = 0; l < moveCount; l++) stack9.Push(stackPlus.Pop());
            }
            else if (moveFrom == 2)
            {
                // pop/push to stackPlus
                for (int k = 0; k < moveCount; k++) stackPlus.Push(stack2.Pop());
                // pop/push to moveTo
                if (moveTo == 1) for (int l = 0; l < moveCount; l++) stack1.Push(stackPlus.Pop());
                if (moveTo == 3) for (int l = 0; l < moveCount; l++) stack3.Push(stackPlus.Pop());
                if (moveTo == 4) for (int l = 0; l < moveCount; l++) stack4.Push(stackPlus.Pop());
                if (moveTo == 5) for (int l = 0; l < moveCount; l++) stack5.Push(stackPlus.Pop());
                if (moveTo == 6) for (int l = 0; l < moveCount; l++) stack6.Push(stackPlus.Pop());
                if (moveTo == 7) for (int l = 0; l < moveCount; l++) stack7.Push(stackPlus.Pop());
                if (moveTo == 8) for (int l = 0; l < moveCount; l++) stack8.Push(stackPlus.Pop());
                if (moveTo == 9) for (int l = 0; l < moveCount; l++) stack9.Push(stackPlus.Pop());
            }
            else if (moveFrom == 3)
            {
                // pop/push to stackPlus
                for (int k = 0; k < moveCount; k++) stackPlus.Push(stack3.Pop());
                // pop/push to moveTo
                if (moveTo == 1) for (int l = 0; l < moveCount; l++) stack1.Push(stackPlus.Pop());
                if (moveTo == 2) for (int l = 0; l < moveCount; l++) stack2.Push(stackPlus.Pop());
                if (moveTo == 4) for (int l = 0; l < moveCount; l++) stack4.Push(stackPlus.Pop());
                if (moveTo == 5) for (int l = 0; l < moveCount; l++) stack5.Push(stackPlus.Pop());
                if (moveTo == 6) for (int l = 0; l < moveCount; l++) stack6.Push(stackPlus.Pop());
                if (moveTo == 7) for (int l = 0; l < moveCount; l++) stack7.Push(stackPlus.Pop());
                if (moveTo == 8) for (int l = 0; l < moveCount; l++) stack8.Push(stackPlus.Pop());
                if (moveTo == 9) for (int l = 0; l < moveCount; l++) stack9.Push(stackPlus.Pop());
            }
                else if (moveFrom == 4)
                {
                    // pop/push to stackPlus
                    for (int k = 0; k < moveCount; k++) stackPlus.Push(stack4.Pop());
                    // pop/push to moveTo
                    if (moveTo == 1) for (int l = 0; l < moveCount; l++) stack1.Push(stackPlus.Pop());
                    if (moveTo == 2) for (int l = 0; l < moveCount; l++) stack2.Push(stackPlus.Pop());
                    if (moveTo == 3) for (int l = 0; l < moveCount; l++) stack3.Push(stackPlus.Pop());
                    if (moveTo == 5) for (int l = 0; l < moveCount; l++) stack5.Push(stackPlus.Pop());
                    if (moveTo == 6) for (int l = 0; l < moveCount; l++) stack6.Push(stackPlus.Pop());
                    if (moveTo == 7) for (int l = 0; l < moveCount; l++) stack7.Push(stackPlus.Pop());
                    if (moveTo == 8) for (int l = 0; l < moveCount; l++) stack8.Push(stackPlus.Pop());
                    if (moveTo == 9) for (int l = 0; l < moveCount; l++) stack9.Push(stackPlus.Pop());
                }
                else if (moveFrom == 5)
                {
                    // pop/push to stackPlus
                    for (int k = 0; k < moveCount; k++) stackPlus.Push(stack5.Pop());
                    // pop/push to moveTo
                    if (moveTo == 1) for (int l = 0; l < moveCount; l++) stack1.Push(stackPlus.Pop());
                    if (moveTo == 2) for (int l = 0; l < moveCount; l++) stack2.Push(stackPlus.Pop());
                    if (moveTo == 3) for (int l = 0; l < moveCount; l++) stack3.Push(stackPlus.Pop());
                    if (moveTo == 4) for (int l = 0; l < moveCount; l++) stack4.Push(stackPlus.Pop());
                    if (moveTo == 6) for (int l = 0; l < moveCount; l++) stack6.Push(stackPlus.Pop());
                    if (moveTo == 7) for (int l = 0; l < moveCount; l++) stack7.Push(stackPlus.Pop());
                    if (moveTo == 8) for (int l = 0; l < moveCount; l++) stack8.Push(stackPlus.Pop());
                    if (moveTo == 9) for (int l = 0; l < moveCount; l++) stack9.Push(stackPlus.Pop());
                }
                else if (moveFrom == 6)
                {
                    // pop/push to stackPlus
                    for (int k = 0; k < moveCount; k++) stackPlus.Push(stack6.Pop());
                    // pop/push to moveTo
                    if (moveTo == 1) for (int l = 0; l < moveCount; l++) stack1.Push(stackPlus.Pop());
                    if (moveTo == 2) for (int l = 0; l < moveCount; l++) stack2.Push(stackPlus.Pop());
                    if (moveTo == 3) for (int l = 0; l < moveCount; l++) stack3.Push(stackPlus.Pop());
                    if (moveTo == 4) for (int l = 0; l < moveCount; l++) stack4.Push(stackPlus.Pop());
                    if (moveTo == 5) for (int l = 0; l < moveCount; l++) stack5.Push(stackPlus.Pop());
                    if (moveTo == 7) for (int l = 0; l < moveCount; l++) stack7.Push(stackPlus.Pop());
                    if (moveTo == 8) for (int l = 0; l < moveCount; l++) stack8.Push(stackPlus.Pop());
                    if (moveTo == 9) for (int l = 0; l < moveCount; l++) stack9.Push(stackPlus.Pop());
                }
                else if (moveFrom == 7)
                {
                    // pop/push to stackPlus
                    for (int k = 0; k < moveCount; k++) stackPlus.Push(stack7.Pop());
                    // pop/push to moveTo
                    if (moveTo == 1) for (int l = 0; l < moveCount; l++) stack1.Push(stackPlus.Pop());
                    if (moveTo == 2) for (int l = 0; l < moveCount; l++) stack2.Push(stackPlus.Pop());
                    if (moveTo == 3) for (int l = 0; l < moveCount; l++) stack3.Push(stackPlus.Pop());
                    if (moveTo == 4) for (int l = 0; l < moveCount; l++) stack4.Push(stackPlus.Pop());
                    if (moveTo == 5) for (int l = 0; l < moveCount; l++) stack5.Push(stackPlus.Pop());
                    if (moveTo == 6) for (int l = 0; l < moveCount; l++) stack6.Push(stackPlus.Pop());
                    if (moveTo == 8) for (int l = 0; l < moveCount; l++) stack8.Push(stackPlus.Pop());
                    if (moveTo == 9) for (int l = 0; l < moveCount; l++) stack9.Push(stackPlus.Pop());
                }
                else if (moveFrom == 8)
                {
                    // pop/push to stackPlus
                    for (int k = 0; k < moveCount; k++) stackPlus.Push(stack8.Pop());
                    // pop/push to moveTo
                    if (moveTo == 1) for (int l = 0; l < moveCount; l++) stack1.Push(stackPlus.Pop());
                    if (moveTo == 2) for (int l = 0; l < moveCount; l++) stack2.Push(stackPlus.Pop());
                    if (moveTo == 3) for (int l = 0; l < moveCount; l++) stack3.Push(stackPlus.Pop());
                    if (moveTo == 4) for (int l = 0; l < moveCount; l++) stack4.Push(stackPlus.Pop());
                    if (moveTo == 5) for (int l = 0; l < moveCount; l++) stack5.Push(stackPlus.Pop());
                    if (moveTo == 6) for (int l = 0; l < moveCount; l++) stack6.Push(stackPlus.Pop());
                    if (moveTo == 7) for (int l = 0; l < moveCount; l++) stack7.Push(stackPlus.Pop());
                    if (moveTo == 9) for (int l = 0; l < moveCount; l++) stack9.Push(stackPlus.Pop());
                }
                else if (moveFrom == 9)
                {
                    // pop/push to stackPlus
                    for (int k = 0; k < moveCount; k++) stackPlus.Push(stack9.Pop());
                    // pop/push to moveTo
                    if (moveTo == 1) for (int l = 0; l < moveCount; l++) stack1.Push(stackPlus.Pop());
                    if (moveTo == 2) for (int l = 0; l < moveCount; l++) stack2.Push(stackPlus.Pop());
                    if (moveTo == 3) for (int l = 0; l < moveCount; l++) stack3.Push(stackPlus.Pop());
                    if (moveTo == 4) for (int l = 0; l < moveCount; l++) stack4.Push(stackPlus.Pop());
                    if (moveTo == 5) for (int l = 0; l < moveCount; l++) stack5.Push(stackPlus.Pop());
                    if (moveTo == 6) for (int l = 0; l < moveCount; l++) stack6.Push(stackPlus.Pop());
                    if (moveTo == 7) for (int l = 0; l < moveCount; l++) stack7.Push(stackPlus.Pop());
                    if (moveTo == 8) for (int l = 0; l < moveCount; l++) stack8.Push(stackPlus.Pop());
                }


            }


            // result
            Console.Write("Stack1: ");
            foreach (char c in stack1) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack2: ");
            foreach (char c in stack2) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack3: ");
            foreach (char c in stack3) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack4: ");
            foreach (char c in stack4) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack5: ");
            foreach (char c in stack5) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack6: ");
            foreach (char c in stack6) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack7: ");
            foreach (char c in stack7) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack8: ");
            foreach (char c in stack8) Console.Write(c);
            Console.WriteLine();

            Console.Write("Stack9: ");
            foreach (char c in stack9) Console.Write(c);
            Console.WriteLine();

        }

        public void Solver06A()
        {
            Console.WriteLine("Challenge: 6A");

            String input = "hjchjcjhjshjsssrfsrrldrddbrrzfzjzzrffvwwclwlffhwhwpwfffcbctbccchmccfmmwdmmdwwdttwffsfshswhhfchfchcphpnnflnlznlnnnvpnnhjhrrjgrglgwwrgghzhnzztlltbtwbbvmmzppdmmhchnccspccvmvwwzpwzzmddjmdmbdmmrzmmhlhhhdndllrlgrllmlhljlmmgdmggwdggffblbmmdgdwgdgwgvgcgtctjjnfnsffbqbwbnnsbbqsswggncgncntccqqfmmlqllllvrvlrlgldlggjvvqdvqvzvzpzrrvfvcfcqfcflfjfjrrwbrrpnrrvzzbddfdgfdgfddppbdbbjddtcdtccllvccjtctmccsttfcfppmvppbvpvjpvprvvmggjffbqbbqhbbcdbdrbrjrllgmggwdwzddzdczddgpgglgpgqgmgllrqlqmlqllmbmzmdzdbzddqbbzwwjfjqqlrrzgrrlzzdczddlflpfpqfqrqzzpdzdnznwwvjjnndldpdppfgppgwwnddmzzmffvgggphpbpnbblqbqccswwlcwlltvvlggqvqhvvtstmssbvvflvvhdhggqpgqgqlqggjvjpphhqnhqhvqhvqvpvvfvqfqvvbmbtmmqpqccwcbbqwbbmjbjsscsqqcccbjbvvmsmrmwrwwbhwwdpwphprptrrdssrprjrdrssqtqzqtzzcbbvrrpwrwlwbbpwwrddfcfccvttdsshqhqddsmslsffdsdrrswsmmztzhzghgqhqbbfcctmcmmdwwpbpdbbnjbnbmnmqqqftfdfnfzfqzffmmnqqgfgwwntnwwfsfmssnzzscsmmzttdwttfppnccngggmrmbmccrbcrclcslsfspfsswnwpwjwddbnbjbrjbrjbrjbrrlgljggcpgptpltlmlnnjpnptnppdcdwcwfcwcnnzddbrrnbnnsjsnjjjsqjjqhjjbrjbbghbgggsdshswsrwwqbwqqmtqmqdmdttwfwzztwztwtfwtwtfwwjpwjjljcccdbdndmmhjhzzszfssgbbwbhhhrhfrhhwttwltwtbwbrbqbpbwwjtwwdjjwhwmmddhgdhhhdrhrjjngjgnjnfjnjrjtrrhmmjzzsjzjhjmmvnmnqqzbbtnncffnhnhgnhggcssvrrwfwjwgjwwwdtwddgrrwnwffndnbdnbnsnbsnndtdvvdtdsdhshcczqzztzfzdzndnnhqqzggwrwtrtvtjvjvsjjzhzggtffdbbzwbbnwwnhnpnznfncnqqvmvbmbcbgcgfggtpggjqggnppwmwzzqpzzvvgqqjjhrrmmfsfvvbqvbqqptpztpzzhnndgngdngdngnllslhhsvssdffwllchlccjpjdpddgcgrgttmqttjlttphhdwdtdtnnrggmhhmhmgghnhbhppfmmlrmmlqqsllwswpsshbbfjjqvvlsvvblbljltjtjsszcscmsmgmddzsdddznnvvddwbwjwwmqwqlqvqffptfpttgngpgttlglpgppssthshwhzhshfshssstppbpjjtgjttlsszmzccrllwjjcdccgmccdppnlnrlltntcnttrhtrtqqfhhjfffldfdldbbqjqzzqjzzfhhtvvrrfqfsqfftrtbblmlsltsszqqcsshllvlbbpgpzgpgcppwnpwnwpnnjjmllrhllfzlzglzlnlrrcssjjjtgjgjjznjnmmjjpccqrqzrzzmfzfczcssnttddfjdfjfpjjmqjqnqtqbqzzqqzwwzwqqfccvcrvrqrlqrlqqnvjtqswzvngfcjpmnrnvnwtwnjvsmzhtwzpjbpglchwfvwhvznsvhvwwjppmqqpcpmzrznqrlvbgdfcpgdtfhwdclvzjqlhtbdvsgpjlrgbcjblnqhffbcjfwsgssfzlsbhrptfgsfsstzbwqcsrpgftblrnldhwfwpgpffftsjgclzqmjmcvwjrsbhgdblswrwnhpjtgsggmnjqgzzctjjztwhcqvhqfvddljjtqwgpmwdsmmhdttvdpqpvsqbpwmtzgfthtmfhmplmwqcbmdmrwqmmzmjmfdbqspmshlhtbmbcpcjsgdccwmbfwvftlshtrgzvbndqvqjzqgbgrnmzbwfgntfphjrvhrgzgdqclvpvwffghthlqwlghfqrwpdmgnthqwznqsjrnnpghfcfwctpvnbnftczlhmdslfvqprhgqmzmzsjvtzfsfzlcrltjhfgmwqcvnzmttfvvbsjslqfwmnhgbbjdwfgbzsjqfsgvphvmclfgtmcvlpslpqfsbzgccqslmrgdwrtlrzbbvrjrnnnncgrnsggzjrfqtmhjdvdfbwdmqrjbghrbnhpqcdzgbqwrvrcpwdlbvrdpfhnpbncjzgmftjhvwnplmnlfnlfjsjnqhtgqldzqlrlqtdjndjpsfdcdfrwtqblzpsqjvnqchdhwvswrmczhsbpfggsvzdznqjlrjjbcjnsjvqtrtttmmcgdwbqcthqvzffjmdbvjmjvcrmnpjgtjshbnlqpdfdnbcfmbrzsvqftrnfzmjdhpprpnwqbngmbbwjvmdzbwvttncdtgqnwwchmbbdtrwlflmqnbthnczfpmtpfpqpbwbcpsplgfpjfptdpvzjnbgzrfdwpdrztqtsrzmbfqhgwnfzcsbdsjsmbdghjcjlvbpjpplgqqnbqpqgsqqbmpgmlghrlbcfzjhlqfgdpfljspwqjbsjqzwwhrcpfrhwpvgrjpqjzfzphcrwbfwsjdsjtlwctsfhrmbnvsrfwwvgqtjtjvvqzjznlrsblgthjfrphsfmbtpmbthwdhrqbdmbzplbvpbcwvhgrsjccsnhbrqdbljzpdttbffqrbmgmzsmhdhsmnnmjqtwdjpmhlpwtwhvbfnjzfcwfzfplsbqgcvwgjcbwzbzmqdchwrggjwgjbttsttsztrftttqpslwvtcrjmdtwdhlwnhpjstqnqtvrmlmtcgjljzrthgpmvdjzlwfntqmbpdpgmmvvwqmdqqwrnlsrmhrpdtmhjrngwdfgddlrmdnfdnscjhdfjzwljjrsclnfdmhpbsvwtsmrdsvmpbjjpmmgtfclcccmcnzcslsvdwncrgtpvgbcgwdmcqlthgmrqmpnprlsqgzzpzzmhgflfgpjwgjjdpvggmhcstrwscqggqgrrjwtqzdfbnwgtvslvghfnzphbznqslcwwcsplgwjnltrttqzcvjhfdrwgjpclzmqfgvhzhrcdsgchhfqptqjwffmrsjrplzzlhnptwlmrvtstsrgnfdnrbtdbzjdcbthhtnjdprrpgtgfjsqnpgslcqgmdfpsrdfvhbqvvpthmmshpdnrrwlfcmqfbrsvqdqhffgbdhwjgcjsclcqpwnrfzfdqcvnmqnjmjnvhqmznmbnbnnjfrtlvbpdgglqpgcmqqcnpzfvvsnchpbjprpnwbdqvqzgjvgtnsrvswfmwhzllmlgpsglssnhcvbjtfghhrznpzntwwtnshmhhddnntdljhhhpmnchssqthbzpqmtmjbcfvmgnmwhpzrbwzzvzmnfdcsbvzphlglbhjpfmrtgfblhtszqvbbmtglwdhgjdvvgtpscgvwzjppfnlndnmtrnnnlfbgmrpqlvhvbgzmwghnsmdmdrftqpqncsbcmqhhhljzlwcrlsdbhrlddwlhcghvttjfsmfdzcllswjgsmcmghbflbdgpwfqplqnrvzfnctdsnmldhtbtpfrsztjdsgmnbrdjwbrgqlhdrlrnmlpwltgpwhwztbwpcqtwbqdmsfdfczftncvsggshhcqbjgcwjljcqdpczrnzbjhrhwcgrbbqzmmfjpqwrwppmnvcsfwprjqvtnzqzwtwlvvqssfjzbrvjjrmphtbjbrzttmvvhdfsnqdmpfbtprbqgzdgtjtpvbqqsgppsrnvsfnmgvbbsjcpttffthpvfjpnzmsjmpdzbldggtjrjqpshtmgpfgtcstdrgjhzjr\r\n";
            int markerSize = 4;

            // cycle through the chars starting from markerSize
            for(int i = markerSize; i<input.Length; i++)
            {
                //Console.WriteLine("input[" + i + "]: " + input[i]);

                // for current i, check for matches to previous chars
                List<char> charList = new List<char>();
                for (int j = 0; j<markerSize; j++)
                {
                    charList.Add(input[i-j]);
                }

                if(charList.Count() == charList.Distinct().Count())
                {
                    Console.Write("All distinct at position: ");
                    Console.WriteLine(i + 1);
                    break;
                }

            }
        }

        public void Solver06B()
        {
            Console.WriteLine("Challenge: 6B");

            String input = "hjchjcjhjshjsssrfsrrldrddbrrzfzjzzrffvwwclwlffhwhwpwfffcbctbccchmccfmmwdmmdwwdttwffsfshswhhfchfchcphpnnflnlznlnnnvpnnhjhrrjgrglgwwrgghzhnzztlltbtwbbvmmzppdmmhchnccspccvmvwwzpwzzmddjmdmbdmmrzmmhlhhhdndllrlgrllmlhljlmmgdmggwdggffblbmmdgdwgdgwgvgcgtctjjnfnsffbqbwbnnsbbqsswggncgncntccqqfmmlqllllvrvlrlgldlggjvvqdvqvzvzpzrrvfvcfcqfcflfjfjrrwbrrpnrrvzzbddfdgfdgfddppbdbbjddtcdtccllvccjtctmccsttfcfppmvppbvpvjpvprvvmggjffbqbbqhbbcdbdrbrjrllgmggwdwzddzdczddgpgglgpgqgmgllrqlqmlqllmbmzmdzdbzddqbbzwwjfjqqlrrzgrrlzzdczddlflpfpqfqrqzzpdzdnznwwvjjnndldpdppfgppgwwnddmzzmffvgggphpbpnbblqbqccswwlcwlltvvlggqvqhvvtstmssbvvflvvhdhggqpgqgqlqggjvjpphhqnhqhvqhvqvpvvfvqfqvvbmbtmmqpqccwcbbqwbbmjbjsscsqqcccbjbvvmsmrmwrwwbhwwdpwphprptrrdssrprjrdrssqtqzqtzzcbbvrrpwrwlwbbpwwrddfcfccvttdsshqhqddsmslsffdsdrrswsmmztzhzghgqhqbbfcctmcmmdwwpbpdbbnjbnbmnmqqqftfdfnfzfqzffmmnqqgfgwwntnwwfsfmssnzzscsmmzttdwttfppnccngggmrmbmccrbcrclcslsfspfsswnwpwjwddbnbjbrjbrjbrjbrrlgljggcpgptpltlmlnnjpnptnppdcdwcwfcwcnnzddbrrnbnnsjsnjjjsqjjqhjjbrjbbghbgggsdshswsrwwqbwqqmtqmqdmdttwfwzztwztwtfwtwtfwwjpwjjljcccdbdndmmhjhzzszfssgbbwbhhhrhfrhhwttwltwtbwbrbqbpbwwjtwwdjjwhwmmddhgdhhhdrhrjjngjgnjnfjnjrjtrrhmmjzzsjzjhjmmvnmnqqzbbtnncffnhnhgnhggcssvrrwfwjwgjwwwdtwddgrrwnwffndnbdnbnsnbsnndtdvvdtdsdhshcczqzztzfzdzndnnhqqzggwrwtrtvtjvjvsjjzhzggtffdbbzwbbnwwnhnpnznfncnqqvmvbmbcbgcgfggtpggjqggnppwmwzzqpzzvvgqqjjhrrmmfsfvvbqvbqqptpztpzzhnndgngdngdngnllslhhsvssdffwllchlccjpjdpddgcgrgttmqttjlttphhdwdtdtnnrggmhhmhmgghnhbhppfmmlrmmlqqsllwswpsshbbfjjqvvlsvvblbljltjtjsszcscmsmgmddzsdddznnvvddwbwjwwmqwqlqvqffptfpttgngpgttlglpgppssthshwhzhshfshssstppbpjjtgjttlsszmzccrllwjjcdccgmccdppnlnrlltntcnttrhtrtqqfhhjfffldfdldbbqjqzzqjzzfhhtvvrrfqfsqfftrtbblmlsltsszqqcsshllvlbbpgpzgpgcppwnpwnwpnnjjmllrhllfzlzglzlnlrrcssjjjtgjgjjznjnmmjjpccqrqzrzzmfzfczcssnttddfjdfjfpjjmqjqnqtqbqzzqqzwwzwqqfccvcrvrqrlqrlqqnvjtqswzvngfcjpmnrnvnwtwnjvsmzhtwzpjbpglchwfvwhvznsvhvwwjppmqqpcpmzrznqrlvbgdfcpgdtfhwdclvzjqlhtbdvsgpjlrgbcjblnqhffbcjfwsgssfzlsbhrptfgsfsstzbwqcsrpgftblrnldhwfwpgpffftsjgclzqmjmcvwjrsbhgdblswrwnhpjtgsggmnjqgzzctjjztwhcqvhqfvddljjtqwgpmwdsmmhdttvdpqpvsqbpwmtzgfthtmfhmplmwqcbmdmrwqmmzmjmfdbqspmshlhtbmbcpcjsgdccwmbfwvftlshtrgzvbndqvqjzqgbgrnmzbwfgntfphjrvhrgzgdqclvpvwffghthlqwlghfqrwpdmgnthqwznqsjrnnpghfcfwctpvnbnftczlhmdslfvqprhgqmzmzsjvtzfsfzlcrltjhfgmwqcvnzmttfvvbsjslqfwmnhgbbjdwfgbzsjqfsgvphvmclfgtmcvlpslpqfsbzgccqslmrgdwrtlrzbbvrjrnnnncgrnsggzjrfqtmhjdvdfbwdmqrjbghrbnhpqcdzgbqwrvrcpwdlbvrdpfhnpbncjzgmftjhvwnplmnlfnlfjsjnqhtgqldzqlrlqtdjndjpsfdcdfrwtqblzpsqjvnqchdhwvswrmczhsbpfggsvzdznqjlrjjbcjnsjvqtrtttmmcgdwbqcthqvzffjmdbvjmjvcrmnpjgtjshbnlqpdfdnbcfmbrzsvqftrnfzmjdhpprpnwqbngmbbwjvmdzbwvttncdtgqnwwchmbbdtrwlflmqnbthnczfpmtpfpqpbwbcpsplgfpjfptdpvzjnbgzrfdwpdrztqtsrzmbfqhgwnfzcsbdsjsmbdghjcjlvbpjpplgqqnbqpqgsqqbmpgmlghrlbcfzjhlqfgdpfljspwqjbsjqzwwhrcpfrhwpvgrjpqjzfzphcrwbfwsjdsjtlwctsfhrmbnvsrfwwvgqtjtjvvqzjznlrsblgthjfrphsfmbtpmbthwdhrqbdmbzplbvpbcwvhgrsjccsnhbrqdbljzpdttbffqrbmgmzsmhdhsmnnmjqtwdjpmhlpwtwhvbfnjzfcwfzfplsbqgcvwgjcbwzbzmqdchwrggjwgjbttsttsztrftttqpslwvtcrjmdtwdhlwnhpjstqnqtvrmlmtcgjljzrthgpmvdjzlwfntqmbpdpgmmvvwqmdqqwrnlsrmhrpdtmhjrngwdfgddlrmdnfdnscjhdfjzwljjrsclnfdmhpbsvwtsmrdsvmpbjjpmmgtfclcccmcnzcslsvdwncrgtpvgbcgwdmcqlthgmrqmpnprlsqgzzpzzmhgflfgpjwgjjdpvggmhcstrwscqggqgrrjwtqzdfbnwgtvslvghfnzphbznqslcwwcsplgwjnltrttqzcvjhfdrwgjpclzmqfgvhzhrcdsgchhfqptqjwffmrsjrplzzlhnptwlmrvtstsrgnfdnrbtdbzjdcbthhtnjdprrpgtgfjsqnpgslcqgmdfpsrdfvhbqvvpthmmshpdnrrwlfcmqfbrsvqdqhffgbdhwjgcjsclcqpwnrfzfdqcvnmqnjmjnvhqmznmbnbnnjfrtlvbpdgglqpgcmqqcnpzfvvsnchpbjprpnwbdqvqzgjvgtnsrvswfmwhzllmlgpsglssnhcvbjtfghhrznpzntwwtnshmhhddnntdljhhhpmnchssqthbzpqmtmjbcfvmgnmwhpzrbwzzvzmnfdcsbvzphlglbhjpfmrtgfblhtszqvbbmtglwdhgjdvvgtpscgvwzjppfnlndnmtrnnnlfbgmrpqlvhvbgzmwghnsmdmdrftqpqncsbcmqhhhljzlwcrlsdbhrlddwlhcghvttjfsmfdzcllswjgsmcmghbflbdgpwfqplqnrvzfnctdsnmldhtbtpfrsztjdsgmnbrdjwbrgqlhdrlrnmlpwltgpwhwztbwpcqtwbqdmsfdfczftncvsggshhcqbjgcwjljcqdpczrnzbjhrhwcgrbbqzmmfjpqwrwppmnvcsfwprjqvtnzqzwtwlvvqssfjzbrvjjrmphtbjbrzttmvvhdfsnqdmpfbtprbqgzdgtjtpvbqqsgppsrnvsfnmgvbbsjcpttffthpvfjpnzmsjmpdzbldggtjrjqpshtmgpfgtcstdrgjhzjr";
            int markerSize = 14;

            // cycle through the chars starting from markerSize
            for (int i = markerSize; i < input.Length; i++)
            {
                //Console.WriteLine("input[" + i + "]: " + input[i]);

                // for current i, check for matches to previous chars
                List<char> charList = new List<char>();
                for (int j = 0; j < markerSize; j++)
                {
                    charList.Add(input[i - j]);
                }

                if (charList.Count() == charList.Distinct().Count())
                {
                    Console.Write("All distinct at position: ");
                    Console.WriteLine(i + 1);
                    break;
                }

            }
        }

    }
}
using Ovning4_SkalProj;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics; // Add this namespace for BigInteger


namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        static void Main()
        {
            MemoryManagement mm = new MemoryManagement();
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3, 4, 5, 6, 7, 8, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. Check Parenthesis"
                    + "\n5. Iterative Fibonacci"
                    + "\n6. Recursive Fibonacci"
                    + "\n7. Iterative Factorial"
                    + "\n8. Recursive Factorial"
                    + "\n0. Exit the application");

                char input = ' ';
                try
                {
                    input = Console.ReadLine()![0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                
                switch (input)
                {
                    case '1':
                        //mm.ExamineList();
                        ExamineList();
                       
                        break;
                    case '2':
                        //mm.ExamineQueue();
                        ExamineQueue();
                        break;
                    //case '3':
                    //   mm.ExamineQueue();
                    //   ExamineStack();
                    //    break;
                    case '3':
                        //mm.ReverseText();
                        ReverseText();
                        break;
                    case '4':
                        //mm.CheckParentheses();
                        CheckParenthesis();
                        break;
                    case '5':
                        IterativeFibonacci();
                        break;
                    case '6':
                        RecursiveFibonacci();
                        break;
                    case '7':
                        IterativeFactorial();
                        break;
                    case '8':
                        RecursiveFactorial();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input (0, 1, 2, 3, 4, 5, 6, 7, 8)");
                        break;
                }
            }
        }

        static void ExamineList()
        {
            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine("Enter +<item> to add, -<item> to remove or 'exit' to return to main menu:");
                string input = Console.ReadLine();
                if (input == "exit") break;

                char operation = input[0];
                string value = input.Substring(1).Trim();

                switch (operation)
                {
                    case '+':
                        if (!theList.Contains(value))
                        {
                            theList.Add(value);
                            Console.WriteLine($"Added: {value}");
                        }
                        else
                        {
                            Console.WriteLine($"Item '{value}' is already in the list.");
                        }
                        break;
                    case '-':
                        if (theList.Contains(value))
                        {
                            theList.Remove(value);
                            Console.WriteLine($"Removed: {value}");
                        }
                        else
                        {
                            Console.WriteLine($"Item '{value}' not found in the list.");
                        }
                        break;
                    default:
                        Console.WriteLine("Please use + to add or - to remove items.");
                        break;
                }

                Console.WriteLine($"List: {string.Join(", ", theList)}");
                Console.WriteLine($"Number of elements in the list: {theList.Count}");
                Console.WriteLine($"Capacity: {theList.Capacity}");
            }
        }

        static void ExamineQueue()
        {
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                Console.WriteLine("\nChoose an action: \n1. Add a person to the queue (+[Name]) \n2. Remove a person from the queue (-) \n3. Exit (exit)");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                if (input.StartsWith("+"))
                {
                    string person = input.Substring(1);
                    queue.Enqueue(person);  // Enqueue adds a person to the queue
                    Console.WriteLine($"{person} has joined the queue.");
                }
                else if (input == "-")
                {
                    if (queue.Count > 0)
                    {
                        string person = queue.Dequeue();  // Dequeue removes the person at the front
                        Console.WriteLine($"{person} has been served and left the queue.");
                    }
                    else
                    {
                        Console.WriteLine("The queue is empty. No one to serve.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Use +[Name] to add and - to remove.");
                }

                // Display the current state of the queue
                Console.WriteLine("Current queue: " + string.Join(", ", queue));
            }
        }

        static void ExamineStack()
        {
            Stack<string> theStack = new Stack<string>();

            while (true)
            {
                Console.WriteLine("Enter +<item> to push or 'exit' to return to main menu:");
                string input = Console.ReadLine();
                if (input == "exit") break;

                char operation = input[0];
                string value = input.Substring(1).Trim();

                if (operation == '+')
                {
                    if (!theStack.Contains(value))
                    {
                        theStack.Push(value);
                        Console.WriteLine($"Pushed: {value}");
                    }
                    else
                    {
                        Console.WriteLine($"Item '{value}' is already in the stack.");
                    }
                }
                else
                {
                    Console.WriteLine("Please use + to push items.");
                }

                Console.WriteLine($"Stack: {string.Join(", ", theStack)}");
            }
        }

        static void ReverseText()
        {
            Console.WriteLine("Enter a string to reverse:");
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                stack.Push(c);
            }

            Console.WriteLine("Reversed string:");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }

        static void CheckParenthesis()
        {
            Console.WriteLine("Enter a string with parentheses to check if it's balanced:");
            string input = Console.ReadLine();

            if (IsBalanced(input))
            {
                Console.WriteLine("The parentheses are balanced.");
            }
            else
            {
                Console.WriteLine("The parentheses are not balanced.");
            }
        }

        static bool IsBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char ch in input)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(ch);
                }
                else if (ch == ')' || ch == '}' || ch == ']')
                {
                    if (stack.Count == 0) return false;
                    char open = stack.Pop();
                    if (!Matches(open, ch)) return false;
                }
            }
            return stack.Count == 0;
        }

        static bool Matches(char open, char close)
        {
            return (open == '(' && close == ')') ||
                   (open == '{' && close == '}') ||
                   (open == '[' && close == ']');
        }

        // Exercise 5: Iterative Fibonacci
        static void IterativeFibonacci()
        {
            Console.WriteLine("Enter a number to calculate the nth Fibonacci iteratively:");
            int n = int.Parse(Console.ReadLine());

            int a = 0, b = 1, next;
            for (int i = 2; i <= n; i++)
            {
                next = a + b;
                a = b;
                b = next;
            }

            Console.WriteLine($"Fibonacci number at position {n} is: {b}");
        }

        // Exercise 6: Recursive Fibonacci
        static void RecursiveFibonacci()
        {
            Console.WriteLine("Enter a number to calculate the nth Fibonacci recursively:");
            int n = int.Parse(Console.ReadLine());
            int result = Fibonacci(n);
            Console.WriteLine($"Fibonacci number at position {n} is: {result}");
        }

        static int Fibonacci(int n)
        {
            if (n <= 1) return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        // Exercise 7: Iterative Factorial
        static void IterativeFactorial()
        {
            Console.WriteLine("Enter a number to calculate the factorial iteratively:");
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = 1; 
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine($"Factorial of {n} is: {factorial}");
        }

        // Exercise 8: Recursive Factorial
        static void RecursiveFactorial()
        {
            Console.WriteLine("Enter a number to calculate the factorial recursively:");
            int n = int.Parse(Console.ReadLine());
            BigInteger result = Factorial(n); 
            Console.WriteLine($"Factorial of {n} is: {result}");
        }

        static BigInteger Factorial(int n) 
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }
    }
}

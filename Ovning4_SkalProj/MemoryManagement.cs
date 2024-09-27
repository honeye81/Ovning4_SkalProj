using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning4_SkalProj
{
    public class MemoryManagement
    {
        // Exercise 1: Examine List
        public void ExamineList()
        {
            List<int> numbers = new List<int>();
            Console.WriteLine($"Initial Capacity: {numbers.Capacity}");

            for (int i = 0; i < 20; i++)
            {
                numbers.Add(i);
                Console.WriteLine($"Added {i}, Capacity: {numbers.Capacity}, Count: {numbers.Count}");
            }

            numbers.RemoveAt(0);
            Console.WriteLine($"After removing one element: Capacity: {numbers.Capacity}, Count: {numbers.Count}");
        }

        // Exercise 2: Examine Queue
        public void ExamineQueue()
        {
            Queue<string> queue = new Queue<string>();

            // Simulating the queue at ICA
            queue.Enqueue("Kalle");
            queue.Enqueue("Greta");
            Console.WriteLine($"{queue.Dequeue()} is served.");
            queue.Enqueue("Stina");
            Console.WriteLine($"{queue.Dequeue()} is served.");
            queue.Enqueue("Olle");

            // Process the remaining queue
            while (queue.Count > 0)
            {
                Console.WriteLine($"{queue.Dequeue()} is served.");
            }
        }

        // Exercise 3: Examine Stack
        public void ExamineStack()
        {
            Stack<string> stack = new Stack<string>();

            // Simulating a stack (not ideal for a queue)
            stack.Push("Kalle");
            stack.Push("Greta");
            Console.WriteLine($"{stack.Pop()} is served (Last In First Out).");
            stack.Push("Stina");
            Console.WriteLine($"{stack.Pop()} is served.");
            stack.Push("Olle");

            while (stack.Count > 0)
            {
                Console.WriteLine($"{stack.Pop()} is served.");
            }
        }

        // Reverse a text using stack
        public void ReverseText()
        {
            Console.WriteLine("Enter a text: ");
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            foreach (char c in input)
            {
                stack.Push(c);
            }

            Console.Write("Reversed text: ");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }

        // Exercise 4: Check Parentheses
        public bool CheckParentheses(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);  
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0) return false;  

                    char open = stack.Pop(); 
                    if (!IsMatchingPair(open, c)) return false;
                }
            }

            return stack.Count == 0;  
        }

        private bool IsMatchingPair(char open, char close)
        {
            return (open == '(' && close == ')') ||
                   (open == '{' && close == '}') ||
                   (open == '[' && close == ']');
        }

    }

}
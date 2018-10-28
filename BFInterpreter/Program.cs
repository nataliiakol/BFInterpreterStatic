using System;

namespace BFInterpreter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            
            Interpret(input);
            Console.ReadLine();
        }

        public static string Interpret(string input)
        {
            byte[] memory = new byte[30000];
            int memoryPointer = 0;
            int inputPointer = 0;
            string result="";
            while (inputPointer < input.Length)
            {
                switch (input[inputPointer++])
                {
                    case '>': memoryPointer++; break;
                    case '<': memoryPointer = (memoryPointer > 0) ? memoryPointer - 1 : 0; break;
                    case '+': memory[memoryPointer] = (Byte)(memory[memoryPointer] + 1); break;
                    case '-': memory[memoryPointer] = (memory[memoryPointer] > 0) ? (Byte)(memory[memoryPointer] - 1) : (Byte)0; break;
                    case '.': Console.WriteLine(Convert.ToChar(memory[memoryPointer]));
                        result += Convert.ToChar(memory[memoryPointer]);
                        break;
                    case '[':
                        if (memory[memoryPointer] == 0)
                            FindEndBFLoop(input, ref inputPointer); break;
                    case ']': FindStartBFLoop(input, ref inputPointer); break;
                    default: Console.WriteLine("Wrong input"); break;
                }
            }
            return result;
        }

        private static void FindEndBFLoop(string input, ref int pointer)
        {
            int loop = 1;
            while (loop > 0)
            {
                pointer++;
                if (input[pointer] == '[')
                {
                    loop++;
                }
                else if (input[pointer] == ']')
                {
                    loop--;
                }
            }
            pointer++;
        }

        private static void FindStartBFLoop(string input, ref int pointer)
        {
            pointer--;
            int loop = 1;
            while (loop > 0)
            {
                pointer--;
                if (input[pointer] == '[')
                {
                    loop--;
                }
                else if (input[pointer] == ']')
                {
                    loop++;
                }
            }
        }
    }
}
using System;

namespace _02._Enter_Number.cs
{
	class Program
	{
        static void Main(string[] args)
        {
            ReadNumber(1, 100);
        }

        public static void ReadNumber(int start, int end)
        {
            int[] array = new int[10];

            int index = 0;

            while (index < 10)
            {
                try
                {
                    int number = int.Parse(Console.ReadLine());

                    if (number <= start || number >= end)
                    {
                        Console.WriteLine($"Your number is not in range ({number} - 100)");
                    }
                    else
                    {
                        array[index] = number;
                        index++;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }
    }
}

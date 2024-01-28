using System;

namespace _04._Sum_of_Integers
{
	class Program
	{
		static void Main(string[] args)
		{
            string[] input = Console.ReadLine().Split();

            int sum = 0;

            foreach (var item in input)
            {
                try
                {
                    int currentNumber = int.Parse(item);

                    sum += currentNumber;
                }
                catch (Exception ex)
                {
                    if (ex is FormatException)
                    {
                        Console.WriteLine($"The element '{item}' is in wrong format!");
                    }
                    if (ex is OverflowException)
                    {
                        Console.WriteLine($"The element '{item}' is out of range!");
                    }
                }
                Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
	}
}

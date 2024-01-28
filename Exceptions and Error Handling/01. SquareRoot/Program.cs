using System;

namespace _01._Square_Root
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				uint number = uint.Parse(Console.ReadLine());

				Console.WriteLine(Math.Sqrt(number));
			}
			catch (OverflowException)
			{
				Console.WriteLine("Invalid number.");
			}
			finally
			{
				Console.WriteLine("Goodbye.");
			}
		}
	}
}


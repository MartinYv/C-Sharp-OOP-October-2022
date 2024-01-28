using System;
using System.Linq;

namespace _05._Play_Catch
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();

			int exCount = 0;

			while (exCount < 3)
			{
				try
				{
					string[] input = Console.ReadLine().Split();

					if (input[0] == "Replace")
					{
						integers[int.Parse(input[1])] = int.Parse(input[2]);
					}
					if (input[0] == "Print")
					{
						int start = int.Parse(input[1]);
						int end = int.Parse(input[2]);

						if (start < 0 || start >= integers.Length || end >= integers.Length || end < 0)
						{
							throw new IndexOutOfRangeException();
						}

						for (int i = start; i <= end; i++)
						{
							Console.Write($"{integers[i]}");

							if (i < end)
							{
								Console.Write(", ");
							}
						}

						Console.WriteLine();
					}
					if (input[0] == "Show")
					{
						Console.WriteLine(integers[int.Parse(input[1])]);
					}
				}
				catch (Exception ex)
				{
					exCount++;

					if (ex is IndexOutOfRangeException)
					{
						Console.WriteLine("The index does not exist!");
					}
					if (ex is FormatException)
					{
						Console.WriteLine("The variable is not in the correct format!");
					}
				}
			}

			Console.WriteLine(String.Join(", ", integers));
		}
	}
}

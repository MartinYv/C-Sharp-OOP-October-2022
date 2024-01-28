using System;

namespace _03._Shapes
{
	class Program
	{
		static void Main(string[] args)
		{
            Shape circle = new Circle(3);

            Console.WriteLine(circle.Draw());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());

            Shape rectangle = new Rectangle(5, 7);

            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
        }
	}
}

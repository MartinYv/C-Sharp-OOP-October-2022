using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Shapes
{
        public class Rectangle : IDrawable
        {
            private int width;
            private int height;

            public Rectangle(int width, int height)
            {
                this.width = width;
                this.height = height;
            }

            public void Draw()
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

                for (int j = 0; j < height - 2; j++)
                {
                    Console.Write("*");
                    for (int k = 0; k < width - 2; k++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine("*");
                }

                for (int j = 0; j < width; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
}

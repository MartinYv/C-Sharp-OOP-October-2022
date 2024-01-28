using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Shapes
{
	public class Rectangle : Shape
	{
		private double width, height;

		public Rectangle(double width, double height)
		{
			Width = width;
			Height = height;
		}

		public double Width
		{
			get { return width; }
			private set { width = value; }
		}
		public double Height
		{
			get { return height; }
			private set { height = value; }
		}

		public override double CalculateArea()
		{
			return Height * Width;
		}

		public override double CalculatePerimeter()
		{
			return Height * 2 + Width * 2;
		}

		public override string Draw()
		{
			return base.Draw() + GetType().Name;
		}
	}
}

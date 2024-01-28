using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
   public class Box
    {
        private double length;
        private double width;
        private double height;


        // Length - double, should not be zero or negative number
        //
        // Width - double, should not be zero or negative number
        //
        // Height - double, should not be zero or negative number

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return length; }

           private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                
                length = value; 
            }
        }

      

        public double Width
        {
            get { return width; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }

                width = value;
            }
        }
        

        public double Height
        {
            get { return height; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                height = value; 
            }
        }


       public double SurfaceArea()
        {
            //2lw + 2lh + 2wh
            double surfaceArea = 2 * length * width + 2 * length * height + 2 * width * height;
            return surfaceArea;
        }

        public double LateralSurfaceArea()
        {
            //2lh + 2wh

            double lateralSurfaceArea = 2 * length * height + 2 * width * height;
            return lateralSurfaceArea;

        }

        public double Volume()
        {
            //2lw + 2lh + 2wh

            double volume = length * width  * height;
            return volume;
        }
    }
}

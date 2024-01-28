using System;
using System.Diagnostics;

namespace ClassBoxData 
{
   public class Program
    {
        static void Main(string[] args)
        {
            // Surface Area -52.00 Lateral Surface Area - 40.00 Volume - 24.00

            
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.Volume():f2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
             
            }
            
        }
    }
}

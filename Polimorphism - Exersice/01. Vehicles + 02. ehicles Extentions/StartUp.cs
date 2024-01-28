using System;
using System.Collections;
using System.Collections.Generic;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Polimorphism
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carINfo = Console.ReadLine().Split();
            string[] truckINfo = Console.ReadLine().Split();
            string[] busINfo = Console.ReadLine().Split();

            IVehicle car = new Car(double.Parse(carINfo[1]), double.Parse(carINfo[2]), double.Parse(carINfo[3]));
            IVehicle truck = new Truck(double.Parse(truckINfo[1]), double.Parse(truckINfo[2]), double.Parse(truckINfo[3]));
            IVehicle bus = new Bus(double.Parse(busINfo[1]), double.Parse(busINfo[2]), double.Parse(busINfo[3]));


            List<IVehicle> vehicles = new List<IVehicle>();

            vehicles.Add(car);
            vehicles.Add(truck);
            vehicles.Add(bus);

            int countOfVehicles = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfVehicles; i++)
            {

                string command = Console.ReadLine();
                string[] commands = command.Split();

                string type = commands[1];

                if (type == "Car")
                {
                    if (commands[0] == "Refuel")
                    {
                        car.Refuel(double.Parse(commands[2]));
                    }
                    else if (commands[0] == "Drive")
                    {
                        car.Drive(double.Parse(commands[2]));
                    }
                }
                else if (type == "Truck")
                {
                    if (commands[0] == "Refuel")
                    {
                        truck.Refuel(double.Parse(commands[2]));
                    }
                    else if (commands[0] == "Drive")
                    {
                        truck.Drive(double.Parse(commands[2]));
                    }
                }
                else if (type == "Bus")
                {
                    if (commands[0] == "Refuel")
                    {
                        bus.Refuel(double.Parse(commands[2]));
                    }
                    else if (commands[0] == "Drive")
                    {
                        bus.Drive(double.Parse(commands[2]));
                    }
                    else if (commands[0] == "DriveEmpty")
                    {

                        bus.Drive(double.Parse(commands[2]), commands[0]);
                      
                    }
                }
            }

            foreach (IVehicle item in vehicles)
            {
                Console.WriteLine($"{item.GetType().Name}: {item.FuelQuantity:f2}");
            }
        }
    }
}
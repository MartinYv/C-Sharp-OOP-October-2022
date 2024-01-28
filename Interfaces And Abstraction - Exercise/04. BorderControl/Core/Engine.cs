using BorderControl.Core.Interfaces;
using BorderControl.IO;
using BorderControl.IO.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {

        private readonly List<IIdentify> ids;

        private readonly IConsoleWrite writer;
        private readonly IConsoleReader reader;

        public Engine()
        {
            ids = new List<IIdentify>();

            writer = new ConsoleWrite();
            reader = new ConsoleRead();
        }

        public void Run()
        {

            string input;
            while ((input= reader.ReadLine())!= "End")
            {
                string[] info = input.Split();

                if (info.Length == 3)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];

                    IIdentify citizen = new Citizen(name, age, id);

                    ids.Add(citizen);
                }
                else if (info.Length == 2)
                {
                    string model = info[0];
                    string id = info[1];

                    IIdentify robot = new Robot(model, id);

                    ids.Add(robot);
                }
            }


            string fakeIdEnd = reader.ReadLine();


            foreach (var item in ids)
            {
                if (item.Id.EndsWith(fakeIdEnd))
                {
                    writer.WriteLine(item.Id);
                }
            }
        }
    }
}

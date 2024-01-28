using CommandPattern.Core.Contracts;
using CommandPattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            string data;
            while ((data= Console.ReadLine())!= "Exit")
            {
              string result=  commandInterpreter.Read(data);
                Console.WriteLine(result);

            }
    }
}

}

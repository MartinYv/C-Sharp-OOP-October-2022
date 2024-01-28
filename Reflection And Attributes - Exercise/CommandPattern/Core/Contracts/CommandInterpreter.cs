using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public CommandInterpreter()
        {

        }
        public string Read(string args)
        {
            string [] input = args.Split();
            string command = input[0];
            string[] value = input.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == command);

            if (type==null)
            {
                throw new ArgumentException("Missing command");
            }

            var instance = Activator.CreateInstance(type) as ICommand;

            string result = instance.Execute(value);
            
            return result;
        }
    }
}

using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Models
{
    public class HelloCommand : ICommand
    {
        public HelloCommand()
        {

        }
        public string Execute(string[] args)
        {
            return $"Hello, {string.Join("",args[0])}";
        }
    }
}

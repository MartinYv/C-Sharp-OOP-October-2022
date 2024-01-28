using BorderControl.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.IO
{
   public class ConsoleRead : IConsoleReader
    {
        public string ReadLine() => Console.ReadLine();

    }
}

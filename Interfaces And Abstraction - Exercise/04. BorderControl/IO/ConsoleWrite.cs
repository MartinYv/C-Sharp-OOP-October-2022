﻿using BorderControl.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.IO
{
    public class ConsoleWrite : IConsoleWrite
    {
        public void Write(string text) => Console.Write(text);
        public void WriteLine(string text) => Console.WriteLine(text);

    }
}
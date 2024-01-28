using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.IO.Interfaces
{
    public interface IConsoleWrite
    {
        public void Write(string text);

        public void WriteLine(string text);
    }
}

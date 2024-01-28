using BorderControl.Core;
using BorderControl.Core.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
   public class StartUp
    {
        static void Main(string[] args)
        {

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}

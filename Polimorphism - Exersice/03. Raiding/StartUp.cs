using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;
using System;

namespace Raiding
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

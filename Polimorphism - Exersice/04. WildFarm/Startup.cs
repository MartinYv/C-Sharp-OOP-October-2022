using System;
using WildFarm.Core;
using WildFarm.Core.Interfaces;

namespace WildFarm
{
  public  class Startup
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();     
            engine.Run(); 
        }
    }
}

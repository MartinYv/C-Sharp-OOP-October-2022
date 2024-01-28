using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factiories.Interfaces
{
   public interface ICreateChamp
    {
        public IBaseHero CreateChamp(string type, string name);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int ROGUE_BASE_POWER = 80;
        public Rogue(string name) : base(name, ROGUE_BASE_POWER)
        {

        }

        public override string CastAbility()
        {
            return $"{typeof(Rogue).Name} - {Name} hit for {Power} damage";
        }
    }
}

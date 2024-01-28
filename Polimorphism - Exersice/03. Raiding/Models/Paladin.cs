using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int PALADIN_BASE_POWER = 100;
        public Paladin(string name) : base(name, PALADIN_BASE_POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{typeof(Paladin).Name} - {Name} healed for {Power}";
        }
    }
}

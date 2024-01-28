using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DRUID_BASE_POWER = 80;

        public Druid(string name) : base(name, DRUID_BASE_POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{typeof(Druid).Name} - {Name} healed for {Power}";
        }
    }
}

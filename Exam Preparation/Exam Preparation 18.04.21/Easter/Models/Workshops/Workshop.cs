using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (egg.IsDone() != true && bunny.Energy > 0 && bunny.Dyes.Any(x => x.IsFinished() != true))
            {
                for (int i = 0; i < bunny.Dyes.Count; i++)
                {

                    if (egg.IsDone() == true || bunny.Energy == 0)
                    {
                        break;
                    }


                    if (bunny.Dyes.ToList()[i].IsFinished() == false)
                    {
                        bunny.Dyes.ToList()[i].Use();
                        i--;

                        bunny.Work();
                        egg.GetColored();

                    }
                }
            }
        }
    }
}


using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
   public class Controller : IController
    {
        private List<ICaptain> captains;
        private IRepository<IVessel> vessels;       //125/150

        public Controller()
        {
            captains = new List<ICaptain>();
            vessels = new VesselRepository();
        }


        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            IVessel vessel = vessels.FindByName(selectedVesselName);

            if (captain == null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);

            }
            if (vessel.Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);

            }

            vessel.Captain = captain;
            captain.AddVessel(vessel);
            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);

            
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = vessels.FindByName(attackingVesselName);
            IVessel deffendingVessel = vessels.FindByName(defendingVesselName);


            if (attackingVessel == null )
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            else if (deffendingVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, deffendingVessel);
            }

            if (attackingVessel.ArmorThickness <= 0 || deffendingVessel.ArmorThickness <= 0)
            {
                string vesselWithNoArmor = attackingVessel.ArmorThickness <= 0 ? $"{attackingVessel.Name}" : $"{deffendingVessel.Name}";
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, vesselWithNoArmor);
            }

            attackingVessel.Attack(deffendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            deffendingVessel.Captain.IncreaseCombatExperience();

            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, deffendingVessel.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            string result = captains.First(x => x.FullName == captainFullName).Report();
            return result;
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == fullName);

            if (captain == null)
            {
                ICaptain captainToAdd = new Captain(fullName);
                captains.Add(captainToAdd);
                return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
            }
            else
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);

            }
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.FindByName(name) != null)
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }
            
            if (vesselType != "Battleship" && vesselType != "Submarine")
            {
                return String.Format(OutputMessages.InvalidVesselType, vesselType, name);

            }

            IVessel vessel = null;
            
            if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);

            }

            vessels.Add(vessel);
            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            if (vessel != null)
            {
                vessel.RepairVessel();
                return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
            }
            else
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);

            }
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vessel.GetType().Name == "Battleship")
            {
                IBattleship battleship = vessels.FindByName(vesselName) as Battleship;
                battleship.ToggleSonarMode();
                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                ISubmarine battleship = vessels.FindByName(vesselName) as ISubmarine;
                battleship.ToggleSubmergeMode();
                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
        }

        public string VesselReport(string vesselName)
        {
            string result = vessels.FindByName(vesselName).ToString();
            return result;
        }
    }
}

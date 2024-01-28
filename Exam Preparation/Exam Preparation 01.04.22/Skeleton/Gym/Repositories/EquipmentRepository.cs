using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment>  equipmentInTheGym;

        public EquipmentRepository()
        {
            equipmentInTheGym = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models => equipmentInTheGym;

        public void Add(IEquipment model)
        {
            equipmentInTheGym.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            var equipmentByType = equipmentInTheGym.FirstOrDefault(x => x.GetType().Name == type);

            return equipmentByType;
        }

        public bool Remove(IEquipment model)
        {
            bool isItExisting = equipmentInTheGym.Contains(model);

            if (isItExisting == true)
            {
                equipmentInTheGym.Remove(model);
            }

            return isItExisting;
        }
    }
}

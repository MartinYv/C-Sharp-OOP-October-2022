using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Birthday_Celebrations
{
	class Citizen : IIdentifiable
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; set; }
        public string Id { get; set; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
   public class Team
    {

        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();

            Name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public IReadOnlyList<Person> FirstTeam => firstTeam;
        public IReadOnlyList<Person> ReserveTeam => reserveTeam;
       public void AddPlayer(Person person)
        {

            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
   public class Kitten : Cat
    {
        private const string KITTENS_GENDER = "Female";

        public Kitten(string name, int age, string gender) : base(name, age, KITTENS_GENDER)
        {
        }

        public override string ProduceSound()
        {
            return"Meow";
        }
    }
}

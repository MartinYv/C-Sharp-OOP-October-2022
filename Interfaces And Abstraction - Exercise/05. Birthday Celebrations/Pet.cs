﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Birthday_Celebrations
{
	class Pet : IIdentifiable
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public string Id { get; set; }

            public Pet(string name, string birthdate)
            {
                Name = name;
                Birthdate = birthdate;
            }

        }
}

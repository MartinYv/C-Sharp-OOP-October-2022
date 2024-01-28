using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Food_Shortage
{
	public class Robot : IIdentifiable
	{
		public string Model { get; set; }
		public string Id { get; set; }
		public string Birthdate { get; set; }

		public Robot(string model, string id)
		{
			Model = model;
			Id = id;
		}


	}
}

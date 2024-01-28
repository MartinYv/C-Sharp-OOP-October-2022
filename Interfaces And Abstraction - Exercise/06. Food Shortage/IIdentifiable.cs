using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Food_Shortage
{
	public interface IIdentifiable
	{
		public string Id { get; set; }
		public string Birthdate { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Birthday_Celebrations
{
	public interface IIdentifiable
	{
		public string Id { get; set; }
		public string Birthdate { get; set; }
	}
}

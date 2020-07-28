using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteperGame
{
    class AnimalCard
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public AnimalCard(string name)
		{
			Name = name;
		}
	}
}

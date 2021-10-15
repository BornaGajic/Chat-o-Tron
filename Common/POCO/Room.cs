using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.POCO
{
	public class Room
	{
		public Guid id = Guid.Empty;

		public string name = string.Empty;
		public int numOfParticipants = 0;
	}
}

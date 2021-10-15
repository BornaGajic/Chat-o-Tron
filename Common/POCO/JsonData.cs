using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utility.Utility;

namespace Common.POCO
{
	public class JsonData
	{
		public Commands command;

		public Room room = new Room();

		public string message = string.Empty;
		public string username = string.Empty;

		public bool isMessageMine = false;

		public List<Room> activeRooms = new List<Room>();
	}
}

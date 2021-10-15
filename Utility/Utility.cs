using System;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace Utility
{
    public class Utility
	{
        public enum Commands { NewRoom, Refresh, Join, Leave, LeaveAll, Post }
           
        public static string username;

		public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
	}
}

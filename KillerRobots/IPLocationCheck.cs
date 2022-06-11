using System;
using System.Drawing;
using Console = Colorful.Console;
namespace KillerRobots
{
    public class IPLocationCheck
    {
        public string status { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string region { get; set; }
        public string regionName { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string timezone { get; set; }
        public string isp { get; set; }
        public string org { get; set; }
        public string @as { get; set; }
        public string query { get; set; }

        public IPLocationCheck()
        {

        }

        public void rejectionMessage()
        {
            Console.WriteLine($"\n!!! Un-Authorized Request !!!", Color.OrangeRed);
            Console.Write($"Request IP: ", Color.DarkGreen);
            Console.WriteLine($"{query}", Color.Yellow);
            Console.Write($"    Origin: ", Color.DarkGreen);
            Console.WriteLine($"{ city}, {country}", Color.Yellow);
        }
    }
}


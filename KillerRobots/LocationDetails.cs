using System;
using Newtonsoft.Json;
namespace KillerRobots
{
    public class Address
    {

        public string road { get; set; } = "";
        public string suburb { get; set; } = "";
        public string town { get; set; } = "";
        public string borough { get; set; } = "";
        public string city { get; set; } = "";
        public string municipality { get; set; } = "";
        public string state { get; set; } = "";
        public string postcode { get; set; } = "";
    }

    public class LocationData
    {
        public string lat { get; set; } = "";
        public string lon { get; set; } = "";
        public string display_name { get; set; } = "";
        public string @class { get; set; } = "";
        public string type { get; set; } = "";
        public Address address { get; set; }

        public string ShortName()
        {
            string[] fields = display_name.Split(", ");

            return fields[0];
        }

        public string ReturnValue()
        {
            string LocationDetails = "";
            if (ShortName().Length > 0) LocationDetails += "     Name: " + ShortName() + "\n";
            if (@class.Length > 0) LocationDetails += "    Class: " + @class + "\n";
            if (type.Length > 0) LocationDetails += "     Type: " + type + "\n";
            if (lat.Length > 0) LocationDetails += "      Lat: " + lat + "\n";
            if (lon.Length > 0) LocationDetails += "      Lon: " + lon + "\n";
            if (address.road.Length > 0)LocationDetails += "     Road: " + address.road + "\n";
            if (address.suburb.Length > 0) LocationDetails += "   Suburb: " + address.suburb + "\n";
            if (address.town.Length > 0) LocationDetails += "     Town: " + address.town + "\n";
            if (address.borough.Length > 0) LocationDetails += "  Borough: " + address.borough + "\n";
            if (address.city.Length > 0) LocationDetails += "     City: " + address.city + "\n";
            if (address.state.Length > 0) LocationDetails += "    State: " + address.state + "\n";
            if (address.postcode.Length > 0) LocationDetails += "Post Code: " + address.postcode + "\n";

            return LocationDetails;
        }



        public override string ToString()
        {
            return ReturnValue();
        }
    }
}



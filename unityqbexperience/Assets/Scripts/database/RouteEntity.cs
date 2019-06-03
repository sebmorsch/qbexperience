using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBank
{
    public class RouteEntity
    {

        public string _id;
        public string _name;
        public string _listofwaypoints;

        public RouteEntity(string id, string name, string listofwaypoints)
        {
            _id = id;
            _name = name;
            _listofwaypoints = listofwaypoints;
        }

        public static RouteEntity getFakeRoute()
        {
            return new RouteEntity("0", "Hitch", "test");
        }
    }
}
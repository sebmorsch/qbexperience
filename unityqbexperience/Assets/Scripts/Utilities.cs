using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class Utilities {

    private static double yardCoefficient = 1.0936;
    public static double meterInYards(double meter) {
        return (meter * yardCoefficient);
    }

    public static double yardsInMeter(double yards) {
        return (yards / yardCoefficient);
    }

    public static string waypointlistInString(List<Vector3> waypointlist)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < waypointlist.Count; i++)
        {
            if (i == waypointlist.Count)
            {
                string x = waypointlist[i].x.ToString();
                string y = waypointlist[i].y.ToString();
                string z = waypointlist[i].z.ToString();
                sb.Append(x + "," + y + "," + z);
            }
            else if (i == 0)
                {
                    string x = waypointlist[i].x.ToString();
                    string y = waypointlist[i].y.ToString();
                    string z = waypointlist[i].z.ToString();
                    sb.Append(x + "," + y + "," + z);
                }
            else
            {
                string x = waypointlist[i].x.ToString();
                string y = waypointlist[i].y.ToString();
                string z = waypointlist[i].z.ToString();
                sb.Append(";" + x + "," + y + "," + z);
            }
        }
        return sb.ToString();
    }

        public static List<Vector3> stringInWaypointlist(string waypointstring)
        {
            List<Vector3> waypointlist = new List<Vector3>();
            string[] vectors = waypointstring.Split(';');
            for (int i = 0; i < vectors.Length; i++)
            {
            string[] coordinates = vectors[i].Split(',');
            for (int j = 0; j < coordinates.Length; j =+ 3)
            {
                Vector3 vec = new Vector3();
                vec.x = float.Parse(coordinates[j]);
                vec.y = float.Parse(coordinates[j + 1]);
                vec.z = float.Parse(coordinates[j + 2]);
                waypointlist.Add(vec);
                Debug.Log("vecotr" + vec.x + " " + vec.y + " " + vec.z);
            }
            }
            return waypointlist;
        }
} 

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
        foreach (Vector3 vector in waypointlist)
        {
            float x = vector.x;
            float y = vector.y;
            float z = vector.z;
            sb.Append(x + "," + y + "," + z + ";");
        }
        return sb.ToString();
    }

    public static List<Vector3> stringInWaypointlist(string waypointstring)
    {
        List<Vector3> waypointlist = new List<Vector3>();
        for (int i = 0; i < waypointstring.Length; i++)
        {
        }
        return waypointlist;
    }
}

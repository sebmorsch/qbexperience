using System.Collections;
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
}

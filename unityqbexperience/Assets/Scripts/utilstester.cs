using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class utilstester : MonoBehaviour
{

    private string waypointstring;
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> listo = new List<Vector3>();
         
        Vector3 vec1 = new Vector3(1, 2, 0);
        Vector3 vec2 = new Vector3(3, 2, 1);
        Vector3 vec3 = new Vector3(4, 2, 7);
        Vector3 vec4 = new Vector3(8, 9, 5);
        listo.Add(vec1);
        listo.Add(vec2);
        listo.Add(vec3);
        listo.Add(vec4);

        waypointstring = Utilities.waypointlistInString(listo);
        Debug.Log(waypointstring);
        List<Vector3> listo2 = Utilities.stringInWaypointlist(waypointstring);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfScrimmageGenerator: MonoBehaviour {

    public static float xPosition = 0.0F;
    public static float zPosition = 0.0F;
    public static bool issaid = false;
    public static List<Vector3> waypointlistvector;
    GameObject x;
    void Start() {
        xPosition = gameObject.transform.position.x;
        zPosition = gameObject.transform.position.z;
        generateCubes();
    }

    private void generateCubes() {
        GameObject cubeOne = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject cubeTwo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject cubeThree = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject cubeFour = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject cubeFive = GameObject.CreatePrimitive(PrimitiveType.Cube);
        x = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cubeOne.transform.position = new Vector3(xPosition, 0.5F, zPosition);
        cubeTwo.transform.position = new Vector3((xPosition - 1.5F), 0.5F, zPosition);
        cubeThree.transform.position = new Vector3((xPosition + 1.5F), 0.5F, zPosition);
        cubeFour.transform.position = new Vector3((xPosition -3), 0.5F, zPosition);
        cubeFive.transform.position = new Vector3((xPosition + 3), 0.5F, zPosition);
        x.transform.position = new Vector3(12, 0.5F, zPosition);
    }

    private void Update()
    {
        if (issaid)
        {
            x.transform.position = new Vector3(12, 0.5F, zPosition);
            Debug.Log("Spieler fängt an zu laufen");
            x.transform.position = new Vector3((x.transform.position.x + waypointlistvector[0].x), x.transform.position.y, waypointlistvector[0].z);
             issaid = false;
        }
        
    }

    public static void isroutegezogen(string waypointlist)
    {
        issaid = true;
        waypointlistvector = new List<Vector3>();
        waypointlistvector.Clear();
        waypointlistvector = Utilities.stringInWaypointlist(waypointlist);
        Debug.Log(waypointlistvector[0].x + " " + waypointlistvector[0].y+ " " + waypointlistvector[0].z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfScrimmageGenerator: MonoBehaviour {

    private const float cubeXSize = 0.75F;
    private const float cubeYSize = 1.8F;
    private const float cubeZSize = 0.75F;

    private readonly Vector3 cubeVector = new Vector3(cubeXSize, cubeYSize, cubeZSize);

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

        cubeOne.transform.localScale = cubeVector;
        cubeTwo.transform.localScale = cubeVector;
        cubeThree.transform.localScale = cubeVector;
        cubeFour.transform.localScale = cubeVector;
        cubeFive.transform.localScale = cubeVector;
        x.transform.localScale = cubeVector;

        cubeOne.transform.position = new Vector3(xPosition, cubeYSize/2, zPosition);
        cubeTwo.transform.position = new Vector3((xPosition - 1.5F), cubeYSize/2, zPosition);
        cubeThree.transform.position = new Vector3((xPosition + 1.5F), cubeYSize/2, zPosition);
        cubeFour.transform.position = new Vector3((xPosition -3), cubeYSize/2, zPosition);
        cubeFive.transform.position = new Vector3((xPosition + 3), cubeYSize/2, zPosition);
        x.transform.position = new Vector3(12, cubeYSize/2, zPosition);
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

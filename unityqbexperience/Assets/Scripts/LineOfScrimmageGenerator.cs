using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfScrimmageGenerator: MonoBehaviour {

    public static float xPosition = 0.0F;
    public static float zPosition = 0.0F;

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

        cubeOne.transform.position = new Vector3(xPosition, 0.5F, zPosition);
        cubeTwo.transform.position = new Vector3((xPosition - 1.5F), 0.5F, zPosition);
        cubeThree.transform.position = new Vector3((xPosition + 1.5F), 0.5F, zPosition);
        cubeFour.transform.position = new Vector3((xPosition -3), 0.5F, zPosition);
        cubeFive.transform.position = new Vector3((xPosition + 3), 0.5F, zPosition);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCube : MonoBehaviour
{

    Vector3 defaultPosition = new Vector3(0f, -0.05f, 0.5f);
    // Start is called before the first frame update
    public void resetCubePosition()
    {
        transform.position = defaultPosition;
        Debug.Log("Cube position reset");
    }
}

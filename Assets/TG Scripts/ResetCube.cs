using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCube : MonoBehaviour
{
    // Start is called before the first frame update
    public void resetCubePosition()
    {
        transform.position = new Vector3(0f,-0.048f,0.5f);
    }
}

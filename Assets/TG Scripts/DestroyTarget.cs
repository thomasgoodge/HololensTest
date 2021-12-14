using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    public void DestroyThisTarget()
    {
        Destroy(this.gameObject);
    }
}

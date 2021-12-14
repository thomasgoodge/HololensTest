using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    public Stopwatch timeAlive = new Stopwatch();
       // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        timeAlive.Start();
    }
  
    void Update()
    {
        if (timeAlive.ElapsedMilliseconds>timeToDestroy)
     {
         timeAlive.Stop();
        
         Destroy(this.gameObject);
     }
    }

    
}

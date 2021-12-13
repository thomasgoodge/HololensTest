using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public bool isRunning;
    public Text timer;
    public float timeKeeper = 0.0f;

    void Awake()
    {
        timer = GetComponent<Text>();
    }

    void Start()
    {
        isRunning = true;
    }

    void Update()
    {
        timeKeeper += Time.deltaTime;
            if (isRunning == true)
            timer.text = Time.time.ToString("#.00");
        //Debug.Log(timer.text);
    }
}


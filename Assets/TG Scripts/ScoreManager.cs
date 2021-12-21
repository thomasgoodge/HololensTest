using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public int score = 0;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        //Debug.Log(score);
    }

    public void SubtractPoint()
    {
        score -= 1;
        scoreText.text = "Score: " + score.ToString();
    }

    public void HazardPoint()
    {
        score += 3;
        scoreText.text = "Score: " + score.ToString();
    }
}


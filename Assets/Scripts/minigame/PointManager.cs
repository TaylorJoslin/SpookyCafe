using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static int Score = 0;
    public static PointManager instance;
    public TMP_Text scoreCount;

    

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Score = 0;
        scoreCount.text = Score.ToString();

        
    }

    private void Update()
    {
        if (Score == 15)
        {
           
            Time.timeScale = 0;
        }
    }



    public void AddPoints()
    {
        Score++;
        scoreCount.text = Score.ToString();
    }
}

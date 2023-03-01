using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using System.Timers;

public class Timer : MonoBehaviour
{
    public GameObject textDisplay;
    public int Secondleft = 400;
    public bool takeAway = false;
    public TextMeshProUGUI timerText;
    float currentTime = 0f;
    float startingTime = 400f;
    private bool y = true;
    

    private static System.Timers.Timer aTimer;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        int wholeSecond = (int)Mathf.Floor(currentTime);
        currentTime -= 1 * Time.deltaTime;
        timerText.text = $"Time \n {wholeSecond.ToString()}";
        if (wholeSecond <= 100 && y == true)
            {
                Debug.Log("Game Over You had 100 Seconds to comlete that level and you did not complete it");
                y = false;
            }
        
    }

    

    
}



    

    

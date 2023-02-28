using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;

    void Awake()
    {
        startTime = Time.time;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var difference = Time.time - startTime;
        string minutes = ((int)difference / 60).ToString();
        string seconds = (difference % 60).ToString("f0");
        string timeString = minutes + "m " + seconds +"s";
        //Debug.Log(timeString);
        timerText.text = timeString;
    }
}

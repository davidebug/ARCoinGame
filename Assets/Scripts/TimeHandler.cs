using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    public Text timeText;
    private float time;

    private bool timerGameMode;
   
    void Start()
    {

        timerGameMode = GameStateKeeper.getInstance().getGameMode() == GameStateKeeper.GameMode.Timer;
        if (timerGameMode)
            time = 60.0f;
        else
            time = 0.0f;
    }
    void Update()
    {
        
        if (timerGameMode)
        {
            time = time - 1.0f / 30.0f;
            timeText.text = time.ToString().Substring(0, time.ToString().IndexOf(".") + 2) + " s";
        }
        else
        {
            time = time + 1.0f / 30.0f;
            timeText.text = time.ToString().Substring(0, time.ToString().IndexOf(".") + 2) + " s";
        }
    }
}

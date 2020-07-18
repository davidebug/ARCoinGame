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
            time = 0;
    }
    void Update()
    {
        if (GameStateKeeper.getInstance().getGameState() != GameStateKeeper.GameState.Ended)
        {

            if (timerGameMode)
            {
                time -= Time.deltaTime;
                timeText.text = time.ToString().Substring(0, time.ToString().IndexOf(".") + 2) + " s";
                if (time < 0)
                {
                    GameStateKeeper.getInstance().setGameState(GameStateKeeper.GameState.Ended);
                }

            }
            else
            {
                time += Time.deltaTime;
                timeText.text = time.ToString().Substring(0, time.ToString().IndexOf(".") + 2) + " s";
            }
        }
    }
}

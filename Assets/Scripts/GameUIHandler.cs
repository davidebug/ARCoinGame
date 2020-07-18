﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIHandler : MonoBehaviour
{

    [SerializeField]
    private GameObject scorePanel;
    [SerializeField]
    private GameObject timePanel;
    [SerializeField]
    private GameObject welcomePanel;
    [SerializeField]
    private GameObject mode1Button;
    [SerializeField]
    private GameObject mode2Button;
    [SerializeField]
    private GameObject infoMode1;
    [SerializeField]
    private GameObject infoMode2;

    [SerializeField]
    private GameObject startButton;

    [SerializeField]
    private GameObject continueButton;

    [SerializeField]
    private GameObject scanInfoPanel;

    [SerializeField]
    private GameObject gameInfoPanel;

    [SerializeField]
    private GameObject gameEndPanel;

    [SerializeField]
    private Text gameInfoText;

    [SerializeField]
    private GameObject scanInfoPanel2;

    [SerializeField]
    private GameObject changeModeButton;

    [SerializeField]
    private Text changeModeText;

    [SerializeField]
    private GameObject replayButton;

    [SerializeField]
    private GameObject rescanButton;

    private bool playing = false;

    void Awake()
    {
        changeModeButton.SetActive(false);
        gameEndPanel.SetActive(false);
        replayButton.SetActive(false);
        rescanButton.SetActive(false);
        gameInfoPanel.SetActive(false);
        continueButton.SetActive(false);
        scanInfoPanel.SetActive(false);
        scanInfoPanel2.SetActive(false);
        scorePanel.SetActive(false);
        timePanel.SetActive(false);
        startButton.SetActive(false);
    }

    void Update()
    {
        if (playing && GameStateKeeper.getInstance().getGameState() == GameStateKeeper.GameState.Ended)
        {
            gameEnded();
        }
    }


    public void hintScan()
    {
        changeModeButton.SetActive(false);
        gameEndPanel.SetActive(false);
        replayButton.SetActive(false);
        rescanButton.SetActive(false);
        continueButton.SetActive(true);
        scanInfoPanel.SetActive(true);
        welcomePanel.SetActive(false);
        mode1Button.SetActive(false);
        mode2Button.SetActive(false);
        infoMode1.SetActive(false);
        infoMode2.SetActive(false);
    }
    public void startScan()
    {
        changeModeButton.SetActive(false);
        gameEndPanel.SetActive(false);
        replayButton.SetActive(false);
        rescanButton.SetActive(false);
        scanInfoPanel2.SetActive(true);
        startButton.SetActive(true);
        continueButton.SetActive(false);
        scanInfoPanel.SetActive(false);
    }

    public void startPlaying()
    {
        changeModeButton.SetActive(false);
        gameEndPanel.SetActive(false);
        replayButton.SetActive(false);
        rescanButton.SetActive(false);
        playing = true;
        scanInfoPanel2.SetActive(false);
        startButton.SetActive(false);
        scorePanel.SetActive(true);
        timePanel.SetActive(true);
        if (GameStateKeeper.getInstance().getGameMode() != GameStateKeeper.GameMode.Timer)
            gameInfoText.text = "Raccogli una serie di 8 Monete nel minor tempo possibile!";
        gameInfoPanel.SetActive(true);

    }

    public void setMode1()
    {
        GameStateKeeper.getInstance().setGameMode(GameStateKeeper.GameMode.Timer);
    }
    public void setMode2()
    {
        GameStateKeeper.getInstance().setGameMode(GameStateKeeper.GameMode.Coins);
    }
    public void gameEnded()
    {
        playing = false;

        if (GameStateKeeper.getInstance().getGameMode() == GameStateKeeper.GameMode.Timer)
        {
            changeModeText.text = "Modalità\n8 Monete";
        }
        else
        {
            changeModeText.text = "Modalità\nA Tempo";
        }
        changeModeButton.SetActive(true);
        scorePanel.SetActive(false);
        timePanel.SetActive(false);
        gameInfoPanel.SetActive(false);
        gameEndPanel.SetActive(true);
        replayButton.SetActive(true);
        rescanButton.SetActive(true);
    }

    public void changeMode()
    {
        if (GameStateKeeper.getInstance().getGameMode() == GameStateKeeper.GameMode.Timer)
            GameStateKeeper.getInstance().setGameMode(GameStateKeeper.GameMode.Coins);
        else
        {
            GameStateKeeper.getInstance().setGameMode(GameStateKeeper.GameMode.Timer);
        }
    }

}

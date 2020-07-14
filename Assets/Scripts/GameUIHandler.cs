using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // public GameObject replayButton;
    // public GameObject rescanButton;


    void Awake()
    {
        scorePanel.SetActive(false);
        timePanel.SetActive(false);
        startButton.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startScan()
    {
        startButton.SetActive(true);
        welcomePanel.SetActive(false);
        mode1Button.SetActive(false);
        mode2Button.SetActive(false);
        infoMode1.SetActive(false);
        infoMode2.SetActive(false);
    }

    public void startPlaying()
    {
        startButton.SetActive(false);
        scorePanel.SetActive(true);
        timePanel.SetActive(true);
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

    }

    public void changeMode()
    {

    }

    public void showHint()
    {

    }

    public void welcomePage()
    {

    }

}

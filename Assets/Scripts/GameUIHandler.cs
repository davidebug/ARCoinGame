using System.Collections;
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
    private Text gameInfoText;

    [SerializeField]
    private GameObject scanInfoPanel2;
    // public GameObject replayButton;
    // public GameObject rescanButton;


    void Awake()
    {
        gameInfoPanel.SetActive(false);
        continueButton.SetActive(false);
        scanInfoPanel.SetActive(false);
        scanInfoPanel2.SetActive(false);
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


    public void hintScan()
    {
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
        scanInfoPanel2.SetActive(true);
        startButton.SetActive(true);
        continueButton.SetActive(false);
        scanInfoPanel.SetActive(false);
    }

    public void startPlaying()
    {
        scanInfoPanel2.SetActive(false);
        startButton.SetActive(false);
        scorePanel.SetActive(true);
        timePanel.SetActive(true);
        if(GameStateKeeper.getInstance().getGameMode() != GameStateKeeper.GameMode.Timer)
            gameInfoText.text = "Raccogli 8 Monete nel minor tempo possibile!";
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public Text timeText;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = time.ToString();
        time = Time.deltaTime;
        if(GameStateKeeper.getInstance().getGameMode() == GameStateKeeper.GameMode.Timer){
            
        }else{
            
        }
    }
}

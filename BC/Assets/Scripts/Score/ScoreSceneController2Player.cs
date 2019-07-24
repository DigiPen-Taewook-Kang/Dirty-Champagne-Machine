using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSceneController2Player : MonoBehaviour
{
    // UI data
    GameObject StageObj;
    public List<Text> EnemyCount;
    public List<GameObject> Player2ndUI;
    Text stage;
    static public bool stageChangeFlag;

    public GameObject scoreSystem;

    // Score Data
    private int score;
    private int highScore;
    public int[] tankData = new int[4];
    private int tankIndex = 0;
    private int currScore;
    private int compareScore;
    private float nextTime;
    private float time;

    public bool is2PlayerOn;

    public bool is2PlayerUIStop;


    // Start is called before the first frame update
    private void Start()
    {
        is2PlayerOn = (MainmenuSelector.mode == 1) ? false : true;
        is2PlayerUIStop = (is2PlayerOn)? false : true;

        // Hide UIs
        if (!is2PlayerOn)
        {
            for (int i = 0; i < 15; ++i)
            {
                Player2ndUI[i].SetActive(false);
            }
        }
        else
        {
        ScoreScript2Player tmp = scoreSystem.GetComponent<ScoreScript2Player>();

        score = tmp.Score;
        highScore = tmp.HighScore;
        for (int i = 0; i < tmp.KilledTank.Length; ++i)
        {
            tankData[i] = tmp.KilledTank[i];
        }

        // Set Init Values
        StageObj = GameObject.Find("Stage");
        stage = StageObj.GetComponent<Text>();
        stage.text = "STAGE " + MainmenuController.curStage;
        GameObject.Find("HI-SCORE").GetComponent<Text>().text = highScore.ToString();
        GameObject.Find("II-SCORE").GetComponent<Text>().text = score.ToString();

        currScore = 0;
        compareScore = tankData[0];
        nextTime = 1f;
        time = 0f;

        tmp.Score = 0;
        // Clean Up Score Vars
        scoreSystem.GetComponent<ScoreScript2Player>().Score = 0;
        for (int i = 0; i < 4; ++i)
        {
            scoreSystem.GetComponent<ScoreScript2Player>().KilledTank[i] = 0;
        }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!is2PlayerUIStop)
        {
            time += Time.deltaTime;

            // waiting for 1sec
            if (time > nextTime)
            {
                if (tankIndex >= 4)
                {
                    // Code for get out from score scene
                }
                time = 0;
                currScore++;
                if (currScore > compareScore)
                {
                    is2PlayerUIStop = true;
                    currScore = 0;
                    compareScore = tankData[(++tankIndex) % 4];
                }
                EnemyCount[tankIndex % 4].text = currScore.ToString();

            }
        }
        else
        {
            if(GetComponent<ScoreSceneController>().isPlayerUIStop && is2PlayerUIStop)
            {
                GetComponent<ScoreSceneController>().isPlayerUIStop = false;
                is2PlayerUIStop = false;
            }
        }
    }
}

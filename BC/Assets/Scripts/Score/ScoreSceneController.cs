using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSceneController : MonoBehaviour
{
    // UI data
    GameObject StageObj;
    public List<Text> EnemyCount;
    public Text stage;
    //Text stage;
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

    public bool isPlayerUIStop;

    // Start is called before the first frame update
    private void Start()
    {
        // Get a Score & high score
        ScoreScript tmp = scoreSystem.GetComponent<ScoreScript>();
        score = tmp.Score;
        highScore = tmp.HighScore;
        for (int i = 0; i < tmp.KilledTank.Length; ++i)
        {
            tankData[i] = tmp.KilledTank[i];
        }

        // Set Init Values
        //StageObj = GameObject.Find("Stage");
        //stage = StageObj.GetComponent<Text>();
        stage = GameObject.Find("Stage").GetComponent<Text>();

        GameObject.Find("HI-SCORE").GetComponent<Text>().text = highScore.ToString();
        GameObject.Find("I-SCORE").GetComponent<Text>().text = score.ToString();

        currScore = 0;
        compareScore = tankData[0];
        nextTime = 1f;
        time = 0f;

        tmp.Score = 0;
        // Clean Up Score Vars
        scoreSystem.GetComponent<ScoreScript>().Score = 0;
        for(int i = 0; i < 4; ++i)
        {
            scoreSystem.GetComponent<ScoreScript>().KilledTank[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerUIStop)
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
                    isPlayerUIStop = true;
                    currScore = 0;
                    compareScore = tankData[(++tankIndex) % 4];
                }
                EnemyCount[tankIndex % 4].text = currScore.ToString();

            }
        }
        else
        {
            if(isPlayerUIStop&&GetComponent<ScoreSceneController2Player>().is2PlayerUIStop)
            {
                isPlayerUIStop = false;
                GetComponent<ScoreSceneController2Player>().is2PlayerUIStop = false;
            }
        }
    }
}

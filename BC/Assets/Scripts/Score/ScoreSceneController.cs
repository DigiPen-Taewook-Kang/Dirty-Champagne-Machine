using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSceneController : MonoBehaviour
{
    // UI data
    GameObject StageObj;
    Text Enemy1Score;
    Text Enemy1Count;
    Text Enemy2Score;
    Text Enemy2Count;
    Text Enemy3Score;
    Text Enemy3Count;
    Text Enemy4Score;
    Text Enemy4Count;
    Text stage;
    static public bool stageChangeFlag;

    public GameObject scoreSystem;

    // Score Data
    private int score;
    private int highScore;
    public int []tankData = new int[4];

    public float nextTime;

    // Start is called before the first frame update
    private void Start()
    {
        // Debug::: Set the arbitary values
        score = 100;
        highScore = 200;
        tankData = new int[4] { 2, 1, 3, 2 };

        // Get a Score & high score
        ScoreScript tmp = scoreSystem.GetComponent<ScoreScript>();
        score = tmp.TransferedScore;
        highScore = tmp.HighScore;
        for(int i = 0; i < tmp.SavedTank.Length; ++i)
        {
            tankData[i] = tmp.SavedTank[i];
        }

        // Set Init Values
        StageObj = GameObject.Find("Stage");
        stage = StageObj.GetComponent<Text>();
        stage.text = "STAGE " + MainmenuController.curStage;
        GameObject.Find("HI-SCORE").GetComponent<Text>().text = highScore.ToString();
        GameObject.Find("I-SCORE").GetComponent<Text>().text = score.ToString();

        // Initialize variables
        Enemy1Score = GameObject.Find("Enemy1_score").GetComponent<Text>();
        Enemy1Count = GameObject.Find("Enemy1_count").GetComponent<Text>();
        Enemy2Score = GameObject.Find("Enemy2_score").GetComponent<Text>();
        Enemy2Count = GameObject.Find("Enemy2_count").GetComponent<Text>();
        Enemy3Score = GameObject.Find("Enemy3_score").GetComponent<Text>();
        Enemy3Count = GameObject.Find("Enemy3_count").GetComponent<Text>();
        Enemy4Score = GameObject.Find("Enemy4_score").GetComponent<Text>();
        Enemy4Count = GameObject.Find("Enemy4_count").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // DEBUG
        tankData = new int[4] { 2, 1, 3, 2 };

        nextTime = Time.time+10;
        // Loop for tank tier
        for (int tankIndex = 0; tankIndex < tankData.Length; ++tankIndex)
        {
            int value = tankData[tankIndex];
            // Loop for the number of destroyed tank
            for (int count = 0; count < value; ++count)
            {
                while(Time.time < nextTime)
                {
                    Enemy1Count.text = count.ToString();
                }
                nextTime = Time.time + 10;}
        }
    }
}

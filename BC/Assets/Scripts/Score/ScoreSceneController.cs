using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSceneController : MonoBehaviour
{
    // UI data
    GameObject StageObj;
    public List<Text> EnemyCount;
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
        for (int i = 0; i < tmp.SavedTank.Length; ++i)
        {
            tankData[i] = tmp.SavedTank[i];
        }

        // Set Init Values
        StageObj = GameObject.Find("Stage");
        stage = StageObj.GetComponent<Text>();
        stage.text = "STAGE " + MainmenuController.curStage;
        GameObject.Find("HI-SCORE").GetComponent<Text>().text = highScore.ToString();
        GameObject.Find("I-SCORE").GetComponent<Text>().text = score.ToString();



        // DEBUG ///////////////////////////////////////////////////////////
        tankData[0] = 1;
        tankData[1] = 1;
        tankData[2] = 1;
        tankData[3] = 1;
        ///////////////////

        currScore = 0;
        compareScore = tankData[0];
        nextTime = 1f;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > nextTime)
        {
            time = 0;
            currScore++;
            if (currScore > compareScore)
            {
                currScore = 0;
                compareScore = tankData[(++tankIndex)%4];
            }
            EnemyCount[tankIndex % 4].text = currScore.ToString();
        }
    }
}

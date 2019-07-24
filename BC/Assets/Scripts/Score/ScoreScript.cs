using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private static int score = 0;
    private static int highScore = 20000;

    private static int[] killedTank = new int[4];

    public int[] KilledTank { get => killedTank; set => killedTank = value; }
    public int Score { get => score; set => score = value; }
    public int HighScore { get => highScore; set => highScore = value; }

    // Start is called before the first frame update
    void Start()
    {
        // Save score to send to Score Scene
        // Update HighScore
        if(score > highScore)
        {
            highScore = score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score.ToString());
    }
}

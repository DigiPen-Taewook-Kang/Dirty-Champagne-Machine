using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private static int score = 0;
    private static int transferedScore = 0;
    private static int highScore = 20000;

    private static int[] killedTank = new int[4];
    private static int[] savedTank = new int[4];

    public int[] SavedTank { get => savedTank; set => savedTank = value; }
    public int[] KilledTank { get => killedTank; set => killedTank = value; }
    public int Score { get => score; set => score = value; }
    public int TransferedScore { get => transferedScore; set => transferedScore = value; }
    public int HighScore { get => highScore; set => highScore = value; }

    // Start is called before the first frame update
    void Start()
    {
        // Save score to send to Score Scene
        TransferedScore = score;
        // Update HighScore
        if(TransferedScore > HighScore)
        {
            HighScore = TransferedScore;
        }
        // Reset Score
        score = 0;

        // Reset enemy tanks were killed
        for(int i = 0; i<killedTank.Length; i++)
        {
            SavedTank[i] = killedTank[i];
            killedTank[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

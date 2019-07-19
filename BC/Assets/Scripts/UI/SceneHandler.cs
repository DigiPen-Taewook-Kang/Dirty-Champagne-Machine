using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    /*
     * 
     * Handle Scene List
     * 
     * Stage(clear or fail) -> Score
     * Score => Main or curStage
     * curStage -> Stage(Ingame)
     * 
     * 
     * */


    static public bool isGameOver;
    static public bool isGameClear;

    private float timer = 3f;
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Score")
            isGameOver = false;
        isGameClear = false;
        timer = 3f;
    }



    void Update()
    {

        // cngn Stage emdfmf Layer fh qusrud. 
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            Debug.Log("isGameClear >> " + isGameClear);
            Debug.Log("isGameOver >. " + isGameOver);

            //// # game clear condition # ////
            if (Input.GetKeyDown("c"))
            {
                isGameClear = true;
            }
            //////////////////////////////////

            if (isGameOver || isGameClear)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    //Stage1 -> Score -> NextStage or Mainmenu
                    SceneManager.LoadScene("Score");
                }
            }
        }

        // pass by "enter" scene list
        // CurStage & Score & GameOver
        else if (Input.GetButtonDown("Submit"))
        {
            if (SceneManager.GetActiveScene().name == "CurStage")
            {
                SceneManager.LoadScene("Stage1");
            }
            else if ( SceneManager.GetActiveScene().name == "Score")
            {
                if (isGameOver == false) // go nextStage
                {
                    StageNumbChanger.stageChangeFlag = true;
                    SceneManager.LoadScene("CurStage");
                }
                else if (isGameOver == true) // print gameover and go mainmenu
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
            else if ( SceneManager.GetActiveScene().name == "GameOver")
            {
                isGameOver = false;
                SceneManager.LoadScene("Mainmenu");
            }
        }

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenePasser: MonoBehaviour
{
    public bool isGameOver;

    /* scene process
     * 
     * mainmenu -> #start#
     * 
     * -> curStage -> ingame -> score   -> (next)curStage -> ...
     *                                  -> "gameover" -> mainmenu
     *                                  
     * */


    // press enter -> scene change

    string activeSceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Submit")) // enter
        {
            activeSceneName = SceneManager.GetActiveScene().name;


            if (activeSceneName == "CurStage")
            {
                // #################

                //SceneManager.LoadScene("Ingame");
                SceneManager.LoadScene("Stage1");

                // #################
            }
            else if (activeSceneName == "Score")
            {
                // check gameover condition (y: mainmenu , n: CurStage)
                if (IngameTester.overFlag) // t: go Mainmenu f: next stage
                {
                    // load GameOver -> load Mainmenu
                    //SceneManager.LoadScene("Mainmenu");
                    SceneManager.LoadScene("GameOver");
                    return;
                }
                else
                {
                    // Set StageNumb +1
                    StageNumbChanger.stageChangeFlag = true;
                    SceneManager.LoadScene("CurStage");
                }
            }
            else if(activeSceneName == "GameOver")
            {
                SceneManager.LoadScene("Mainmenu");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

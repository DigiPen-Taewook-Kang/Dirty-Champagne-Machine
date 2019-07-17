using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenePasser: MonoBehaviour
{
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
                SceneManager.LoadScene("Ingame");
            }
            else if (activeSceneName == "Score")
            {
                // check gameover condition (y: mainmenu , n: CurStage)
                if (IngameTester.overFlag) // t: go Mainmenu f: next stage
                {
                    SceneManager.LoadScene("Mainmenu");
                    return;
                }
                SceneManager.LoadScene("CurStage");

            }
            
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

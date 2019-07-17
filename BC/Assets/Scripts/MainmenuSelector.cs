using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuSelector : MonoBehaviour
{
    /* scene process
     * 
     * mainmenu -> #start#
     * 
     * -> curStage -> ingame -> score   -> (next)curStage
     *                                  -> "gameover" -> mainmenu
     *                                  
     * */

    int curSelect = 0; // 0: single mode 1: multi mode 2: construction
    public GameObject icon;
    public GameObject[] tab;

    // Start is called before the first frame update
    void Start()
    {
        IngameTester.overFlag = false;   
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(Input.GetButtonDown("Fire1")) // left ctl
        {
            // next tab
            ++curSelect;
            curSelect %= 3;
            buttonMove(curSelect);
        }

        else if (Input.GetButtonDown("Submit")) // enter
        {
            // selected tab start -> mode set & scene change
            if (curSelect == 0) // single mode
            {
                SceneManager.LoadScene("CurStage");
            }
        }
    }

    void buttonMove(int s)
    {
        icon.transform.position = new Vector3(icon.transform.position.x,tab[s].transform.position.y);
    }
}

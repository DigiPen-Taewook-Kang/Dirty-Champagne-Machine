using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameTester : MonoBehaviour
{
    /*
     * 
     * 
     * Ingame condition(clear or fail) controller
     * 
     * 
     * 
     * */

    static public bool overFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (Input.GetKeyDown("z"))
        {
            SceneManager.LoadScene("Score");

            overFlag = true;
        }
        else if (Input.GetKeyDown("a"))
        {
            SceneManager.LoadScene("Score");

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageNumbChanger : MonoBehaviour
{
    GameObject StageObj;
    Text stage;
    static public bool stageChangeFlag;

    // Start is called before the first frame update
    private void Start()
    {
        StageObj = GameObject.Find("StageNumb");
        //stageNumb = GetComponentInChildren<Text>();
        stage = StageObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("?");
        
        if (stageChangeFlag == true)
        {
            stageChangeFlag = false;
            
            MainmenuController.curStage = MainmenuController.curStage + 1;
            
            stage.text = "STAGE " + MainmenuController.curStage;

        }


    }
}

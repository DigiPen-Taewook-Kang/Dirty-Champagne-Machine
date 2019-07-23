using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageNumbChanger : MonoBehaviour
{
    Text stage;
    static public bool stageChangeFlag;

    // Start is called before the first frame update
    private void Start()
    {
        
        stage = GameObject.Find("Stage").GetComponent<Text>();
        //Debug.Log("NowStageinNumbChanger >> " + MainmenuController.curStage);
        //Debug.Log("stageChangeFlag >> " + StageNumbChanger.stageChangeFlag);
        StageNumbChanger.stageChangeFlag = true;
        stage.text = "STAGE " + MainmenuController.curStage;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (stageChangeFlag == true)
        {
            //Debug.Log("Stage change");
            stageChangeFlag = false;
            //Debug.Log("Before >> " + MainmenuController.curStage);
            MainmenuController.curStage = MainmenuController.curStage + 1;
            //Debug.Log("After >> " + MainmenuController.curStage);
            stage.text = "STAGE " + MainmenuController.curStage;

        }


    }
}

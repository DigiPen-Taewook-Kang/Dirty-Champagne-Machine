using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSceneController : MonoBehaviour
{
    GameObject StageObj;
    Text stage;
    static public bool stageChangeFlag;

    // Start is called before the first frame update
    private void Start()
    {
        StageObj = GameObject.Find("Stage");
        //stageNumb = GetComponentInChildren<Text>();
        stage = StageObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("?");
            stage.text = "STAGE " + MainmenuController.curStage;
    }
}

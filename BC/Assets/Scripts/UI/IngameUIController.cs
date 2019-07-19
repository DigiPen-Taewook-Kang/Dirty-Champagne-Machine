using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUIController : MonoBehaviour
{
    public GameObject[] leftEnemyIcon;
    int leftEnemyCount = 5; // ?

    Text stage;

    // Start is called before the first frame update
    void Start()
    {
        stage = GameObject.Find("curStage").GetComponent<Text>();
        
        stage.text = "" + MainmenuController.curStage;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Mainmenu >> " + MainmenuController.curStage);
        //Debug.Log("curStage >> " + stage.text);

    }

    //public int getLeftEnemy()
    //{
    //    return leftEnemyCount;
    //}

    public void EnemyDestroy()
    {
       // leftEnemyCount = leftEnemyCount - 1;

        Destroy(leftEnemyIcon[--leftEnemyCount]);

        if(leftEnemyCount == 0)
        {
            SceneHandler.isGameClear = true;
        }
    }
}

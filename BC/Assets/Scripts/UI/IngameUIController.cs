using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUIController : MonoBehaviour
{
    public GameObject[] leftEnemyIcon;
    static public int leftEnemyCount; // 20. icon counter
    static public int leftEnemyReal; // left Enemy on field.
    int curLife;
    Text lifeTmp;
    Text stage;


    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        leftEnemyCount = 5; // 20
        leftEnemyReal = leftEnemyCount;

        lifeTmp = GameObject.Find("life").GetComponent<Text>();
        stage = GameObject.Find("curStage").GetComponent<Text>();

        curLife = GameObject.Find("GameManager").GetComponent<GameItemControl>().Player1_Life;
        lifeTmp.text = "" + curLife;
        stage.text = "" + MainmenuController.curStage;
    }

    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("leftEnemyCount >> " + leftEnemyCount);
        //Debug.Log("leftEnemyReal >> " + leftEnemyReal);


         ///// Left player life value change with respawn is better /////
        if(curLife != GameObject.Find("GameManager").GetComponent<GameItemControl>().Player1_Life)
        {
            curLife = GameObject.Find("GameManager").GetComponent<GameItemControl>().Player1_Life;
            lifeTmp.text = "" + curLife;
        }
        /////

        
    }


    public void EnemyDestroy()
    {

        Destroy(leftEnemyIcon[--leftEnemyCount]);

        /*
        if(leftEnemyCount == 0)
        {
            SceneHandler.isGameClear = true;
        }
        */
    }
}

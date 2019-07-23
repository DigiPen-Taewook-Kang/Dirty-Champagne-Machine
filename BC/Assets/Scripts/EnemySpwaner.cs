using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpwaner : MonoBehaviour
{
    public float timer;
    private float elapsed;
    //public Rigidbody2D Enemy_t1;
    //public Rigidbody2D Enemy_t2;
    //public Rigidbody2D Enemy_t3;
    //public Rigidbody2D Enemy_t4;

    public Rigidbody2D[] Enemies = new Rigidbody2D[4];

    public GameObject gameManager;
    private int MaxEnemy;
    private int CurEnemy;

    private float[] spawn;
    private int trig;


    private int temporder;
    private int[] spawnOrder;

    private float spawnXpos;
    private int itemspawn;
    private int maxitemCount;
    private int stageRandom;

    //0 normal 1 fast 2 rapid 3 strong
    private int[] stage1 = new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 };
    private int[] stage2 = new int[] { 3, 3, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };



    //-7, 1, 9
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.5f;
        elapsed = timer;
        MaxEnemy = 4;
        CurEnemy = 0;
        itemspawn = 0;
        maxitemCount = 3;

        spawnOrder = new int[20];
        temporder = 0;

        spawn = new float[3] { 1, 13, -11 };
        trig = 0;



        StageSelect();




    }
    void StageSelect()
    {
        var CurrentScene = SceneManager.GetActiveScene();
        var currentSceneName = CurrentScene.name;
        if (currentSceneName == "Stage1")
        {
            spawnOrder = stage1;
            //print("stage1");
        }
        else if (currentSceneName == "Stage2")
        {
            spawnOrder = stage2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CurEnemy = GameObject.FindGameObjectsWithTag("T1Tank").Length
            + GameObject.FindGameObjectsWithTag("T2Tank").Length
            + GameObject.FindGameObjectsWithTag("T3Tank").Length
            + GameObject.FindGameObjectsWithTag("T4Tank").Length;


        if (IngameUIController.leftEnemyCount > 0 && CurEnemy < MaxEnemy)
        {
            elapsed -= Time.deltaTime;
            if (elapsed <= 0)
            {
                spawnXpos = spawn[trig];

                trig++;
                if (trig == 3)
                    trig = 0;


                if ((IngameUIController.leftEnemyCount == 17 ||
                    IngameUIController.leftEnemyCount == 11 ||
                    IngameUIController.leftEnemyCount == 7) &&
                    maxitemCount > itemspawn)
                {
                    Enemies[spawnOrder[temporder]].GetComponent<EnemySpawnItem>().HadItem = true;
                    //print("erwerew");
                    itemspawn++;
                }
                else
                    Enemies[spawnOrder[temporder]].GetComponent<EnemySpawnItem>().HadItem = false;

                Instantiate(Enemies[spawnOrder[temporder]], new Vector2(spawnXpos, 23), transform.rotation);
                timer = 3.0f;
                elapsed = timer;

                gameManager.GetComponent<IngameUIController>().EnemyDestroy();
                CurEnemy++;

                temporder++;
            }
        }


    }
}

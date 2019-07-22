using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    public float timer;
    private float elapsed;
    public Rigidbody2D Enemy_t1;
    public Rigidbody2D Enemy_t2;
    public Rigidbody2D Enemy_t3;
    public Rigidbody2D Enemy_t4;

    public GameObject gameManager;
    private int MaxEnemy;
    private int CurEnemy;

    private float []spawn;
    private int trig;

    private float spawnXpos;

    //-7, 1, 9
    // Start is called before the first frame update
    void Start()
    {
        timer = 3f;
        elapsed = timer;
        MaxEnemy = 4;
        CurEnemy = 0;

        spawn = new float[3] { 1, 13, -11 };
        trig = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurEnemy = GameObject.FindGameObjectsWithTag("T1Tank").Length
            + GameObject.FindGameObjectsWithTag("T2Tank").Length
            + GameObject.FindGameObjectsWithTag("T3Tank").Length
            + GameObject.FindGameObjectsWithTag("T4Tank").Length;


        if (gameManager.GetComponent<IngameUIController>().leftEnemyCount > 0 && CurEnemy < MaxEnemy)
        {
            elapsed -= Time.deltaTime;
            if (elapsed <= 0)
            {
                spawnXpos = spawn[trig];

                trig++;
                if (trig == 3)
                    trig = 0;

                Instantiate(Enemy_t1, new Vector2(spawnXpos, 23), transform.rotation);
                elapsed = timer;

                gameManager.GetComponent<IngameUIController>().EnemyDestroy();
                CurEnemy++;
            }
        }


    }
}

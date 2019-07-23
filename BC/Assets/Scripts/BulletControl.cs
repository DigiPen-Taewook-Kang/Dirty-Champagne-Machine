using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Sound Vars
    public AudioClip strongWall;
    public AudioClip enemyDead;
    public AudioClip baseDead;
    public AudioClip hitWall;
    private AudioSource BulletHitSource;

    //public GameObject gameManager;
    public GameObject bullet_explosion;
    //public Rigidbody2D test;


    List<GameObject> items = new List<GameObject>();
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject Item6;

    private int randomindex;

    private int randomX;
    private int randomY;
    private Transform rota;


    // Start is called before the first frame update
    void Start()
    {
        BulletHitSource = GameObject.Find("Bullet Hit Source").GetComponent<AudioSource>();
        BulletHitSource.clip = strongWall;
        items.Add(Item1);
        items.Add(Item2);
        items.Add(Item3);
        items.Add(Item4);
        items.Add(Item5);
        items.Add(Item6);


    }

    // Update is called once per frame
    void Update()
    {



    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        var check = Instantiate(bullet_explosion, transform.position, gameObject.transform.rotation);
        check.GetComponent<Animator>().enabled = true;
        Destroy(check, 0.5f);

        if (coll.gameObject.tag == "WALL")
        {
            BulletHitSource.clip = strongWall;
        }
        else if (coll.gameObject.tag == "WALL_normal")
        {
            BulletHitSource.clip = hitWall;
            Destroy(coll.gameObject);
        }
        else if (
            coll.gameObject.tag == "T1Tank"
         || coll.gameObject.tag == "T2Tank"
         || coll.gameObject.tag == "T3Tank"
         || coll.gameObject.tag == "T4Tank"
         )
        {
            coll.gameObject.GetComponent<EnemyAI>().health--;

            if (coll.gameObject.GetComponent<EnemySpawnItem>().HadItem)
            {
                randomindex = Random.Range(0, 6);
                randomX = Random.Range(-11, 13);
                randomY = Random.Range(2, 22);

                Instantiate(items[randomindex], new Vector3(randomX, randomY, 1.5f), Quaternion.identity);
            }

            if (coll.gameObject.GetComponent<EnemyAI>().health <= 0)
            {
                BulletHitSource.clip = enemyDead;
                Destroy(coll.gameObject);

                //Game clear Check
                IngameUIController.leftEnemyReal--;
                if (IngameUIController.leftEnemyReal <= 0)
                {
                    SceneHandler.isGameClear = true;
                }
            }
        }
        else if (coll.gameObject.tag == "BaseBlock")
        {
            BulletHitSource.clip = baseDead;
            Destroy(coll.gameObject);
        }
        GameObject[] playerTank = GameObject.FindGameObjectsWithTag("Player_Tank");

        playerTank[0].GetComponent<PlayerFireControl>().IsBulletAlive = false;

        Destroy(gameObject);

        // Play Sound
        BulletHitSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public Sprite DeadBase;

    // Sound Vars
    public AudioClip strongWall;
    public AudioClip enemyDead;
    public AudioClip baseDead;
    public AudioClip hitWall;
    private AudioSource BulletHitSource;

    public GameObject gameManager;
    public GameObject bullet_explosion;
    public Rigidbody2D test;

    public GameObject ScoreSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        // Init Sound Vars
        BulletHitSource = GameObject.Find("Bullet Hit Source").GetComponent<AudioSource>();
        BulletHitSource.clip = strongWall;
        // Init Score Systems
        ScoreSystem = GameObject.Find("ScoreSystem");
    }

    // Update is called once per frame
    void Update()
    {

    }


    void Score(int score)
    {
        ScoreSystem.GetComponent<ScoreScript>().Score += score;
    }

    void KillTank(int num)
    {
        ++ScoreSystem.GetComponent<ScoreScript>().KilledTank[num - 1];
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
        else if (coll.gameObject.tag == "T1Tank")
        {
            Score(100);
            KillTank(1);
            coll.gameObject.GetComponent<EnemyAI>().health--;

            if (coll.gameObject.GetComponent<EnemyAI>().health <= 0)
            {
                BulletHitSource.clip = enemyDead;
                Destroy(coll.gameObject);
            }
        }
        else if (coll.gameObject.tag == "T2Tank")
        {
            Score(200);
            KillTank(2);
            coll.gameObject.GetComponent<EnemyAI>().health--;

            if (coll.gameObject.GetComponent<EnemyAI>().health <= 0)
            {
                BulletHitSource.clip = enemyDead;
                Destroy(coll.gameObject);
            }
        }
        else if (coll.gameObject.tag == "T3Tank")
        {
            Score(300);
            KillTank(3);
            coll.gameObject.GetComponent<EnemyAI>().health--;

            if (coll.gameObject.GetComponent<EnemyAI>().health <= 0)
            {
                BulletHitSource.clip = enemyDead;
                Destroy(coll.gameObject);
            }
        }
        else if( coll.gameObject.tag == "T4Tank")
        {
            Score(400);
            KillTank(4);
            coll.gameObject.GetComponent<EnemyAI>().health--;

            if (coll.gameObject.GetComponent<EnemyAI>().health <= 0)
            {
                BulletHitSource.clip = enemyDead;
                Destroy(coll.gameObject);
            }
        }
        else if(coll.gameObject.tag == "BaseBlock")
        {
            BulletHitSource.clip = baseDead;
            coll.gameObject.GetComponent<SpriteRenderer>().sprite = DeadBase;
            SceneHandler.isGameOver = true;
        }
        GameObject[] playerTank = GameObject.FindGameObjectsWithTag("Player_Tank");

        playerTank[0].GetComponent<PlayerFireControl>().IsBulletAlive = false;

        Destroy(gameObject);

        // Play Sound
        BulletHitSource.Play();
    }
}

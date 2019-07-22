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

    public GameObject gameManager;
    public GameObject bullet_explosion;
    public Rigidbody2D test;

    public GameObject ScoreSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        BulletHitSource = GameObject.Find("Bullet Hit Source").GetComponent<AudioSource>();
        BulletHitSource.clip = strongWall;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void Score(int score)
    {
        ScoreSystem = GameObject.Find("ScoreSystem");
        ScoreSystem.GetComponent<ScoreScript>().Score = score;

        Debug.Log(ScoreSystem.GetComponent<ScoreScript>().Score.ToString());
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
            Score(100);
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
            Destroy(coll.gameObject);
        }
        GameObject[] playerTank = GameObject.FindGameObjectsWithTag("Player_Tank");

        playerTank[0].GetComponent<PlayerFireControl>().IsBulletAlive = false;

        Destroy(gameObject);

        // Play Sound
        BulletHitSource.Play();
    }
}

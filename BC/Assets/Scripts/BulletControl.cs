using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite BaseAfter;

    // Sound Variables
    public AudioClip strongWall;
    public AudioClip enemyDied;
    public AudioClip baseDestroyed;
    public AudioClip hitWall;
    private AudioSource BulletHitSource;

    void Start()
    {
        // Init Sound Var
        BulletHitSource = GameObject.Find("Bullet Hit Source").GetComponent<AudioSource>();
        BulletHitSource.clip = strongWall;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D coll)
    {

        if(coll.gameObject.tag == "T4Tank")
        {
            coll.gameObject.GetComponent<EnemyAI>().health -= 1;
            if(coll.gameObject.GetComponent<EnemyAI>().health == 0)
                Destroy(coll.gameObject);
        }
        else if(coll.gameObject.tag == "WALL_normal")
        {
            BulletHitSource.clip = hitWall;//
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.tag == "T1Tank" || coll.gameObject.tag == "T2Tank" || coll.gameObject.tag == "T3Tank")
        {
            BulletHitSource.clip = enemyDied;
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.tag == "Base")
        {
            BulletHitSource.clip = baseDestroyed;
            coll.gameObject.GetComponent<SpriteRenderer>().sprite = BaseAfter;
            GameObject.Find("Main Camera").GetComponent<SceneHandler>().isGameOver = true;
        }
        GameObject[] playerTank = GameObject.FindGameObjectsWithTag("Player_Tank");

        playerTank[0].GetComponent<PlayerFireControl>().IsBulletAlive = false;

        Destroy(gameObject);

        // Play Sound
        BulletHitSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour
{
    public Sprite BaseAfter;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "WALL_normal" || coll.gameObject.tag == "Player")
        {
            Destroy(coll.gameObject);
        }
        else if(coll.gameObject.tag == "Base")
        {
            coll.gameObject.GetComponent<SpriteRenderer>().sprite = BaseAfter;
            //GameObject.Find("MainCamera").GetComponent<SceneHandler>().isGameOver = true;
            SceneHandler.isGameOver = true;
        }

        Destroy(gameObject);
    }
}

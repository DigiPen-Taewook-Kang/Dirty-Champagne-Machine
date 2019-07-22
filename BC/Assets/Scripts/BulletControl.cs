using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gameManager;
    public Rigidbody2D test;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.gameObject.tag == "T4Tank" || coll.gameObject.tag == "WALL")
        {
            //coll.gameObject.GetComponent<TankHealth>().HP -= 1;
        }
        else if(coll.gameObject.tag == "WALL_normal" 
            || coll.gameObject.tag== "T1Tank" 
            || coll.gameObject.tag == "T2Tank" 
            || coll.gameObject.tag == "T3Tank"
            || coll.gameObject.tag == "BaseBlock"
            )
        {
           
            Destroy(coll.gameObject);
            
        }
        GameObject[] playerTank = GameObject.FindGameObjectsWithTag("Player_Tank");

        playerTank[0].GetComponent<PlayerFireControl>().IsBulletAlive = false;

        Destroy(gameObject);
    }
}

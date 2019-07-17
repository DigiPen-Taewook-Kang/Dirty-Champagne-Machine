using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D coll)
    {

        if(coll.gameObject.tag == "LV4TANK" || coll.gameObject.tag == "WALL")
        {
            //coll.gameObject.GetComponent<TankHealth>().HP -= 1;
        }
        else if(coll.gameObject.tag == "WALL_normal")
        {
            Destroy(coll.gameObject);
        }
        GameObject[] playerTank = GameObject.FindGameObjectsWithTag("Player");

        playerTank[0].GetComponent<PlayerFireControl>().IsBulletAlive = false;

        Destroy(gameObject);
    }
}

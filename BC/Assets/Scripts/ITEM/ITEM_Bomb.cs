using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEM_Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player_Tank")
        {
            GameObject[] T1 = GameObject.FindGameObjectsWithTag("T1Tank");
            GameObject[] T2 = GameObject.FindGameObjectsWithTag("T2Tank");
            GameObject[] T3 = GameObject.FindGameObjectsWithTag("T3Tank");
            GameObject[] T4 = GameObject.FindGameObjectsWithTag("T4Tank");

            foreach (GameObject tank1 in T1)
            {

                Destroy(tank1);
            }
            foreach (GameObject tank2 in T2)
                Destroy(tank2);
            foreach (GameObject tank3 in T3)
                Destroy(tank3);
            foreach (GameObject tank4 in T4)
                Destroy(tank4);

            Destroy(gameObject);
        }
        
    }
}

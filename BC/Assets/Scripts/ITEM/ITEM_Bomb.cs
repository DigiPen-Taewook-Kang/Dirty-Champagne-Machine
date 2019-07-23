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
            int destroyCount = 0;

            foreach (GameObject tank1 in T1)
            {
                tank1.GetComponent<EnemyAI>().isBombItemOn = true;
                //Destroy(tank1);
                destroyCount++;
            }
            foreach (GameObject tank2 in T2)
            {
                tank2.GetComponent<EnemyAI>().isBombItemOn = true;
                //Destroy(tank2);
                destroyCount++;


            }
            foreach (GameObject tank3 in T3)
            {
                tank3.GetComponent<EnemyAI>().isBombItemOn = true;
                //Destroy(tank3);
                destroyCount++;
            }
            foreach (GameObject tank4 in T4)
            {
                tank4.GetComponent<EnemyAI>().isBombItemOn = true;
                //Destroy(tank4);
                destroyCount++;
            }


            IngameUIController.leftEnemyReal -= destroyCount;

            if(IngameUIController.leftEnemyReal <= 0)
            {
                SceneHandler.isGameClear = true;
            }



            Destroy(gameObject);
        }
        
    }
}

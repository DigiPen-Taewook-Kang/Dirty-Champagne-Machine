using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_status : MonoBehaviour
{
    public int playerNum;
    [SerializeField]
    private int HP;
    [SerializeField]
    private int StarLevel;

    public bool ps_IsBarrierOn;
    public float ShieldTimer;


    GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        HP = 1;
        StarLevel = 0;
        ps_IsBarrierOn = true;
        ShieldTimer = 5f;
         gameController = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

        //Deeeeeeeeeeeeeeeead
        if (HP <= 0)
        {
            Destroy(gameObject);
            if(playerNum == 1)
                gameController.GetComponent<GameItemControl>().IsShieldOn1 = true;
            else
                gameController.GetComponent<GameItemControl>().IsShieldOn2 = true;
        }

        //barrier start
        if (ps_IsBarrierOn)
        {
            HP = 10000;

            ShieldTimer -= Time.deltaTime;
            if (ShieldTimer < 0)
            {
                ps_IsBarrierOn = false;
                ShieldTimer = 5f;
            }
        }
        // end
        else if(HP > 1)
        {
            HP = 1;
        }

        //Star Level
        if (StarLevel == 1)
        {
            gameObject.GetComponent<PlayerFireControl>().bulletSpeed = 30;
        }
        else if (StarLevel == 2)
        {
            //double shot

            PlayerFireControl.doubleShotActive = true;
        }
        else if (StarLevel == 3)
        {
            //double shot + penetrate Iron.

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ITEM_Star")
        {
            StarLevel += 1;
            Destroy(collision.gameObject);
        }

        if(collision.collider.tag == "ITEM_Shield")
        {
            ps_IsBarrierOn = true;
            GameObject.FindGameObjectWithTag("Player_Shield").GetComponent<Barrier>().isTimerOn = true;
            Destroy(collision.gameObject);
        }

        if(collision.collider.tag == "BULLET")
        {
            HP -= 1;
        }

    }
}

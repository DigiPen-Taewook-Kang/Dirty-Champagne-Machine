using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemControl : MonoBehaviour
{
    //Freeze
    public bool IsFreezeOn;
    public float FreezeTimer = 10f;

    //Reinforce
    public bool IsReinforceOn;
    public float ReinforceTimer = 5f;

    public GameObject Normal;
    public GameObject Iron;

    //Life Control
    public int Player1_Life = 3;
    public int Player2_Life = 3;

    //Shield
    public bool IsShieldOn1;
    public bool IsShieldOn2;
    public float ShieldTimer1 = 5f;
    public float ShieldTimer2 = 5f;


    //Star
    [HideInInspector]
    public int StarLevel = 0;


    public GameObject[] BTS;


    private int tilemaker = 0;
    private bool loop = false;

    // Start is called before the first frame update
    void Start()
    {
        IsFreezeOn = false;
        IsReinforceOn = false;
        IsShieldOn1 = true;
        IsShieldOn2 = true;

        BTS = GameObject.FindGameObjectsWithTag("BaseBlock");
    }

    // Update is called once per frame
    void Update()
    {
        Freeze();
        Reinforce();
        Shield();
    }
    void Reinforce()
    {
        if (IsReinforceOn)
        {

            if (!loop)
            {
                for (; tilemaker < 8; tilemaker++)
                {
                    GameObject IronWall = Instantiate(Iron, BTS[tilemaker].transform.position, Quaternion.identity);

                    IronWall.gameObject.tag = "BaseBlock_Reinforced";
                    //tilemaker++;
                }
                loop = true;
            }

            ReinforceTimer -= Time.deltaTime;
            if (ReinforceTimer < 0)
            {
                IsReinforceOn = false;
                ReinforceTimer = 5f;
            }
        }
        else if (!IsReinforceOn)
        {
            tilemaker = 0; loop = false;
            GameObject[] IronBlock = GameObject.FindGameObjectsWithTag("BaseBlock_Reinforced");

            foreach (GameObject ib in IronBlock)
            {
                Destroy(ib.gameObject);

                GameObject NormalWall = Instantiate(Normal, ib.transform.position, Quaternion.identity);


                //NormalWall.gameObject.tag = "BaseBlock";


            }

        }


    }

    void Freeze()
    {
        if (IsFreezeOn)
        {
            GameObject[] T1 = GameObject.FindGameObjectsWithTag("T1Tank");
            GameObject[] T2 = GameObject.FindGameObjectsWithTag("T2Tank");
            GameObject[] T3 = GameObject.FindGameObjectsWithTag("T3Tank");
            GameObject[] T4 = GameObject.FindGameObjectsWithTag("T4Tank");

            foreach (GameObject tank1 in T1)
            {
                tank1.GetComponent<EnemyAI>().isFreezeOn = true;
            }
            foreach (GameObject tank2 in T2)
                tank2.GetComponent<EnemyAI>().isFreezeOn = true;
            foreach (GameObject tank3 in T3)
                tank3.GetComponent<EnemyAI>().isFreezeOn = true;
            foreach (GameObject tank4 in T4)
                tank4.GetComponent<EnemyAI>().isFreezeOn = true;

            FreezeTimer -= Time.deltaTime;
            if (FreezeTimer < 0)
            {
                IsFreezeOn = false;
                FreezeTimer = 10f;
            }
        }
        else
        {

            GameObject[] T1 = GameObject.FindGameObjectsWithTag("T1Tank");
            GameObject[] T2 = GameObject.FindGameObjectsWithTag("T2Tank");
            GameObject[] T3 = GameObject.FindGameObjectsWithTag("T3Tank");
            GameObject[] T4 = GameObject.FindGameObjectsWithTag("T4Tank");

            foreach (GameObject tank1 in T1)
            {
                tank1.GetComponent<EnemyAI>().isFreezeOn = false;
            }
            foreach (GameObject tank2 in T2)
                tank2.GetComponent<EnemyAI>().isFreezeOn = false;
            foreach (GameObject tank3 in T3)
                tank3.GetComponent<EnemyAI>().isFreezeOn = false;
            foreach (GameObject tank4 in T4)
                tank4.GetComponent<EnemyAI>().isFreezeOn = false;
        }


    }

    void Shield()
    {
        if (GameObject.Find("Player1"))
        {
            if (IsShieldOn1)
            {
                //if (GameObject.FindGameObjectWithTag("Player_Tank"))
                //{
                //    GameObject playerTank = GameObject.FindGameObjectWithTag("Player_Tank");

                //    playerTank.gameObject.tag = "Player_Tank_Invincible";

                //}

                ShieldTimer1 -= Time.deltaTime;
                if (ShieldTimer1 < 0)
                {
                    IsShieldOn1 = false;
                    ShieldTimer1 = 5f;
                }
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player_Tank").GetComponent<Player_status>().ps_IsBarrierOn = false;
            }
        }

        if (GameObject.Find("Player2"))
        {
            if (IsShieldOn2)
            {

                //if (GameObject.FindGameObjectWithTag("Player_Tank"))
                //{
                //    GameObject playerTank = GameObject.FindGameObjectWithTag("Player_Tank");

                //    playerTank.gameObject.tag = "Player_Tank_Invincible";

                //}

                ShieldTimer2 -= Time.deltaTime;
                if (ShieldTimer2 < 0)
                {
                    IsShieldOn2 = false;
                    ShieldTimer2 = 5f;
                }
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player_Tank").GetComponent<Player_status>().ps_IsBarrierOn = false;
            }

        }
    }
}





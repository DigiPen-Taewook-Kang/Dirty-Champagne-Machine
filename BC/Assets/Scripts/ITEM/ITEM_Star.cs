﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEM_Star : MonoBehaviour
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
        //if (collision.collider.tag == "Player_Tank")
        //{
        //    GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameItemControl>().StarLevel += 1;

        //    Destroy(gameObject);
        //}
    }
}

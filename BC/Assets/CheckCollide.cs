﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollide : MonoBehaviour
{
    [HideInInspector]
    public bool IsCollide = false;

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
        if (collision.collider != null)
        {
            IsCollide = true;
            //print("Collision with gun");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsCollide = false;
    }
}

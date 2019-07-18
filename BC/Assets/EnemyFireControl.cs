﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireControl : MonoBehaviour
{
    public float bulletSpeed = 10f;
    private float coundown = 5f;

    public Transform Gun;
    public Rigidbody2D projectile;

    private Vector3 FireDirection;

    public bool IsBulletAlive;

    private string myBullet;

    void Start()
    {
        FireDirection = new Vector3(0, 1, 0);
        IsBulletAlive = false;
    }

    void Update()
    {
        if (IsBulletAlive == false)
        {
            coundown -= Time.deltaTime;
            if (coundown <= 0)
            {
                Fire();
            }
        }

        if (GameObject.Find(myBullet) == null)
        {
            IsBulletAlive = false;
        }
    }
    void Fire()
    {
        Rigidbody2D bulletInstance = Instantiate(projectile, Gun.position, transform.rotation) as Rigidbody2D;
        bulletInstance.name += name;
        myBullet = bulletInstance.name;
        
        bulletInstance.velocity = transform.up * bulletSpeed;
        coundown = 5f;
        IsBulletAlive = true;
    }
}
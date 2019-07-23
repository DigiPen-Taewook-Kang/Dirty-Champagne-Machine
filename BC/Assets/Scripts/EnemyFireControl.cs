using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireControl : MonoBehaviour
{
    public float bulletSpeed = 10f;
    private float coundown = 1f;

    public Transform Gun;
    public Rigidbody2D projectile;
    public bool IsBulletAlive;
    private string myBullet;

    void Start()
    {
        IsBulletAlive = false;
    }

    void Update()
    {
        if (IsBulletAlive == false)
        {
            coundown -= Time.deltaTime;
            if (coundown <= 0)
            {
                if(!GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameItemControl>().IsFreezeOn)
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
        Rigidbody2D bulletInstance = Instantiate(projectile, Gun.position, transform.rotation);
        bulletInstance.name += name;
        myBullet = bulletInstance.name;
        
        bulletInstance.velocity = transform.up * bulletSpeed;
        coundown = 1f;
        IsBulletAlive = true;
    }
}

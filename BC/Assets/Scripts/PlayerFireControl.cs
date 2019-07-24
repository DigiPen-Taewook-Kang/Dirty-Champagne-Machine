using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireControl : MonoBehaviour
{
    public int playerNum;
    public float bulletSpeed = 10f;
    public float firerate = 0.5f;
    private float nextfire = 0.0f;

    public Transform Gun;
    public Rigidbody2D projectile;

    private Vector3 FireDirection;

    // Sound Vars
    public AudioClip shotSoundClip;
    public AudioSource shotSource;

    [HideInInspector]
    public bool IsBulletAlive;
    private string myBullet;


    // Start is called before the first frame update
    void Start()
    {
        //shotSoundClip = Resources.Load<AudioClip>("Audio Assets/SFX/Shot-Sound");
        shotSource = GameObject.Find("Shooting Source").GetComponent<AudioSource>();
        shotSource.clip = shotSoundClip;

        bulletSpeed = 20f;
        FireDirection = new Vector3(0, 1, 0);
        IsBulletAlive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find(myBullet) == null)
        {
            IsBulletAlive = false;
        }

        if (Time.time > nextfire && !IsBulletAlive)
        {
            if (playerNum == 1 && Input.GetKeyDown(KeyCode.Z))
            {
                nextfire = Time.time + firerate;
                Fire();
            }
            else if(playerNum == 2 && Input.GetKeyDown(KeyCode.Keypad7))
            {
                nextfire = Time.time + firerate;
                Fire();
            }
        }
    }

    void Fire()
    {
        // Play Sound
        shotSource.Play();

        Rigidbody2D bulletInstance = Instantiate(projectile, transform.GetChild(0).transform.position, transform.rotation) as Rigidbody2D;
        bulletInstance.velocity = transform.up * bulletSpeed;
        bulletInstance.name += name;
        myBullet = bulletInstance.name;
        IsBulletAlive = true;
    }
}

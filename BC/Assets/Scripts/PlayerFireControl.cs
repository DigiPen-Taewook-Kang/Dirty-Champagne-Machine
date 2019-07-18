using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireControl : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float firerate = 0.5f;
    private float nextfire = 0.0f;

    public Transform Gun;
    public Rigidbody2D projectile;

    private Vector3 FireDirection;

    // Sound Variables
    public AudioClip ShotSound;
    public AudioSource ShotSoundSource;

    [HideInInspector]
    public bool IsBulletAlive;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize Sound Variables
        if (ShotSoundSource)
        {
            ShotSoundSource.clip = ShotSound;
        }

        FireDirection = new Vector3(0, 1, 0);
        IsBulletAlive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( (Input.GetKeyDown(KeyCode.Z) && Time.time > nextfire) && !IsBulletAlive)
        {
            nextfire = Time.time + firerate;
            Fire();
        }
    }

    void Fire()
    {
        // Play Sound
        if(ShotSoundSource)
        {
            ShotSoundSource.Play();
        }

        Rigidbody2D bulletInstance = Instantiate(projectile, Gun.position, transform.rotation) as Rigidbody2D;
        bulletInstance.velocity = transform.up * bulletSpeed;
        IsBulletAlive = true;
    }
}

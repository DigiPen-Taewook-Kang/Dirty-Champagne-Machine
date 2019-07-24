using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int playerNum;
    public float speed;

    private DIRECTION dir = 0;
    public bool isMoving = false;

    enum DIRECTION { NONE, LEFT, RIGHT, UP, DOWN };
    Vector2 dir_;

    // Sound Vars
    public AudioClip idleClip;
    public AudioClip moveClip;
    public AudioSource PlayerMovementAudioSource;

    private void Move()
    {
        float newspeed = Time.deltaTime * speed;
        switch (dir)
        {
            case DIRECTION.LEFT:
                {
                    transform.GetComponent<Rigidbody2D>().velocity = (new Vector3(-newspeed, 0, 0));
                    break;
                }
            case DIRECTION.RIGHT:
                {
                    transform.GetComponent<Rigidbody2D>().velocity = (new Vector3(newspeed, 0, 0));
                    break;
                }
            case DIRECTION.UP:
                {
                    transform.GetComponent<Rigidbody2D>().velocity = (new Vector3(0, newspeed, 0));
                    break;
                }
            case DIRECTION.DOWN:
                {
                    transform.GetComponent<Rigidbody2D>().velocity = (new Vector3(0, -newspeed, 0));
                    break;
                }
            default:
                {
                    dir = DIRECTION.NONE;
                    transform.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                    break;
                }
        }
    }

    private void GetDirection()
    {
        if (playerNum == 1)
        {
            if (Input.GetKey("left"))
            {
                if (transform.GetChild(0).GetComponent<CheckCollide>().IsCollide == false)
                {
                    dir = DIRECTION.LEFT;
                }
                gameObject.transform.up = Quaternion.Euler(0, 0, 90) * Vector3.up;

            }
            else if (Input.GetKey("right"))
            {
                if (transform.GetChild(0).GetComponent<CheckCollide>().IsCollide == false)
                {
                    dir = DIRECTION.RIGHT;
                }
                gameObject.transform.up = Quaternion.Euler(0, 0, -90) * Vector3.up;

            }
            else if (Input.GetKey("up"))
            {
                gameObject.transform.up = Quaternion.Euler(0, 0, 0) * Vector3.up;
                if (transform.GetChild(0).GetComponent<CheckCollide>().IsCollide == false)
                {
                    dir = DIRECTION.UP;
                }

            }
            else if (Input.GetKey("down"))
            {
                gameObject.transform.up = Quaternion.Euler(0, 0, 180) * Vector3.up;
                if (transform.GetChild(0).GetComponent<CheckCollide>().IsCollide == false)
                {
                    dir = DIRECTION.DOWN;
                }
            }
            else
            {
                dir = DIRECTION.NONE;
                transform.position = new Vector3(Round1D(transform.position.x), Round1D(transform.position.y), 0);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Keypad4))
            {
                if (transform.GetChild(0).GetComponent<CheckCollide>().IsCollide == false)
                {
                    dir = DIRECTION.LEFT;
                }
                gameObject.transform.up = Quaternion.Euler(0, 0, 90) * Vector3.up;

            }
            else if (Input.GetKey(KeyCode.Keypad6))
            {
                if (transform.GetChild(0).GetComponent<CheckCollide>().IsCollide == false)
                {
                    dir = DIRECTION.RIGHT;
                }
                gameObject.transform.up = Quaternion.Euler(0, 0, -90) * Vector3.up;

            }
            else if (Input.GetKey(KeyCode.Keypad8))
            {
                gameObject.transform.up = Quaternion.Euler(0, 0, 0) * Vector3.up;
                if (transform.GetChild(0).GetComponent<CheckCollide>().IsCollide == false)
                {
                    dir = DIRECTION.UP;
                }

            }
            else if (Input.GetKey(KeyCode.Keypad2))
            {
                gameObject.transform.up = Quaternion.Euler(0, 0, 180) * Vector3.up;
                if (transform.GetChild(0).GetComponent<CheckCollide>().IsCollide == false)
                {
                    dir = DIRECTION.DOWN;
                }
            }
            else
            {
                dir = DIRECTION.NONE;
                transform.position = new Vector3(Round1D(transform.position.x), Round1D(transform.position.y), 0);
            }
        }
    }

    public float Round1D(float value) //Return a number rounded to first decimal
    {
        value *= 10;
        value = Mathf.Round(value);
        return value / 10f;
    }

    private void Start()
    {
        PlayerMovementAudioSource = GameObject.Find("Player Movement Source").GetComponent<AudioSource>();

        // Init Sound Vars
        if (PlayerMovementAudioSource)
        {
            PlayerMovementAudioSource.clip = idleClip;
            PlayerMovementAudioSource.Play();
        }
    }

    private void Update()
    {
        Move();
    }

    //calculations
    private void FixedUpdate()
    {
        
        // Check isMoving
        float Velocity = GetComponent<Rigidbody2D>().velocity.magnitude;
        isMoving = (Velocity >= -float.Epsilon && Velocity < float.Epsilon) ? false : true;

        GetDirection();
           
         if(PlayerMovementAudioSource)
        {
            PlayerMovementAudioSource.clip = (isMoving) ? moveClip : idleClip;

            if(!PlayerMovementAudioSource.isPlaying)
            {
                PlayerMovementAudioSource.Play();
            }
        }
    }


}

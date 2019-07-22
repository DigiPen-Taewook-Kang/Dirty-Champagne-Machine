using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    private DIRECTION dir = 0;
    public bool isMoving = false;

    enum DIRECTION { NONE, LEFT, RIGHT, UP, DOWN };
    Vector2 dir_;

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
                    isMoving = false;
                    break;
                }
        }
    }

    private void GetDirection()
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

    public float Round1D(float value) //Return a number rounded to first decimal
    {
        value *= 10;
        value = Mathf.Round(value);
        return value / 10f;
    }

    private void Start()
    {}

    private void Update()
    {
        Move();
    }

    //calculations
    private void FixedUpdate()
    {
        if (!isMoving)
            GetDirection();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    public float speed;
    public int dir; //LRUD

    private void Move()
    {
        float newspeed = Time.deltaTime * speed;
        switch (dir)
        {
            case 1:
                {
                    transform.GetComponent<Rigidbody2D>().velocity = (new Vector3(-newspeed, 0, 0));
                    break;
                }
            case 2:
                {
                    transform.GetComponent<Rigidbody2D>().velocity = (new Vector3(newspeed, 0, 0));
                    break;
                }
            case 3:
                {
                    transform.GetComponent<Rigidbody2D>().velocity = (new Vector3(0, newspeed, 0));
                    break;
                }
            case 4:
                {
                    transform.GetComponent<Rigidbody2D>().velocity = (new Vector3(0, -newspeed, 0));
                    break;
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
        //dir = 4;
    }

    private void Update()
    {
        Move();
    }
}

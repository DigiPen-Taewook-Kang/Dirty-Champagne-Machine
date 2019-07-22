using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //change it to movement <- mono
    Rigidbody2D rb2d;

    float x_dir, y_dir;
    float timer = 3.0f;

    public int health = 1;

    List<Vector2> direction = new List<Vector2>();

    [SerializeField]
    LayerMask blockinglayer;

    public GameObject tank_explosion;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        direction.Add(new Vector2(0, 1));
        direction.Add(new Vector2(0, -1));
        direction.Add(new Vector2(1, 0));
        direction.Add(new Vector2(-1, 0));

        RandomDirection();

        tank_explosion.GetComponent<Animator>().enabled = false;
    }

    public void RandomDirection()
    {
        int rand = Random.Range(0, 4);

        if (!Physics2D.CircleCast(transform.position, 1f, direction[rand], blockinglayer))
        {
            RandomDirection();
        }
        else
        {
            rand += 1;
            GetComponent<MovementEnemy>().dir = rand;
            if (rand == 1)
            {
                gameObject.transform.up = Quaternion.Euler(0, 0, 90) * Vector3.up;
            }
            else if (rand == 2)
            {
                gameObject.transform.up = Quaternion.Euler(0, 0, -90) * Vector3.up;

            }
            else if (rand == 3)
            {
                gameObject.transform.up = Quaternion.Euler(0, 0, 0) * Vector3.up;
            }
            else if (rand == 4)
            {
                gameObject.transform.up = Quaternion.Euler(0, 0, 180) * Vector3.up;
            }
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            tank_explosion.transform.position = gameObject.transform.position;
            tank_explosion.GetComponent<Animator>().enabled = true;
        }
        else
        {
            RandomDirection();
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = 3.0f;
            RandomDirection();
        }
    }
}
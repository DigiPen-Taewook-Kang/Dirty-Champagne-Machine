using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    public float timer;
    private float elapsed;
    public Rigidbody2D Enemy;
    //-7, 1, 9
    // Start is called before the first frame update
    void Start()
    {
        timer = 3f;
        elapsed = timer;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed -= Time.deltaTime;
        if (elapsed <= 0)
        {
            Instantiate(Enemy, new Vector2(1, 23), transform.rotation);
            elapsed = timer;
        }
    }
}

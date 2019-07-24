using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEM_Shield : MonoBehaviour
{
    [SerializeField]
    GameObject Score500;
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
        if (collision.collider.name == "Player1")
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameItemControl>().IsShieldOn1 = true;

            Instantiate(Score500, transform.position, transform.rotation);
            Destroy(gameObject);
        }


        if (collision.collider.name == "Player2")
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameItemControl>().IsShieldOn2 = true;
            //print("ShiledOn 2");
            Instantiate(Score500, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}

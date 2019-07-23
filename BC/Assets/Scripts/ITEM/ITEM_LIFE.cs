using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEM_LIFE : MonoBehaviour
{
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
        if (collision.gameObject.name == "Player1")
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameItemControl>().Player1_Life += 1;

            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "Player2")
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameItemControl>().Player2_Life += 1;

            Destroy(gameObject);
        }
    }
}

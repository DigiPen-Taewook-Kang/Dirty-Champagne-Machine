using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEM_FREEZE : MonoBehaviour
{
    [SerializeField]
    GameObject Score500;
    public GameObject gameController;
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
        if (collision.collider.tag == "Player_Tank")
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameItemControl>().IsFreezeOn = true;

            Instantiate(Score500, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}

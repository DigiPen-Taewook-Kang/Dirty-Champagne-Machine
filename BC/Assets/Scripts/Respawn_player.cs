using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_player : MonoBehaviour
{
    [SerializeField]
    GameObject gameController;

    [SerializeField]
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
         gameController = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.FindGameObjectWithTag("Player_Tank"))
        {
            if(gameController.GetComponent<GameItemControl>().Player_Life > 0)
            {
                GameObject newPlayer = Instantiate(player, transform.position, Quaternion.identity);
                gameController.GetComponent<GameItemControl>().Player_Life -= 1;
            }
        }
    }
}

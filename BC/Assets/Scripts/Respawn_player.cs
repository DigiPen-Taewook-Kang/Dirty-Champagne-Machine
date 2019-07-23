using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_player : MonoBehaviour
{
    [SerializeField]
    GameObject gameController;

    public Rigidbody2D player1;
    public Rigidbody2D player2;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Player1"))
        {
            if (gameController.GetComponent<GameItemControl>().Player_Life > 0)
            {
                Rigidbody2D newPlayer = Instantiate(player1, new Vector3(-3, -1, 0), Quaternion.identity);
                gameController.GetComponent<GameItemControl>().Player_Life -= 1;
                newPlayer.name = "Player1";
            }
        }
        if (MainmenuSelector.mode == 2)
        {
            if (!GameObject.Find("Player2"))
            {
                if (gameController.GetComponent<GameItemControl>().Player_Life > 0)
                {
                    Rigidbody2D newPlayer = Instantiate(player2, new Vector3(5, -1, 0), Quaternion.identity);
                    gameController.GetComponent<GameItemControl>().Player_Life -= 1;
                    newPlayer.name = "Player2";
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_player : MonoBehaviour
{
    [SerializeField]
    GameObject gameController;

    public GameObject flash;

    public Rigidbody2D player1;
    public Rigidbody2D player2;

    private float timer1 = 0.5f;
    private float timer2 = 0.5f;
    private bool trigger_flash1 = true;
    private bool trigger_flash2 = true;

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
            if (gameController.GetComponent<GameItemControl>().Player1_Life > 0)
            {
                if (trigger_flash1)
                {
                    var temp = Instantiate(flash, new Vector3(-3, -1, 0), Quaternion.identity);
                    Destroy(temp, .5f);
                    trigger_flash1 = false;
                }

                timer1 -= Time.deltaTime;

                if (timer1 < 0)
                {
                    Rigidbody2D newPlayer = Instantiate(player1, new Vector3(-3, -1, 0), Quaternion.identity);
                    gameController.GetComponent<GameItemControl>().Player1_Life -= 1;
                    newPlayer.name = "Player1";
                    timer1 = .5f;
                    trigger_flash1 = true;
                }
            }
            if (MainmenuSelector.mode == 2)
            {
                if (!GameObject.Find("Player2"))
                {
                    if (gameController.GetComponent<GameItemControl>().Player2_Life > 0)
                    {
                        if (trigger_flash2)
                        {
                            var temp = Instantiate(flash, new Vector3(5, -1, 0), transform.rotation);
                            Destroy(temp, 0.5f);
                            trigger_flash2 = false;
                        }

                        timer2 -= Time.deltaTime;

                        if (timer2 < 0)
                        {
                            Rigidbody2D newPlayer = Instantiate(player2, new Vector3(5, -1, 0), Quaternion.identity);
                            gameController.GetComponent<GameItemControl>().Player2_Life -= 1;
                            newPlayer.name = "Player2";
                            timer2 = .5f;
                            trigger_flash2 = true;
                        }
                    }
                }
            }
        }
    }
}

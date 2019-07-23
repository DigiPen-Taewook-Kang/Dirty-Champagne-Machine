using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    Animator m_Animator;
    SpriteRenderer m_SpriteRenderer;
    public int playerNum;

    public bool isActivated = true;
    public float timer = 5.0f;
    public bool isTimerOn = true;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player_Tank"))
        {
            if (isTimerOn)
            {
                TriggerTimer();
                timer -= Time.deltaTime;

                if (timer < 0)
                {
                    isTimerOn = false;
                    timer = 5.0f;
                }

                if (playerNum == 1 && GameObject.Find("Player1"))
                    transform.position = GameObject.Find("Player1").transform.position;
                else if (playerNum == 2 && GameObject.Find("Player2"))
                    transform.position = GameObject.Find("Player2").transform.position;
            }

            if (!isTimerOn)
            {
                m_SpriteRenderer.enabled = false;
                m_Animator.enabled = false;
            }
        }
    }

    public void TriggerTimer()
    {
        //timer = 5.0f;
        isTimerOn = true;
        m_Animator.enabled = true;
        m_SpriteRenderer.enabled = true;

    }
}
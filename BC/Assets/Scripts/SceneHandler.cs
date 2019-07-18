using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public bool isGameOver;
    private float timer = 3f;
    void Start()
    {
        isGameOver = false;
        timer = 3f;
    }

    void Update()
    {
        Debug.Log(timer);
        if(isGameOver)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
            SceneManager.LoadScene("GameOver");
    }
}

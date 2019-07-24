using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreTimedDeath : MonoBehaviour
{

    [SerializeField]
    float Timer = 1.6f;



    // Start is called before the first frame update
    void Start()
    {
        //Timer = 2.0f;    
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer<0)
        {
            Destroy(gameObject);
        }
        Timer -= Time.deltaTime;
       
    }
}

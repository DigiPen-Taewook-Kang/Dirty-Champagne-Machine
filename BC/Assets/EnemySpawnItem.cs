using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnItem : MonoBehaviour
{

    public bool HadItem;

    float timer;
    Color[] color = new Color[2];
    int index = 0;

    private SpriteRenderer myrenderer;


    // Start is called before the first frame update
    void Start()
    {
        color[0] = Color.red;
        color[1] = Color.white;

        myrenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (HadItem)
        {

            timer += Time.deltaTime;
            if(timer > 0.1f)
            {
                if (++index == color.Length)
                    index = 0;
                myrenderer.color = color[index];
                timer=0;
            }
        }
    }
}

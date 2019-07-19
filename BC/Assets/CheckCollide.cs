using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollide : MonoBehaviour
{
    [HideInInspector]
    public bool IsCollide = false;
    [HideInInspector]
    public string CollidingObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IsCollide = true;
        CollidingObj = other.tag;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsCollide = false;
    }
}

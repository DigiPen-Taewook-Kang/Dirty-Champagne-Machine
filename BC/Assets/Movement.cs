﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;

    public bool isSlippery = false;

    protected bool isMoving = false;

    float h, v;
    Rigidbody2D rb2d;

    protected IEnumerator MoveHorizontal(float movementHorizontal, Rigidbody2D rb2d)
    {
        isMoving = true;

        transform.position = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));

        Quaternion rotation = Quaternion.Euler(0, 0, -movementHorizontal * 90f);
        transform.rotation = rotation;


        if (GameObject.FindGameObjectWithTag("Player_Gun").GetComponent<CheckCollide>().IsCollide == false)
        {


            float movementProgress = 0f;
            Vector2 movement, endPos;

            while (movementProgress < Mathf.Abs(movementHorizontal))
            {
                movementProgress += speed * Time.deltaTime;
                movementProgress = Mathf.Clamp(movementProgress, 0f, 1f);
                movement = new Vector2(speed * Time.deltaTime * movementHorizontal, 0f);
                if (!isSlippery)
                    endPos = rb2d.position + movement;
                else
                    endPos = rb2d.position + movement * 2;


                if (movementProgress == 1)
                    endPos = new Vector2(Mathf.Round(endPos.x), endPos.y);


                rb2d.MovePosition(endPos);

                yield return new WaitForFixedUpdate();
            }
        }
        isMoving = false;
    }

    protected IEnumerator MoveVertical(float movementVertical, Rigidbody2D rb2d)
    {
        isMoving = true;

        transform.position = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));

        Quaternion rotation;

        if (movementVertical < 0)
        {
            rotation = Quaternion.Euler(0, 0, movementVertical * 180f);
        }
        else
        {
            rotation = Quaternion.Euler(0, 0, 0);
        }
        transform.rotation = rotation;

        if (GameObject.FindGameObjectWithTag("Player_Gun").GetComponent<CheckCollide>().IsCollide == false)
        {


            float movementProgress = 0f;
            Vector2 endPos, movement;

            while (movementProgress < Mathf.Abs(movementVertical))
            {

                movementProgress += speed * Time.deltaTime;
                movementProgress = Mathf.Clamp(movementProgress, 0f, 1f);

                movement = new Vector2(0f, speed * Time.deltaTime * movementVertical);
                if (!isSlippery)
                    endPos = rb2d.position + movement;
                else
                    endPos = rb2d.position + movement * 2;

                if (movementProgress == 1)
                    endPos = new Vector2(endPos.x, Mathf.Round(endPos.y));


                rb2d.MovePosition(endPos);

                yield return new WaitForFixedUpdate();

            }
        }
        isMoving = false;
    }




    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (h != 0 && !isMoving)
            StartCoroutine(MoveHorizontal(h, rb2d));
        else if (v != 0 && !isMoving)
            StartCoroutine(MoveVertical(v, rb2d));
    }

    void Update()
    {


            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
        

    }


}

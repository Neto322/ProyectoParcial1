using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterController
{
    [SerializeField]
    float speed;

    [SerializeField]
    float jumpforce,jumpDelay;

    [SerializeField]
    float gravity;

    [SerializeField]
    float fallmultiplier;

     float jumpTimer;

     [SerializeField]
     float turntime;

     float timer = 0;

     [SerializeField]
     float movetime;

     float moveTimer = 0;

    [SerializeField]
     float horizontal;
    new void Awake()
    {
        base.Awake();


      
    }

    void Update()
    {

        if(timer > turntime)
        {
            jumpTimer = Time.time + jumpDelay;

            turntime = timer + turntime;

        }
        else{
            
            timer += Time.time * Time.deltaTime;
        }

        if(moveTimer > movetime)
        {
            if(horizontal == 1)
            {
                horizontal = -1;
            }
            else
            {
                horizontal = 1;

            }
            movetime = moveTimer + movetime;
        }
        else
        {
            moveTimer += Time.time * Time.deltaTime;
        }

        Debug.Log(turntime);
    }

    void FixedUpdate() 
    {
        CalculateMovement(speed); 

        CalculatePhysics(gravity , fallmultiplier);

        Rotate(horizontal);

        if(jumpTimer > Time.time &&  rb.IsTouching(ground))
        {
            Saltar(jumpforce,jumpTimer);

        }
    }
}

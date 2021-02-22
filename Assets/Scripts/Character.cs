using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : CharacterController
{
   




    [SerializeField]
    float speed;

    [SerializeField]
    float aceleration;


    




    [SerializeField]
    float jumpforce,jumpDelay;

    float jumpTimer;


    [SerializeField]
    float gravity;

    [SerializeField]
    float fallmultiplier;


    [SerializeField]
    float incremental;


    void Start()
    {


    }

    new void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {

        if(input.Ground.Jump.triggered)
        {
            jumpTimer = Time.time + jumpDelay;
        }

     

        if(Moving)
        {
            incremental += aceleration * Time.deltaTime;
        }

        else{

            incremental -= aceleration * Time.deltaTime;

            
        }

        incremental = Mathf.Clamp(incremental,0.0f,speed);
     
    }

    void FixedUpdate() 
    {
        CalculateMovement(incremental); 

        CalculatePhysics(gravity , fallmultiplier);

        Rotate();

        if(jumpTimer > Time.time &&  rb.IsTouching(ground))
        {
            Saltar(jumpforce,jumpTimer);

        }
    }



  

   


    }



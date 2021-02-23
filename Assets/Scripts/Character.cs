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


    float incremental;

    float escalar;

    [SerializeField]
    Animator anim;

    float horizontal;
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
        transform.position = new Vector3(transform.position.x,transform.position.y,0);
        
        if(input.Ground.Jump.triggered)
        {
            jumpTimer = Time.time + jumpDelay;
        }

        horizontal = input.Ground.Move.ReadValue<float>();


        if(Moving)
        {
            incremental += aceleration * Time.deltaTime;
        }

        else{

            incremental -= aceleration * Time.deltaTime;

            
        }

        incremental = Mathf.Clamp(incremental,0.0f,speed);

        escalar = incremental / speed;
        anim.SetFloat("moveX",escalar);
    }

    void FixedUpdate() 
    {
        CalculateMovement(incremental); 

        CalculatePhysics(gravity , fallmultiplier);

        Rotate(horizontal);

        if(jumpTimer > Time.time &&  rb.IsTouching(ground))
        {
            Saltar(jumpforce,jumpTimer);

        }
    }

    bool Moving => Mathf.Abs(horizontal) > 0;

  

   


    }



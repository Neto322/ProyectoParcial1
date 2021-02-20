using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
     Rigidbody2D rb;


    Input input;


    [SerializeField]
    float speed;

    [SerializeField]
    float aceleration;

    float horizontal;

    [SerializeField]
    float maxSpeed;

    bool changingdirection;

    [SerializeField]
    float lineardrag;

    float rotate;

    [SerializeField]
    float jumpforce,jumpDelay;

    float jumpTimer;

    [SerializeField]
    ContactFilter2D ground;

    [SerializeField]
    float gravity;

    [SerializeField]
    float fallmultiplier;


    float incremental;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    private void Awake() {
        input = new Input();
    }

    private void OnDisable() {
        input.Disable();
    }
   private void OnEnable() {
        input.Enable();
    }

    // Update is called once per frame
    void Update()
    {

        if(input.Ground.Jump.triggered)
        {
            jumpTimer = Time.time + jumpDelay;
        }

        horizontal = input.Ground.Move.ReadValue<float>();

        

        
        rotate += horizontal * 16;




        rotate = Mathf.Clamp(rotate,0,180);



        transform.rotation = Quaternion.Euler(0,rotate,0);

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
        CalcularMovimiento(); 
        CalcularFisica();

        if(jumpTimer > Time.time &&  rb.IsTouching(ground))
        {
            Saltar();

        }
    }

    void CalcularMovimiento()
    {
        transform.position += -transform.right * incremental  * Time.deltaTime;
       


    }

    void CalcularFisica()
    {

        if(rb.IsTouching(ground))
        {            
            

            rb.gravityScale = 0;


        }
        else
        {

            rb.gravityScale = gravity;

           if(rb.velocity.y < 0)
            {
                rb.gravityScale = gravity * fallmultiplier;
            }
            else if (rb.velocity.y > 0 && !input.Ground.Jump.triggered)
            {
                rb.gravityScale = gravity * (fallmultiplier / 2);

            }
          
        }
    
    }

    void Saltar()
    {
        rb.AddForce(Vector2.up * jumpforce,ForceMode2D.Impulse);

        jumpTimer = 0;
       

    }

    bool Moving => Mathf.Abs(horizontal) > 0;

    }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class CharacterController : MonoBehaviour
{
   protected Rigidbody2D rb;

   protected Input input;

   [SerializeField]
   protected ContactFilter2D ground;

   [SerializeField]
   protected float life;


    float rotate;





       protected void Awake() {
        input = new Input();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDisable() {
        input.Disable();
    }
   private void OnEnable() {
        input.Enable();
    }

    protected void CalculateMovement(float incremental)
    {
        transform.position += -transform.right * incremental  * Time.deltaTime;

    }

    protected void CalculatePhysics(float gravity , float fallmultiplier)
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

    protected void Rotate(float horizontal)
    {

        

        
        rotate += horizontal * 35;




        rotate = Mathf.Clamp(rotate,0,180);



        transform.rotation = Quaternion.Euler(0,rotate,0);

    }

    protected void Saltar(float jumpforce, float jumpTimer)
    {
        rb.AddForce(Vector2.up * jumpforce ,ForceMode2D.Impulse);

        jumpTimer = 0;
       

    }
   


}

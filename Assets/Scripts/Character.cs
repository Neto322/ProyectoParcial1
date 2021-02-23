using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using TMPro;

using UnityEngine.SceneManagement;


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

    [SerializeField]
    GameObject chems;

    float horizontal;

    [SerializeField]
    float score;


    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    TextMeshProUGUI text2;

    [SerializeField]
    AudioClip[] sonidos;

    AudioSource sound;


    void Start()
    {
       
        life = 3;

        text2.text = "Vida:" + "<color=#ff0000>" + life + "</color>";

        text.text = "Puntos:" + "<color=#39a015>" + score + "</color>";

        sound = GetComponent<AudioSource>();


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

        anim.SetFloat("velocityY", rb.velocity.y);

        if(rb.IsTouching(ground))
        {
            anim.SetBool("jump", false);
        }
        else{
            anim.SetBool("jump", true);

        }         

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

        if(life <= 0)
        {
            Instantiate(chems, transform.position,Quaternion.identity);
            Destroy(gameObject);

            SceneManager.LoadScene(1);

        }

        text.text = "Puntos:" + "<color=#39a015>" + score + "</color>";

        text2.text = "Vida:" + "<color=#ff0000>" + life + "</color>";

        


    }

    bool Moving => Mathf.Abs(horizontal) > 0;

  

    private void OnTriggerEnter2D(Collider2D other) {


        if(other.tag == "Enemy")
        {
            life -= 1;
           
            if(life != 0)
            Destroy(other.gameObject);

            sound.clip = sonidos[1];
            sound.Play();


        }

        if(other.tag == "Coin")
        {

            score = score + other.gameObject.GetComponent<coin>().puntos; 

           
            other.gameObject.GetComponent<coin>().Consume();


          
            sound.clip = sonidos[2];
            sound.Play();
            


            
        }

  if(other.tag == "Sol")
  {
      Debug.Log("Muerte" + life);
    life = -1;

  }

        
        if(other.tag == "Soda")
        {

            life +=  other.gameObject.GetComponent<coin>().puntos; 

        
            other.gameObject.GetComponent<coin>().Consume();

            sound.clip = sonidos[0];
            sound.Play();
          
           

   


            
        }

    }


    }



using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.


using UnityEngine.Networking;

public class Movementkart : NetworkBehaviour 
{CharacterController characterController;

   public Animator animator;
public static float speed = 5f;
    public static float totalspeed = 0f;
    public static float rotationspeed = 20f;
public bool acclerated;
public  float accelaration=0;
private bool backward=false; 
private bool backwardfix=false; 
 public GameObject Lw;
 public GameObject Rw;
 public GameObject Rbw;
public GameObject Lbw;

 public  GameObject rainbow;
 public  GameObject wind;
    Rigidbody Rigidbody;
  public Transform bomb;
    public AudioSource audioSource;
    public int startingPitch = 1;
    private Rigidbody rb;
 private bool wallcollided;
 public Vector3 Movement;

 public  bool stopanimation=false;


 public static GameObject thisgameobject;


 public  int forcedstop=1;
    //floqt

  float translation;
   float rotation;
   Vector3 m_EulerAngleVelocity;
    void Start()
    {
        Rigidbody = transform.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = startingPitch;
        thisgameobject =this.gameObject;
        rb=this.GetComponent<Rigidbody>();
         m_EulerAngleVelocity = new Vector3(0, 100, 0);
  
    }
  private void Update() {
  
  }
    void FixedUpdate()
    {

        acclerated =false;
    
       if (Input.GetKey(KeyCode.UpArrow) && stopanimation==false)
        {
           if(!wallcollided)
                if (totalspeed < 0.85f)
                {
                  
                    accelaration = accelaration + 0.04f;
                    if (audioSource.pitch < 1.7f)
                    {
                        audioSource.pitch = audioSource.pitch + accelaration/1000;
                    }
                   
                }
            transform.Translate(0.0f,0.0f,0.0f+Time.deltaTime*speed*accelaration*forcedstop);
            acclerated=true;
            backward=false;
           
            totalspeed = Time.deltaTime * speed * accelaration * forcedstop;
            
           
        }
        if (Input.GetKey(KeyCode.DownArrow) && accelaration >1f )
        {
            accelaration = accelaration - 0.05f;
        }
            if (Input.GetKey(KeyCode.DownArrow) && accelaration <1f )
        {
          
                transform.Translate(0.0f,0.0f,0.0f-Time.deltaTime*speed*accelaration); 
                backward=true;
              

        }

          if(acclerated==false && accelaration>1 && backward==false )
        {
          accelaration=accelaration-0.05f;
            if (audioSource.pitch > 1f)
            {
                audioSource.pitch = audioSource.pitch -( accelaration / 1000);
            }


            transform.Translate(0.0f,0.0f,0.0f+Time.deltaTime*speed*accelaration);

          if (Input.GetKey(KeyCode.RightArrow) && stopanimation==false )
        {
          transform.Rotate(0.0f,0.0f+Time.deltaTime*speed*accelaration,0.0f,Space.Self);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && stopanimation==false)
        {
    
            transform.Rotate(0.0f,(0.0f+Time.deltaTime*speed*10)*(-1),0.0f,Space.Self);
        }

            totalspeed = Time.deltaTime * speed * accelaration *  forcedstop - 2f;
        }
       
        if(acclerated==false && accelaration>=1f && backward==true )
        {
          
          backwardfix=true;
          accelaration=accelaration-0.05f;
            if (audioSource.pitch > 1f)
            {
                audioSource.pitch = audioSource.pitch - (accelaration / 1000);
            }
            if (Input.GetKey(KeyCode.DownArrow) && stopanimation==false)
            {
              
              
                    transform.Translate(0.0f,0.0f,0.0f+Time.deltaTime*speed*accelaration); 
                    if (accelaration==1f)
                    {
                      backwardfix=true;
              
                    } 

                    
                   
                  

            }
            
          
         

           if(accelaration<1.0f)
           {
         
           }

                if (Input.GetKey(KeyCode.RightArrow) && stopanimation==false )
              {
                transform.Rotate(0.0f,0.0f-Time.deltaTime*speed*accelaration,0.0f,Space.Self);
              }

              if (Input.GetKey(KeyCode.LeftArrow) && stopanimation==false)
              {
          
                  transform.Rotate(0.0f,(0.0f+Time.deltaTime*speed*10)*(-1),0.0f,Space.Self);
              }
          

        }


      
        
        //wheel animation truning
         //if (Input.GetKey(KeyCode.RightArrow) && stopanimation==false)
         //{animator.SetBool("right",true);}
        // else
         //{animator.SetBool("right",false);}


        /* if (Input.GetKey(KeyCode.LeftArrow) && stopanimation==false)
         {
             
            //animator.SetBool("left",true);
         }
         else
         {
            // animator.SetBool("left",false);
         }*/
         //
       
         

         if (Input.GetKey(KeyCode.RightArrow) && acclerated==true && stopanimation==false)
        {
           
            transform.Rotate(0.0f,0.0f+Time.deltaTime*speed*10,0.0f,Space.Self);
      
        }
         if (Input.GetKey(KeyCode.LeftArrow) && acclerated==true && stopanimation==false)
        {
            transform.Rotate(0.0f,(0.0f+Time.deltaTime*speed*10)*(-1),0.0f,Space.Self);
        }

       
          
       
        
       if (Input.GetKey(KeyCode.KeypadEnter))
        {
             transform.Rotate(0.0f,0.0f+Time.deltaTime*6.0f*100,0.0f,Space.Self);
             this.transform.position=Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z+20.0f) , Time.deltaTime * 6f * accelaration * transform.GetComponent<Movementkart>().accelaration);
        }

         if(collidingmissile.boom==true && this.gameObject.tag=="track" )
        {
           transform.Rotate(0.0f,0.0f+Time.deltaTime*6.0f*92,0.0f,Space.Self);
             this.transform.position=Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z+20.0f) , Time.deltaTime * 6f  );
        }
     
     if (wallcollided)
     {

            
          
            if (accelaration>0.1f)
       {
        accelaration=accelaration-0.05f;
                if (audioSource.pitch > 1f)
                {
                    audioSource.pitch = audioSource.pitch - (accelaration / 1000);
                    print("p=" + audioSource.pitch);
                }


            }
       if((Time.deltaTime * speed * accelaration)>0.6f)
            {
                accelaration=accelaration- ((Time.deltaTime * speed * accelaration)/100*100);
                if (audioSource.pitch > 1f)
                {
                    audioSource.pitch = audioSource.pitch - (accelaration / 1000);
                    print("p=" + audioSource.pitch);
                }

            }



        }
     else
     {
      
     }



}
 
   private void OnCollisionEnter(Collision other) {

         if(other.collider.tag == "walls")
              {
              wallcollided =true;
              }

           
        
      }
   public void OnCollisionExit(Collision other){

      if(other.collider.tag == "walls")
              {
              wallcollided =false;
              }
           }



     



//activer-desactiver le gameobject + time






}  



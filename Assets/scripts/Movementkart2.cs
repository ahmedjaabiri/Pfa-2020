using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class Movementkart2 : MonoBehaviour
{CharacterController characterController;

   public Animator animator;
public static float speed = 5f;
public static float rotationspeed = 20f;
public bool acclerated;
public static float accelaration=1;
private bool backward=false; 
 public GameObject Lw;
 public GameObject Rw;
 public GameObject Rbw;
public GameObject Lbw;
 public  GameObject rainbow;
 public  GameObject wind;
 public Transform missile;
 public Transform missilaux;
  public Transform bomb;
 public Transform banana;
 private Rigidbody rb;
 private bool wallcollided;
 public Vector3 Movement;

 public bool stopanimation=false;

 public string[] ability;
 public string s_ability;
 public static GameObject thisgameobject;
 private GameObject shild;

 private int forcedstop=1;
 private bool isshilded=false;

  float translation;
   float rotation;
   Vector3 m_EulerAngleVelocity;
    void Start()
    {
        thisgameobject=this.gameObject;
        ability=new string[4];
        ability[0]="shild";ability[1]="missile";ability[2]="boost";ability[3]="banana";
        rb=this.GetComponent<Rigidbody>();
         m_EulerAngleVelocity = new Vector3(0, 100, 0);
         missilaux=missile;
    }
  private void Update() {
  }
    void FixedUpdate()
    {
       
       
      acclerated=false;
    
       if (Input.GetKey(KeyCode.W) && stopanimation==false)
        {
           if(!wallcollided)
            accelaration=accelaration+0.02f;
            transform.Translate(0.0f,0.0f,0.0f+Time.deltaTime*speed*accelaration*forcedstop);
            acclerated=true;
            backward=false;
        }
         if (Input.GetKey(KeyCode.S) && stopanimation==false)
        {
            backward=true;
            accelaration=accelaration+0.02f;
            transform.Translate(0.0f,0.0f,0.0f-Time.deltaTime*speed*accelaration);
            acclerated=true;
        }

          if(acclerated==false && accelaration>1 && backward==false )
        {
          accelaration=accelaration-0.05f;
         
          transform.Translate(0.0f,0.0f,0.0f+Time.deltaTime*speed*accelaration);
          if (Input.GetKey(KeyCode.A) && stopanimation==false )
        {
          transform.Rotate(0.0f,0.0f+Time.deltaTime*speed*accelaration,0.0f,Space.Self);
        }
        if (Input.GetKey(KeyCode.D) && stopanimation==false)
        {
    
            transform.Rotate(0.0f,(0.0f+Time.deltaTime*speed*10)*(-1),0.0f,Space.Self);
        }
          

        }
         if(acclerated==false && accelaration>1 && backward==true && stopanimation==false )
        {
          accelaration=accelaration-0.05f;
     
          transform.Translate(0.0f,0.0f,0.0f+speed*accelaration*-1);
        }
        
        //wheel animation truning
         if (Input.GetKey(KeyCode.A) && stopanimation==false)
         {
             
            if(Lw.transform.rotation.eulerAngles.y  < 320.0f){
             Lw.transform.Rotate(0.0f,0.0f+Time.deltaTime*200.0f,0.0f);
             Rw.transform.Rotate(0.0f,0.0f+Time.deltaTime*200.0f,0.0f);
            }
         }else
         {
              if(Lw.transform.rotation.eulerAngles.y  > 270.0f){
             Lw.transform.Rotate(0.0f,0.0f-Time.deltaTime*200.0f,0.0f);
             Rw.transform.Rotate(0.0f,0.0f-Time.deltaTime*200.0f,0.0f);
            }
         }


         if (Input.GetKey(KeyCode.D) && stopanimation==false)
         {
             
            if(Lw.transform.rotation.eulerAngles.y  > 220.0f){
             Lw.transform.Rotate(0.0f,0.0f-Time.deltaTime*200.0f,0.0f);
             Rw.transform.Rotate(0.0f,0.0f-Time.deltaTime*200.0f,0.0f);
            }
         }
         else
         {
              if(Lw.transform.rotation.eulerAngles.y  < 270.0f){
             Lw.transform.Rotate(0.0f,0.0f+Time.deltaTime*200.0f,0.0f);
             Rw.transform.Rotate(0.0f,0.0f+Time.deltaTime*200.0f,0.0f);
            }
         }
         //
       
         

         if (Input.GetKey(KeyCode.A) && acclerated==true && stopanimation==false)
        {
           
            transform.Rotate(0.0f,0.0f+Time.deltaTime*speed*10,0.0f,Space.Self);
      
        }
         if (Input.GetKey(KeyCode.D) && acclerated==true && stopanimation==false)
        {
            transform.Rotate(0.0f,(0.0f+Time.deltaTime*speed*10)*(-1),0.0f,Space.Self);
        }

       if (Input.GetKeyDown(KeyCode.X))
        {
          if(s_ability!="")
          {
            if(s_ability=="missile")
            {
               missile=missilaux;
               missile=Instantiate(missile, new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
               missile.GetComponent<findandhit>().objt=this.gameObject;
               
            }
            if (s_ability=="shild")
            {
              shild = FindObject(this.gameObject,"Shild");
              StartCoroutine(activateshild(shild,10));
            }
            if (s_ability=="boost")
            {
            StartCoroutine(boost());
            }
             if (s_ability=="banana")
            {
            
           Instantiate(banana, new Vector3(transform.position.x,transform.position.y,transform.position.z-4f), transform.rotation);
            }
            
           
            s_ability="";
          }
          
             
        }
        
       if (Input.GetKey(KeyCode.KeypadEnter))
        {
             transform.Rotate(0.0f,0.0f+Time.deltaTime*6.0f*100,0.0f,Space.Self);
             this.transform.position=Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z+20.0f) , Time.deltaTime * 6f * accelaration );
        }

         if(collidingmissile.boom==true && this.gameObject.tag=="track" )
        {
           transform.Rotate(0.0f,0.0f+Time.deltaTime*6.0f*92,0.0f,Space.Self);
             this.transform.position=Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z+20.0f) , Time.deltaTime * 6f  );
        }
     
     if (wallcollided)
     {
       if(accelaration>0.1f)
       {
        accelaration=accelaration-0.05f;
    
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



      private void OnTriggerEnter(Collider other) {

        //sandou9 ability
        if(other.tag == "box")
              {
              s_ability=ability[Random.Range(0, ability.Length)];
       
           
              }   
        if(other.tag=="banana" && isshilded==false)
              {
                StartCoroutine(attacked(other.gameObject));
              }  
          if(other.tag=="banana" && isshilded==false)
              {
                StartCoroutine(attacked(other.gameObject));
              }  

          if(other.tag == "missile" && 
          (other.GetComponent<findandhit>().objt!=this.gameObject )
          && isshilded==false)
              {
               
                 StartCoroutine(attacked(other.gameObject));
                
              }       

         }

public static GameObject FindObject( GameObject parent, string name)
              {
                  Transform[] trs= parent.GetComponentsInChildren<Transform>(true);
                  foreach(Transform t in trs){
                      if(t.name == name){
                            return t.gameObject;
                      }
                  }
                  return null;
              }

//activer-desactiver le gameobject + time
 IEnumerator activateshild(GameObject gameObject,int time)
    {
        gameObject.SetActive(true);
        isshilded=true;
   
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        isshilded=false;
    }

IEnumerator boost()
    {
        Movementkart.speed=Movementkart.speed+3f;
        yield return new WaitForSeconds(1);
       
        Movementkart.speed=Movementkart.speed-3f;
    }

IEnumerator attacked(GameObject other)
{
   animator.SetBool("attacked",true);
   forcedstop=0;
   accelaration=0;
   stopanimation=true;
   GameObject boom;
   if(other.gameObject.tag=="missile")
   {
     
     boom = FindObject(other.gameObject,"boom");
      boom.SetActive(true);
      other.GetComponent<Animator>().SetBool("destroyed",true);

   }
   yield return new WaitForSeconds(1);
   animator.SetBool("attacked",false);
   forcedstop=1;
   stopanimation=false;

    Destroy(other);
}




}  



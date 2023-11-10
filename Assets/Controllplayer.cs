using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Controllplayer : NetworkBehaviour
{ public string[] ability;
 public string s_ability;

   public Animator animator; 
   public Animator powerbox;
   public Image m_Image;
 private bool isshilded=false;
  public GameObject missile1;
 public GameObject missilaux;
  public GameObject banana;
  private GameObject shild;
  public GameObject shildent;
  public  int thisid;
  public static int cur_lap=0;

    public playerui pui;
    // Start is called before the first frame update
    void Start()
    {
        pui.setanim(powerbox);
        pui.setimage(m_Image);
        thisid=idgenerator.id;
        idgenerator.id++;
        ability=new string[3];
        ability[0]="banana";ability[1]="missile";ability[2]="shild";/*ability[3]="banana"*/;
        missilaux = missile1;
    }
     public override void OnStartLocalPlayer()
 {
      base.OnStartLocalPlayer();
      gameObject.name = "Local";
 }

    // Update is called once per frame
  
    public void FixedUpdate() {
 
    
      if (Input.GetKeyDown(KeyCode.Space))
        {
           pui.deanimate();
          if(s_ability!="")
          {
            if(s_ability=="missile")
            {
           
              Cmdmissilup();
            }
            if (s_ability=="shild")
            {
       
              //shild = FindObject(this.gameObject,"Shild");
            Cmdshild();
            }
            if (s_ability=="boost")
            {
            StartCoroutine(boost());
            }
             if (s_ability=="banana")
            {
              
            Cmdbananaup();
           
            }
            
           
            s_ability="";
          }
          
             
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

     private void OnTriggerEnter(Collider other) {

       
          if (other.tag == "speedup")
        {
            StartCoroutine(boost());
        }
        //sandou9 ability
        if (other.tag == "box")
              {
                pui.deanimate();
                int ran=Random.Range(0, ability.Length);
              s_ability=ability[ran];
              pui.animate(ran);
           
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
          other.GetComponent<findandhit>().id!=thisid
          && other.GetComponent<findandhit>().id != 15
          && isshilded==false)
              {

                 StartCoroutine(attacked(other.gameObject));
                 
                
              }
            if (other.tag == "missile" &&
           other.GetComponent<findandhit>().id != thisid
           && other.GetComponent<findandhit>().id != 15
           && isshilded == true)
            {

            transform.GetComponent<Movementkart>().forcedstop = 1;
            transform.GetComponent<Movementkart>().stopanimation = false;
                Destroy(other.gameObject);
                GetComponent<lapscript>().setmissile(0);


        }

    }


IEnumerator attacked(GameObject other)
{
   animator.SetBool("attacked",true);
   transform.GetComponent<Movementkart>().forcedstop=1;
        transform.GetComponent<Movementkart>().accelaration=0;
      //  transform.GetComponent<Movementkart>().stopanimation=true;
   GameObject boom;
   if(other.gameObject.tag=="missile")
   {
     
      boom = FindObject(other.gameObject,"boom");
      boom.SetActive(true);
      other.GetComponent<Animator>().SetBool("destroyed",true);
      

   }
   yield return new WaitForSeconds(1);
     animator.SetBool("attacked",false);
     transform.GetComponent<Movementkart>().forcedstop = 1;
     transform.GetComponent<Movementkart>().stopanimation=false;
     Destroy(other);
        GetComponent<lapscript>().setmissile(0);

    }

[Command]
void Cmdmissilup()
{
        if (isClient)
        {
            Rpcmissilup();
        }
}
 [ClientRpc]
void Rpcmissilup()
{
       // missile1 = missilaux;
        GameObject missile = (GameObject)Instantiate(missile1, this.transform.position , Quaternion.identity);
        missile.GetComponent<findandhit>().id = thisid;
        //NetworkServer.Spawn(missile);
}
    [Command]
void Cmdbananaup()
{
  GameObject bananax=Instantiate(banana, transform.Find("bananaspaner").position, transform.rotation);
  NetworkServer.Spawn(bananax);
}
[Command]
void Cmdshild()
{
 Rpcshild();
}
[ClientRpc]
void Rpcshild()
{
        StartCoroutine(activateshild(shild, 10));
    }
 IEnumerator activateshild(GameObject gameObject,int time)
    {
        GameObject shildentx = Instantiate (shildent,this.transform.position,Quaternion.Euler (0f, 0f, 0f)) as GameObject;
        shildentx.transform.parent=this.gameObject.transform ;
       
        isshilded=true;
   
        yield return new WaitForSeconds(time);
       // gameObject.SetActive(false);
        NetworkServer.Destroy(shildentx);
        isshilded=false;
    }

IEnumerator boost()
    {
        Movementkart.speed=Movementkart.speed+3f;
        yield return new WaitForSeconds(1);
       
        Movementkart.speed=Movementkart.speed-3f;
    }

}

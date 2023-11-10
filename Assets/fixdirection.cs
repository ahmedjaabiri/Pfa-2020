using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixdirection : MonoBehaviour
{
    public static GameObject thisgameobject;
    // Start is called before the first frame update
          float rotate;
             float acceleration=50.0f;
 
         GameObject Parent;
         GameObject Findandhit;
         GameObject one,two,three,four,five;
         Transform[] components;

            public Transform[] waypoints;
             private float moveSpeed = 10f;

    private int waypointIndex = 0;
         bool turn=false;
         bool firstcolliion=false;
    void Start()
    {
        thisgameobject=this.gameObject;
           Findandhit=this.transform.parent.GetComponent<findandhit>().objt;
          float y=Findandhit.transform.localEulerAngles.y;
           if(y>180)
           {
             y=y-360;
           }

           rotate=y;
           Parent.transform.transform.Rotate(this.transform.transform.rotation.x,y,this.transform.transform.rotation.z);
         
    }
    

    // Update is called once per frame
    void Update()
    {
        // print(components[1].gameObject.name);
      Parent=  this.transform.parent.gameObject;
      if(turn==true)
      {
        waypoints=new Transform[components.Length];
        
         for (int i = 0; i < components.Length; i++)
         {
              waypoints[i]=components[i];
         }
      
          Move(Parent);
      }
      else
      {
        print("ff");
      }
      
     
    }
      
   
       private void OnTriggerStay(Collider other) {
          
           
        
            Parent=  this.transform.parent.gameObject;
           
             if(other.gameObject.tag == "ground")
             {
            
                 Parent.transform.position+= Parent.transform.forward * acceleration * Time.deltaTime;
                 Quaternion targetRotation  = Quaternion.LookRotation(other.transform.position - this.transform.position +new Vector3(0,0.5f,0) ); 
                   Parent.transform.rotation = Quaternion.Slerp(Parent.transform.rotation, targetRotation, 1.2f * Time.deltaTime);
                     Parent.transform.position =Vector3.MoveTowards(Parent.transform.position, other.transform.position +new Vector3(0,0.5f,0), Time.deltaTime * 2f);
                 
              
         }
            
        
         print(other.tag);
        }
        private void OnTriggerEnter(Collider other) {

            if(other.gameObject.tag == "grounddoura"){
           turn=true;
                components = other.gameObject.GetComponentsInChildren<Transform>(true);
                
           }

        if(other.gameObject.tag == "ground"){
                
          
            }
        }
       
    private void Move(GameObject obj)
    {
          if(waypointIndex==waypoints.Length)
                {
                  print("gg");
                  turn=false;
                  waypointIndex=0;
                }
        if (waypointIndex <= waypoints.Length - 1)
        {
          
            obj.transform.position = Vector3.MoveTowards(obj.transform.position,
               waypoints[waypointIndex].transform.position,
               acceleration * Time.deltaTime *1.5f);
                   if (waypoints[waypointIndex].transform.position - obj.transform.position != Vector3.zero) {     
                     Quaternion targetRotation  = Quaternion.LookRotation(waypoints[waypointIndex].transform.position - obj.transform.position ); 
                       obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, targetRotation, 3f * Time.deltaTime);
             
    }

             
            if (obj.transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
                
            }
        }
      
    }       
        
}

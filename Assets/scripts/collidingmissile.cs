using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidingmissile : MonoBehaviour
{
    public static bool boom;
   
 private IEnumerator  coroutine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    { 
       
          
              if(other.tag == "ground")
              {
              print("loool");
              }   
        
    }
      IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        boom=true;
        yield return new WaitForSeconds(2);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        boom=false;
     

         Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidingarrow : MonoBehaviour
{
    public static bool tail;
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
        if(other.tag == "Player")
        {
           
           Movementkart.speed=Movementkart.speed+2.0f;
           StartCoroutine(ExampleCoroutine());
           transform.Translate(0.0f,-20.0f,0.0f);
          

            

        }
    }
      IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        tail=true;
        yield return new WaitForSeconds(2);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        tail=false;
         Movementkart.speed=Movementkart.speed-2.0f;

         Destroy(this.gameObject);
    }
}

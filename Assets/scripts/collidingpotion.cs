using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidingpotion : MonoBehaviour
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
           
           transform.Translate(0.0f,-20.0f,0.0f);
          

            

        }
    }
    
}

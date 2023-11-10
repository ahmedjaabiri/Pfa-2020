using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(0.0f,0.0f+Time.deltaTime*6.0f*10,0.0f,Space.Self);
    }
    private void OnTriggerEnter(Collider other) {

        //sandou9 ability
        if(other.tag != "x")
              {
             Destroy(this.gameObject);
              }   
        
      }

   
}

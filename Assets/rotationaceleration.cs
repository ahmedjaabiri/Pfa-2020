using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationaceleration : MonoBehaviour
{
    float aux;
    // Start is called before the first frame update
    void Start()
    {
         aux = transform.rotation.eulerAngles.z;
    }
    float resist=0.5f;
    // Update is called once per frame
    void Update()
    {

       
        

        float angle = transform.rotation.eulerAngles.z;
        angle = (angle > 180) ? angle - 360 : angle;
   
       
        if (Movementkart.totalspeed<0.85f && angle < 47)
        {
            
            transform.Rotate(0, 0, -(0 + ((Movementkart.totalspeed))));
            
        }
        if(angle > 47)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, aux);
        }
       

    }
}

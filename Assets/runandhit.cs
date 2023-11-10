using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runandhit : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private float accelaration;

    // Start is called before the first frame update
    void Start()
    {
        rb= this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
 void FixedUpdate() 
    {

          accelaration=accelaration+0.02f;
          rb.AddForce(transform.forward*500);
       
        
    }
}

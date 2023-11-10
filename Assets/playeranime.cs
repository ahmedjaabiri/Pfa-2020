using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeranime : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey(KeyCode.LeftArrow))
         {
             animator.SetBool("left",true);
           
          }
         else
         {animator.SetBool("left",false);}

          if (Input.GetKey(KeyCode.RightArrow))
         {
             animator.SetBool("right",true);
 
             }
         else
         {animator.SetBool("right",false);}
         }
         


 private void OnTriggerEnter(Collider other) {

        //sandou9 ability
        if(other.tag == "box")
              {
               StartCoroutine(thumb());
              }   
        
      }
         IEnumerator thumb()
    {
            animator.SetBool("thumb",true);
        yield return new WaitForSeconds(1.5f);
       
        animator.SetBool("thumb",false);
    }
}

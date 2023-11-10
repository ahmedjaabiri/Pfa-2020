using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class findandhit : NetworkBehaviour

{
   public GameObject objt;
   Animator animator;
    private GameObject target;
    public GameObject lancer;
    public GameObject capteur;
    public float auxdist;
    private float accelaration=1;

    public  int id;

    // Start is called before the first frame update
    void Start()
    {
           
           animator=this.GetComponent<Animator>();
           objt=this.gameObject;
    }
    bool x=false;
    // Update is called once per frame
    void Update()
    {
      
         FindClosestEnemy();

         //if(auxdist<800)
       //  {
         // fixdirection.thisgameobject.SetActive(false); 
          accelaration=accelaration+0.02f;
          Quaternion targetRotation  = Quaternion.LookRotation(FindClosestEnemy().transform.position - transform.position); 
          transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3.0f * Time.deltaTime);
          this.transform.position=Vector3.MoveTowards(this.transform.position, FindClosestEnemy().transform.position, Time.deltaTime * 6f * accelaration *2.0f);

        // }
        
       
  }

 

       GameObject closest;
       GameObject realone;
        GameObject FindClosestEnemy() {

            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Player");
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            for (int i = 0 ; i < gos.Length ; i++) {
             GameObject go=gos[i];
             if(go.GetComponent<Controllplayer>().thisid!=id)
             {
               print(i);
              Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance ) {
                    closest = go;
                    distance = curDistance;
                    auxdist=distance;
                
                }
             }   
            
                
                
            }
            closest.transform.GetComponent<lapscript>().setmissile(1);
            return closest;
        }
 

}

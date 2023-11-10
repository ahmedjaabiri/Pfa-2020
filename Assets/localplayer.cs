using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class localplayer : NetworkBehaviour 
{
    // Start is called before the first frame update
    void Start()
    {
        if(isLocalPlayer)
        {
            GetComponent<Movementkart>().enabled=true;
            GetComponent<Controllplayer>().enabled=true;
            GetComponent<playerui>().enabled=true;
            GetComponentInChildren<Canvas>().enabled = true;
            GetComponent<lapscript>().enabled = true;

            CameraFollow360.player=this.gameObject.transform;
        }else
        {
          GetComponent<Controllplayer>().enabled=false;
            GetComponent<Movementkart>().enabled=false;
             GetComponent<playerui>().enabled=false;
            GetComponentInChildren<Canvas>().enabled = false;
            GetComponent<lapscript>().enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

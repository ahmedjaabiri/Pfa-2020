using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class shilddestroy : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        //sandou9 ability
        if (other.tag == "missile")
        {
            Cmddestroy(other.gameObject);
        }

    }
    [Command]
    void Cmddestroy(GameObject o)
    {
        Rpcdestroy(o);
    }
    [ClientRpc]
    void Rpcdestroy(GameObject o)
    {
        Destroy(o);
        NetworkAnimator.Destroy(o);
    }
}

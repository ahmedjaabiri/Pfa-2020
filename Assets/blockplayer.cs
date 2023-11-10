using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class blockplayer : MonoBehaviour
{
    public  GameObject[] players;
    bool block;
 
 
    bool joined1= false;
    bool joined2= false;



    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
     
        
    
    }
    
}

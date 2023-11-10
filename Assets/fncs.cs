using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fncs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void Sceanchange()
    {
        SceneManager.LoadScene(0);
         transform.Find("Network manager").GetComponent<hudscript>().st();
 
    }
}

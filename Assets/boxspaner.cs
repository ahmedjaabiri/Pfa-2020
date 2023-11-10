using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxspaner : MonoBehaviour
{
    public GameObject box;
    bool apear = true;
    GameObject boxspanned;
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (apear)
        {
            StartCoroutine(spanbox());
        }
        

        
    }

    IEnumerator spanbox()
    {
        apear = false;
        if (boxspanned == null)
        { boxspanned = (GameObject)Instantiate(box, this.transform.position, Quaternion.identity); }
        yield return new WaitForSeconds(20);
        apear = true;

    }
}

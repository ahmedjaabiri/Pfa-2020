using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningcloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("spancloud");
    }
    IEnumerator spancloud()
    {
        int ran = Random.Range(0, 360);

        transform.Translate(ran * 0.005f, 0, ran * 0.005f);
        transform.Rotate(0, 0.1f, 0);
        yield return new WaitForSeconds(25);
        Destroy(this.gameObject);
        

    }
}

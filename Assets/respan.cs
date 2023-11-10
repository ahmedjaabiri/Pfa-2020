using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respan : MonoBehaviour
{
    public float x, y, z;
    public float r;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(x, y, z);
            other.gameObject.transform.rotation = new Quaternion(0f, r, 0f, r);
            other.gameObject.GetComponent<Movementkart>().accelaration = 0f;
            other.gameObject.GetComponent<Movementkart>().audioSource.pitch = 1f;

        }   
    }
}
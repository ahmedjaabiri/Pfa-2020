using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomcloud : MonoBehaviour
{
    public Transform cloud1;
    public Transform cloud2;
    public Transform cloud3;
    private IEnumerator coroutine;
    bool isCoroutineStarted = true;
    public int time;
    void Start()
    {
        
    }  


    // Update is called once per frame
    void Update()
    {
        if(isCoroutineStarted)
        StartCoroutine(spancloud(time));

    }
    IEnumerator spancloud(int time)
    {
        isCoroutineStarted = false;
        yield return new WaitForSeconds(time);
        int ran = Random.Range(0, 3);
        print("raan="+ ran);
        if (ran==0)
        {
            Instantiate(cloud1, this.transform.position, Quaternion.identity);
        }
        if (ran == 1)
        {
            Instantiate(cloud2, this.transform.position, Quaternion.identity);
        }
        if (ran == 2)
        {
            Instantiate(cloud3, this.transform.position, Quaternion.identity);
        }
        isCoroutineStarted = true;

    }
}

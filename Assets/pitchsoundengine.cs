using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitchsoundengine : MonoBehaviour
{
    AudioSource audioSource;
    public int startingPitch = 1;
    // Start is called before the first frame update
    void Start()
    {
     
    audioSource = GetComponent<AudioSource>();
        audioSource.pitch = startingPitch;
    }

    // Update is called once per frame
    void Update()
    {
        print(audioSource.pitch );
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(audioSource.pitch<1.7f)
            {
                audioSource.pitch = audioSource.pitch * 0.005f;
            }
          
        }
    }
}

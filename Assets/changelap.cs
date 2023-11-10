using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class changelap : MonoBehaviour
{
    public Text txt;
    public void settext(Text txt)
    {
        this.txt = txt;
    }
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
         txt.text = "Lap : " + Controllplayer.cur_lap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

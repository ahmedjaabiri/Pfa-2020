using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lapscript : MonoBehaviour
{
    public int p1win=0;
    public int missilealert = 0;
    public  bool c1 = false;
    public  bool c2 = false;
    public  bool c3 = false;
    public  bool c4 = false;
    public bool c5 = false;
    public bool c6 = false;
    public bool c7 = false;
    public bool c8 = false;
    public bool c9 = false;
    public bool c10 = false;
    public bool c11 = false;
    public bool c12 = false;
    public bool c13 = false;
    public bool c14 = false;
    public bool c15 = false;
    public bool c16 = false;
    public bool c17 = false;
    public bool c18 = false;
    public bool c19 = false;
    public bool c20 = false;
    public bool c21 = false;
    public bool c22 = false;
    public bool c23 = false;
    public bool c24 = false;
    public bool c25 = false;
    public bool c26 = false;
    public bool c27 = false;
    public bool c28 = false;
    public bool c29 = false;
    public int checkpoin;
    public TextMeshPro txt;
   public Animator anim;
    [SerializeField] TextMeshProUGUI m_Object;
    public int cur_lap = 0;

    // Start is called before the first frame update
    void Start()
    {
      
    }
    public int getc1()
    {
        return checkpoin;
    }
    public void setwin(int n)
    {
        this.p1win = n;
    }
    public void setmissile(int n)
    {
        this.missilealert = n;
    }
    public int getlap()
    {
        return cur_lap;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            cur_lap++;
          
        }
        if (p1win == 1)
        {
            anim.SetInteger("lose", 1);
            transform.GetComponent<Movementkart>().forcedstop = 0;
            transform.GetComponent<Movementkart>().stopanimation = true;
        }
        else if (p1win == 2)
        {
            anim.SetInteger("lose", 2);
            transform.GetComponent<Movementkart>().forcedstop = 0;
            transform.GetComponent<Movementkart>().stopanimation = true;
        }
        if (missilealert == 1)
        {
            StartCoroutine(animmissile());
        }
    }
    IEnumerator animmissile()
    {
        anim.SetInteger("missile", 1);
        yield return new WaitForSeconds(3);
        missilealert = 0;
        anim.SetInteger("missile", 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "checklap")
        {
            if (other.name=="c1")
            {
                c1 = true;
                checkpoin=1;
}
            if (other.name == "c2")
            {
                c2 = true;
                checkpoin = 2;
            }
            if (other.name == "c3")
            {
                c3 = true;
                checkpoin = 3;
            }
            if (other.name == "c4")
            {
                c4 = true;
                checkpoin = 4;
            }
            if (other.name == "c5")
            {
                c5 = true;
                checkpoin = 5;
            }
            if (other.name == "c6")
            {
                c6 = true;
                checkpoin = 6;
            }
            if (other.name == "c7")
            {
                c7 = true;
                checkpoin = 7;
            }
            if (other.name == "c8")
            {
                c8 = true;
                checkpoin = 8;
            }
            if (other.name == "c9")
            {
                c9 = true;
                checkpoin = 9;
            }
            if (other.name == "c10")
            {
                c10 = true;
                checkpoin = 10;
            }
            if (other.name == "c11")
            {
                c11 = true;
                checkpoin = 11;
            }
            if (other.name == "c12")
            {
                c12 = true;
                checkpoin = 12;
            }
            if (other.name == "c13")
            {
                c12 = true;
                checkpoin = 13;
            }
            if (other.name == "c14")
            {
                c14 = true;
                checkpoin = 14;
            }
            if (other.name == "c15")
            {
                c15 = true;
                checkpoin = 15;
            }
            if (other.name == "c16")
            {
                c16 = true;
                checkpoin = 16;
            }
            if (other.name == "c17")
            {
                c17 = true;
                checkpoin = 17;
            }
            if (other.name == "c18")
            {
                c18 = true;
                checkpoin = 18;
            }
            if (other.name == "c19")
            {
                c19 = true;
                checkpoin = 19;
            }
            if (other.name == "c20")
            {
                c20 = true;
                checkpoin = 20;
            }
            if (other.name == "c21")
            {
                c21 = true;
                checkpoin = 21;
            }
            if (other.name == "c22")
            {
                c22 = true;
                checkpoin = 22;
            }
            if (other.name == "c23")
            {
                c23 = true;
                checkpoin = 23;
            }
            if (other.name == "c24")
            {
                c24 = true;
                checkpoin = 24;
            }
            if (other.name == "c25")
            {
                c25 = true;
                checkpoin = 25;
            }
            if (other.name == "c26")
            {
                c26 = true;
                checkpoin = 26;
            }
            if (other.name == "c27")
            {
                c27 = true;
                checkpoin = 27;
            }
            if (other.name == "c28")
            {
                c28 = true;
                checkpoin = 28;
            }
            if (other.name == "c29")
            {
                c29 = true;
                checkpoin = 29;
            }
        }

        if (other.tag == "lap")
        {
          if(c1 && c2 && c3 && c4 && c11 && c16 && c22 && c29)
            {
                cur_lap++;
                c1 = false; c2 = false; c3 = false; c4 = false;
                c5 = false; c6 = false; c7 = false; c8 = false;
                c9 = false; c10 = false; c11 = false; c12 = false;
                c13 = false; c14 = false; c15 = false; c16 = false;
                c17 = false; c18 = false; c19 = false; c20 = false;
                c21 = false; c22 = false; c23 = false; c24 = false;
                c25 = false; c26 = false; c27 = false;
                c28 = false; c29 = false;
                m_Object.SetText("lap:{0}" , cur_lap);
               StartCoroutine(animation(cur_lap,2.2f));
            }
        }
       
    }
    IEnumerator animation(int lap, float time)
    {

        anim.SetInteger("lap", cur_lap);
        yield return new WaitForSeconds(time);
        anim.SetInteger("lap", 0);

    }

}

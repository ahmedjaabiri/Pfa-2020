using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class serverplayers : MonoBehaviour
{
    int p1point; int p1lap;
    int p2lap; int p2point;
    public static GameObject[] players;
    public Animator animator;
    bool animateone = true;
    [SerializeField] TextMeshProUGUI m_Object;
    public Animator anim;
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        print("muna" + players.Length);
        if(players.Length>0)
        {
             p1point=players[0].transform.GetComponent<lapscript>().getc1();
             p1lap = players[0].transform.GetComponent<lapscript>().getlap();
        }
        if (players.Length > 1)
        {
             p2point = players[1].transform.GetComponent<lapscript>().getc1();
             p2lap = players[1].transform.GetComponent<lapscript>().getlap();

        }
        if(p1lap > p2lap)
        {
          m_Object.SetText("player1:1st\nplayer2:2nd");
        }else if (p1lap < p2lap)
        {
            m_Object.SetText("player2:1st\nplayer12nd");
        }else if(p1lap == p2lap)
        {
            if (p1point > p2point)
            {
                m_Object.SetText("player1:1st\nplayer2:2nd");
            }
            else if (p1point < p2point)
            {
                m_Object.SetText("player2:1st\nplayer1:2nd");
            }
            else if (p1point == p2point)
            {
                m_Object.SetText("Draw");
            }
        }
        if (players.Length > 1)
        {
            if (p1lap == 4)
            {
                players[0].transform.GetComponent<lapscript>().setwin(2);
                players[1].transform.GetComponent<lapscript>().setwin(1);
            }
            if (p2lap == 4)
            {
                players[1].transform.GetComponent<lapscript>().setwin(2);
                players[0].transform.GetComponent<lapscript>().setwin(1);
            }

        }
        if (players.Length == 0)
        {
            animator.SetBool("count", false);
        }

            if (players != null)
        {

            if (players.Length > 0)
            {

                animator.SetBool("block", true);
                for (int i = 0; i < players.Length; i++)
                {
                    players[i].GetComponent<Movementkart>().forcedstop = 0;
                    players[i].GetComponent<Movementkart>().stopanimation = true;
                }
                animateone = true;
            }
            if (players.Length > 1)
            {

                if (animateone)
                    StartCoroutine(animcounter());
            }




        }

        IEnumerator animcounter()
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].GetComponent<Movementkart>().forcedstop = 0;
                players[i].GetComponent<Movementkart>().stopanimation = true;
            }

            animator.SetBool("count", true);
            animator.SetBool("block", false);
            print("AAAAAAAAA");
            animateone = false;
            yield return new WaitForSeconds(3);
            print("OOOOOO");
            animator.SetBool("count", false);
            for (int i = 0; i < players.Length; i++)
            {
                players[i].GetComponent<Movementkart>().forcedstop = 1;
                players[i].GetComponent<Movementkart>().stopanimation = false;
            }





        }


    }

   /* [Command]
    void Cmdposition(string str)
    {
        Rpcposition(str);
    }
    [ClientRpc]
    void Rpcposition(string str)
    {
        m_Object.SetText(str);
    }*/


}

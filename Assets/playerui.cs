using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerui : MonoBehaviour
{
    public Animator animator;
    public Image m_Image;
  
    public void setanim(Animator animator)
    {
        this.animator=animator;
    }
    public void setimage(Image m_Image)
    {
        this.m_Image=m_Image;
    }
     void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void animate(int power)
    {
      print(power);
      animator.SetBool("took",true);  
      StartCoroutine(powerui(2,power));
     
    }
      public void deanimate()
    {
      animator.SetBool("took",false);  
      animator.SetInteger("choosen",-1);
     
    }
      IEnumerator powerui(int time,int power)
    {
       
        yield return new WaitForSeconds(time);
        animator.SetBool("took",false);
        animator.SetInteger("choosen",power);
    }
}

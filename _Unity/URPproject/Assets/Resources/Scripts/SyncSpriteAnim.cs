using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class SyncSpriteAnim : MonoBehaviour
{
    SayDialog sdialog;
    Animator m_Animator;
   
    GameObject pc, temp;
    
    // Start is called before the first frame update
    void Start()
    {
        sdialog = GetComponent<SayDialog>();
      
       // print(Fungus.PortraitState(). )
    }

    // Update is called once per frame
    void Update()
    {
        if (sdialog.SpeakingCharacter != null)
        {
            Flaps();
            Position();
            
        }
    }

    void Flaps()
    {
        
            m_Animator = sdialog.SpeakingCharacter.gameObject.GetComponentInChildren<Animator>();
        //        print(sdialog.SpeakingCharacter.State.portrait.name);
        if (m_Animator != null)
        {
            if (sdialog.GetComponent<Writer>().IsWriting)
                m_Animator.SetBool("talk", true);
            if (sdialog.GetComponent<Writer>().IsWaitingForInput)
                m_Animator.SetBool("talk", false);
        }
    }

    void Position()
    {
        if (m_Animator != null)
        {
            pc = sdialog.SpeakingCharacter.gameObject;
            temp = GameObject.Find(pc.name + " holder");
            
            //if (temp.GetComponentInChildren<Image>().enabled)
            
                var tempColor = temp.GetComponentInChildren<Image>().color;
            if (tempColor != Color.white)
            {
                // m_Animator.enabled=false;
                pc.transform.GetChild(1).GetComponent<Image>().enabled = true;
            }
            else
            {
                pc.transform.GetChild(1).GetComponent<Image>().enabled = false;
            }
            
                //tempColor.a = 0f;
                //temp.GetComponentInChildren<Image>().color = tempColor;
            
            
                //pc.GetComponentInChildren<Image>().color = temp.GetComponentInChildren<Image>().color;
            pc.GetComponent<RectTransform>().anchoredPosition = temp.GetComponent<RectTransform>().anchoredPosition;
            pc.GetComponent<RectTransform>().localScale = temp.GetComponent<RectTransform>().localScale;
            pc.GetComponent<RectTransform>().pivot = temp.GetComponent<RectTransform>().pivot;
            pc.GetComponent<RectTransform>().anchorMax = temp.GetComponent<RectTransform>().anchorMax;

            pc.gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
        }
    }
    

}

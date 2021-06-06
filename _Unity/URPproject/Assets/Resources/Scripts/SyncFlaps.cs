using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using Fungus;
using UnityEngine.SceneManagement;


public class SyncFlaps : MonoBehaviour
{
    SayDialog sdialog;
    Animator m_Animator;
    Animation anim;
    AnimatorClipInfo[] m_AnimatorClipInfo;

    bool eyesSpeed = true;
    // Start is called before the first frame update
    void Start()
    {
        sdialog = GetComponent<SayDialog>();
         //SceneManager.LoadScene
        //if(sdialog.GetComponent<Writer>().IsWaitingForInput)
        // sdialog.SpeakingCharacter.gameObject.GetComponent<Animator>().SetBool("talking", true);
        // m_Animator = sdialog.SpeakingCharacter.gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
      // Debug.Log(GetComponent<SayDialog>().NameText);
        //Debug.Log(GetComponent<SayDialog>().SpeakingCharacter.NameText);
        if (sdialog.SpeakingCharacter != null)
            m_Animator= sdialog.SpeakingCharacter.gameObject.GetComponentInChildren<Animator>();
//        print(sdialog.SpeakingCharacter.State.portrait.name);
        if (sdialog.GetComponent<Writer>().IsWriting)
            m_Animator.SetBool("talk", true);
        if (sdialog.GetComponent<Writer>().IsWaitingForInput)
            m_Animator.SetBool("talk", false);


        //if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        //{
        //    // m_Animator.SetBool("blink", false);
        //    //Random.Range(0.5f, 1f)
        //   // m_Animator.SetFloat("speed", Random.Range(1f, 2f));
        //}
        //else
        //{
        //    // m_Animator.SetBool("blink", true);

        //}
        //if(!m_Animator.GetBool("blink"))
        //m_Animator.SetFloat("speed", Random.Range(1f, 5f));
        //m_Animator.speed = 0.05f;
        //print(m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime);

    }
}

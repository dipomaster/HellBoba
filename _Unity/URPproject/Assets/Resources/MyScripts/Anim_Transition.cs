using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Transition : MonoBehaviour
{
    public Animator transition;
    public bool activate;
    private BobaGM gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GM").GetComponent<BobaGM>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PrintEvent(string s)
    {
        //Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
        gm.playAnim = s;
    }
}

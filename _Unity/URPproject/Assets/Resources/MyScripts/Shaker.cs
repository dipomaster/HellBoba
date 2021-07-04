using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public float shakeFX, time_max, time_start;
    public GameObject sideCam;
    GameObject cup,liquid;
    Vector4 ogTiling;
    bool shakerON=false;
    // Start is called before the first frame update
    void Start()
    {
        cup = GameObject.FindGameObjectWithTag("Cup");
        liquid = cup.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(shakerON)
        {
            if (Time.time > time_max + time_start)
            {
                GetComponent<Animator>().SetBool("_shake", false);
                sideCam.GetComponent<Animator>().SetBool("_shake", false);
                liquid.GetComponent<Renderer>().material.SetVector("UVtiling",ogTiling);
                shakerON = false;
            }
           shakeFX= Random.Range(0.1f,1);
           liquid.GetComponent<Renderer>().material.SetVector("UVtiling", new Vector4(shakeFX, shakeFX, 0, 0));
        }
    }

    public void Shake()
    {
        time_start = Time.time;
        GetComponent<Animator>().SetBool("_shake", true);
        sideCam.GetComponent<Animator>().SetBool("_shake", true);
        ogTiling= liquid.GetComponent<Renderer>().material.GetVector("UVtiling");
        shakerON = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pour : MonoBehaviour
{
    public GameObject cupLiquid,cupHolder;
    public float fillLevel,fillMin, fillMax, speedFill,t=0;
    bool pouring=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // t += Time.time;
       // Debug.Log(Mathf.Lerp(fillMin, fillMax, Time.time*speedFill));
        if (pouring)
        {
            t++;
            fillLevel = Mathf.Lerp(fillMin, fillMax,t*speedFill);
            cupLiquid.GetComponent<Renderer>().material.SetFloat("_Fill", fillLevel);
            if(fillLevel<1f)
            cupHolder.GetComponent<Animator>().SetBool("pouring", true);
                
                }
        if (cupLiquid.GetComponent<Renderer>().material.GetFloat("_Fill") == fillMax)
        {
            //foreach (Transform child in transform)
            //{
            //    child.gameObject.SetActive(false);
            //}
            cupHolder.GetComponent<Animator>().SetBool("pouring", false);
        }


    }
  public  void PourLiquid()
    {        
        foreach (Transform item in transform)
        {
            item.gameObject.SetActive(true);
            pouring = true;
        }
       
    }
}

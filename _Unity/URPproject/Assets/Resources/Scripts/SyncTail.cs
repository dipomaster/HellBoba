using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SyncTail : MonoBehaviour
{
    GameObject tailGO;
    // Start is called before the first frame update
    void Start()
    {
        tailGO = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<SayDialog>().SpeakingCharacter)
        tailGO.transform.position = new Vector3( GetComponent<SayDialog>().SpeakingCharacter.State.holder.position.x, tailGO.transform.position.y, tailGO.transform.position.z);

        if (tailGO.GetComponent<RectTransform>().anchoredPosition.x > 0)
            tailGO.GetComponent<RectTransform>().rotation =Quaternion.Euler(0, 180,0);                
        else 
            tailGO.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);

    }
}

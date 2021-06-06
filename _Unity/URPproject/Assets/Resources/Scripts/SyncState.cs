using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class SyncState : MonoBehaviour
{
    public SayDialog sdialog;
    // Start is called before the first frame update
    void Start()
    {
        //sdialog = GameObject.Find("SayDialogCustom").GetComponent<SayDialog>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Character>().State.dimmed)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.GetComponent<Image>().enabled=true;
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
        //print(GetComponent<Character>().State.dimmed);
    }
}

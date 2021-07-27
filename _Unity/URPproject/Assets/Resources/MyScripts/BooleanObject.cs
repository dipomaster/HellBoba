using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooleanObject : MonoBehaviour
{
    public GameObject[] goActiveList;
    public GameObject[] goDeactivateList;
    public bool switchOFF=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (switchOFF)
        {
            foreach(GameObject obj in goActiveList)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in goDeactivateList)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject obj in goDeactivateList)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in goActiveList)
            {
                obj.SetActive(true);
            }
        }

    }
    public void SwitchCam()
    {
        switchOFF = !switchOFF;
    }
}

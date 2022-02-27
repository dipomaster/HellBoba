using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOutline : MonoBehaviour
{
   
    public GameObject cup;
    public  void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Cup"))
        {
            cup.GetComponent<Outline>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cup"))
            cup.GetComponent<Outline>().enabled = true;
    }
}

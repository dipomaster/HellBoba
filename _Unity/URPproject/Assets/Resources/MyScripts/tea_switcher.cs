using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tea_switcher : MonoBehaviour
{
    public Material[] teas;
    // Start is called before the first frame update
   

   public void updateMaterial(int i)
    {
        GetComponent<MeshRenderer>().material = teas[i];
    }
}

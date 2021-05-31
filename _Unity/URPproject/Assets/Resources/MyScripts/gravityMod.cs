using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityMod : MonoBehaviour
{
    public float gMod;
    public bool buoyancy;
    private Rigidbody rb;
    public float scaleG=0,t=0,currentG;
    // Start is called before the first frame update
    void Start()
    {
       rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buoyancy)
        {t += Time.deltaTime ;
            currentG = Mathf.Lerp(gMod, scaleG, t*.05f);

            //Debug.Log(currentG);
            rb.AddForce(Vector3.up * currentG*rb.mass);
            if (currentG == 0)
                buoyancy = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("surface"))
        {
            buoyancy = true;
            t = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("surface"))
        {
            buoyancy = false;
            gMod = currentG;
            t = 0;
        }
    }
}

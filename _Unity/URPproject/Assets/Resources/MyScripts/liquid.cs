using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liquid : MonoBehaviour
{
    public bool pour=false;
    public GameObject drop;
    public float timeStart, timeElapsed, dropsinscene = 0, dropsMax;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dropsinscene < dropsMax)
        {
            if (pour)
            {
                if (Time.time > timeStart + timeElapsed)


                    spawn();
            }
            else
            {
                timeStart = Time.time;
                pour = true;
            }
        }
    }

    void spawn()
    {
        int j;
        for (j = 0; j < i; j++)
        {
            
                var go = Instantiate(drop, transform.position, Quaternion.identity);
                go.GetComponent<Rigidbody>().AddForce(Vector3.up * -1);
            go.transform.parent = this.transform;
            dropsinscene++; 
        }
        pour = false;
    }
}

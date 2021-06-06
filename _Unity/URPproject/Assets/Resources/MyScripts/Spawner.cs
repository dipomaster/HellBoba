using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool pour = false;
    public GameObject drop;
    public Boba cup;
    public float timeStart, timeElapsed, dropsinscene = 0, dropsMax,timeMultiplier;
    public int burstSize;
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
                    Spawn();
            }
            else
            {
                timeStart = Time.time;
                pour = true;
            }
        }
    }

    void Spawn()
    {
        int j;
        for (j = 0; j < burstSize; j++)
        {

            var go = Instantiate(drop, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(Vector3.up * -1);
            go.transform.parent = this.transform;
            dropsinscene++;
        }
        pour = false;
    }
}

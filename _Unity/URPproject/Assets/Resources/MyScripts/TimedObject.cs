using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObject : MonoBehaviour
{
    public float timer;
    private float startTimer;


    private void FixedUpdate()
    {
        if(startTimer+timer>Time.time)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("table"))
        {
            startTimer = Time.time;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObject : MonoBehaviour
{
    public float timer;
    private float startTimer;
    public string tag;


    private void FixedUpdate()
    {
        if(startTimer+timer>Time.time)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag(tag))
        {
            startTimer = Time.time;
        }
    }
}

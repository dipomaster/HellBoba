using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSettings : MonoBehaviour
{
    public Camera sideCam,upCam;
    public float zoomDuration,zoomAmount,zoomCurrent;
    private float startTime,t;
    private bool zoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (zoom)
        {
            sideCam.orthographicSize = Mathf.Lerp(zoomCurrent, zoomAmount, t * zoomDuration*2);

            t += 0.5f * Time.deltaTime;
            if (Time.time > startTime + zoomDuration)
            {

                t = 0;
                zoom = false;

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CamTrgr"))
        {
            // Debug.Log("CamTrgr");
            zoom = true;
            zoomCurrent = sideCam.orthographicSize;
            zoomAmount= other.GetComponent<CamTrgr>().zoomAmount;
            zoomDuration= other.GetComponent<CamTrgr>().zoomDuration;
            startTime = Time.time;
        }
        //Debug.Log("hello");
    }
   
}

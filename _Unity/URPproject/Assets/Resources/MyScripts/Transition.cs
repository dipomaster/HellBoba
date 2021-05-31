using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{

    public GameObject bobaWindow, desWindow, vnWindow, textWindow;
    public bool move=false;
    public Transform newpos;
    public float lerpDuration = 3;
    public Vector3 startValue ;
    public Vector3 endValue ;
    public float valueToLerp;
    public float timeElapsed;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        startValue = bobaWindow.GetComponent<RectTransform>().position;

    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        Lerp();
        endValue.x = cam.scaledPixelWidth*2;
        endValue.y = cam.scaledPixelHeight;
    }

    void Lerp()
    {
        if (timeElapsed < lerpDuration)
        {
            bobaWindow.GetComponent<RectTransform>().position = new Vector3(  Mathf.Lerp(startValue.x, endValue.x, timeElapsed / lerpDuration), bobaWindow.GetComponent<RectTransform>().position.y, bobaWindow.GetComponent<RectTransform>().position.z)  ;
            timeElapsed += Time.deltaTime;
        }
        else
        {
            transform.position = endValue;
        }
    }
}

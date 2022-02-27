using UnityEngine;

public class CamSettings : MonoBehaviour
{
    private Camera sideCam, upCam;
    public Camera activeCam;
    public bool switchCam,move;
    public float zoomDuration, zoomAmount, zoomCurrent;
    public Vector3 moveCam;
    private float startTime, t;
    private bool zoom;
    private DragObjRT canvasGM;
    public Animator transition;

    // Start is called before the first frame update
    public virtual void Start()
    {
        canvasGM = GameObject.Find("UI").GetComponent<DragObjRT>();
        upCam = canvasGM.camUp;
        sideCam = canvasGM.camSide;
        activeCam = upCam;
        transition = GameObject.Find("Transition").GetComponent<Animator>();
        transition.enabled = false;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (zoom)//zooms the camera according to the trigger's value
        {
            sideCam.orthographicSize = Mathf.Lerp(zoomCurrent, zoomAmount, t * zoomDuration * 2);

            t += 0.5f * Time.deltaTime;
            if (Time.time > startTime + zoomDuration)
            {
                t = 0;
                zoom = false;
               
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CamTrgr"))
        {
            // Debug.Log("CamTrgr");
            zoom = true;
            zoomCurrent = sideCam.orthographicSize;
            zoomAmount = other.GetComponent<CamTrgr>().zoomAmount;
            zoomDuration = other.GetComponent<CamTrgr>().zoomDuration;
            move = other.GetComponent<CamTrgr>().move;
            switchCam = other.GetComponent<CamTrgr>().switchCam;
            startTime = Time.time;

            if (switchCam)
            {
                transition.enabled=true;
                activeCam = sideCam;
                canvasGM.Side = true;
                canvasGM.Up = false;
                
                sideCam.GetComponent<Camera>().enabled = true;
                upCam.GetComponent<Camera>().enabled = false;
                
            }
            else
            {
                activeCam = upCam;
                canvasGM.Side = false;
                canvasGM.Up = true;
                sideCam.GetComponent<Camera>().enabled = false;
                upCam.GetComponent<Camera>().enabled = true;
            }
            if (move)
            {
                activeCam.GetComponent<Animator>().SetBool("_sideview", true);
            }

        }
        //Debug.Log(activeCam.name);
    }
}
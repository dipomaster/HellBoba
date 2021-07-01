using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragObjRT : MonoBehaviour, IPointerDownHandler,IPointerUpHandler, IDragHandler
{
    private Vector3 mOffset;
    private float mZCoord;
    //[SerializeField] protected Camera UICamera;
    //[SerializeField] protected RectTransform RawImageRectTrans;
    //[SerializeField] protected Camera RenderToTextureCamera;

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    Vector2 localPoint;
    //    RectTransformUtility.ScreenPointToLocalPointInRectangle(RawImageRectTrans, eventData.position, UICamera, out localPoint);
    //    Vector2 normalizedPoint = Rect.PointToNormalized(RawImageRectTrans.rect, localPoint);
    //    var renderRay = RenderToTextureCamera.ViewportPointToRay(normalizedPoint);
    //    if (Physics.Raycast(renderRay, out var raycastHit))
    //    {
    //        Debug.Log("Hit: " + raycastHit.collider.gameObject.name);
    //    }
    //    else
    //    {
    //        Debug.Log("No hit object");
    //    }
    //}
    public Camera camUp;
    public GameObject selectedObj,spwnr;

    GraphicRaycaster gr;
    List<RaycastResult> results;

    void Start()
    {
        gr = gameObject.GetComponent<GraphicRaycaster>();
       
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        results = new List<RaycastResult>();
        gr.Raycast(eventData, results);
        //Now all the things that were touched by the graphic raycast are saved in a list.
        for (int i = 0; i < results.Count; i++)
        {
            //Debug.Log(results[i].gameObject.name);
            if (results[i].gameObject.name == "RawImage")
            //this is the one we need.
            {
               // Debug.Log("Touched the screen!"); //yeah!!
                                                  //So here we have the fist part working. I can get the screen and I am 
                                                  //guessing that somewhere in results[i], the coordinates I need for the second cast
                                                  //are waiting for me to understand what to do next...               
                                                  //I need to access the coordinates of the first hit (results[i]) and feed 
                                                  //it to a raycast that originates from the second cam to the extrapolated point which
                                                  //would let me access the 3d prefab. 
                RectTransform RawImageRectTrans = results[i].gameObject.GetComponent<RectTransform>();
                ///Here is what I tried (not working).
                Vector2 localPoint;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(RawImageRectTrans, eventData.position, null, out localPoint);
                Vector2 normalizedPoint = Rect.PointToNormalized(RawImageRectTrans.rect, localPoint);
                var renderRay = camUp.ViewportPointToRay(normalizedPoint);
                if (Physics.Raycast(renderRay, out var raycastHit))
                {
                    if (raycastHit.collider.gameObject.CompareTag("Grab"))
                    {
                        // Debug.Log("Hit: " + raycastHit.collider.gameObject.name);
                        selectedObj = raycastHit.collider.gameObject;
                        mZCoord = camUp.WorldToScreenPoint(selectedObj.transform.position).y;
                        mOffset = selectedObj.transform.position - GetMouseWorldPos();
                    }
                        //Debug.Log(mZCoord);
                }
                else
                {
                    Debug.Log("No hit object");
                    selectedObj = null;
                }
            }
        }
    }
    private void FixedUpdate()
    {
        //if (selectedObj)
        //{
        //    selectedObj.transform.position = GetMouseWorldPos() + mOffset;
        //}
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        //mousePoint.y = mZCoord;
        return camUp.ScreenToWorldPoint(mousePoint);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        selectedObj.transform.parent=null;
        var go=Instantiate(spwnr, selectedObj.transform.position,Quaternion.identity);
        go.SetActive(true);
        go.GetComponent<PearlSpwnr>().i = selectedObj.GetComponent<DragObj>().type; 
        Destroy(selectedObj);
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (selectedObj)
        {
            selectedObj.transform.position = GetMouseWorldPos() + mOffset;
        }
    }
}

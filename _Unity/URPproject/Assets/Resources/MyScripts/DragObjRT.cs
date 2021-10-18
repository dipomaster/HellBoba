using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragObjRT : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector3 mOffset;
    public bool Up = false, Side = false;
    private float mZCoord;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public GameObject powder;
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
    public Camera camUp, camSide;

    public GameObject selectedObj, spwnr, fosset;
    private bool grab, click, select;

    private GraphicRaycaster gr;
    private List<RaycastResult> results;

    private void Start()
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

                RectTransform RawImageRectTrans = results[i].gameObject.GetComponent<RectTransform>();
                ///Here is what I tried (not working).
                Vector2 localPoint;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(RawImageRectTrans, eventData.position, null, out localPoint);
                Vector2 normalizedPoint = Rect.PointToNormalized(RawImageRectTrans.rect, localPoint);
                if (Up)
                {
                    var renderRay = camUp.ViewportPointToRay(normalizedPoint);
                    if (Physics.Raycast(renderRay, out var raycastHit))
                    {
                        switch (raycastHit.collider.gameObject.tag)
                        {

                            case "Grab":
                                {
                                    grab = true;
                                    // Debug.Log("Hit: " + raycastHit.collider.gameObject.name);
                                    Select(raycastHit.collider.gameObject);
                                    mZCoord = camUp.WorldToScreenPoint(selectedObj.transform.position).y;
                                    mOffset = selectedObj.transform.position - GetMouseWorldPos();
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Debug.Log("No hit object");
                        //Cursor.SetCursor(null, Vector2.zero, cursorMode);
                        selectedObj = null;
                    }
                }
                else if (Side)
                {                    
                    var renderRay = camSide.ViewportPointToRay(normalizedPoint);
                    if (Physics.Raycast(renderRay, out var raycastHit))
                    {
                        switch (raycastHit.collider.gameObject.tag)
                        {
                            case "Click":
                                {
                                    click = true;
                                    Select(raycastHit.collider.gameObject);
                                    break;
                                }
                            //Debug.Log(raycastHit.collider.gameObject.transform.name);
                            case "ClickandSelect":
                                {
                                    select = true;
                                    Select(raycastHit.collider.gameObject);
                                    cursorTexture = selectedObj.GetComponent<CursorChange>().cursorTexture;
                                    Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
                                    powder.GetComponent<ParticleSystem>().startColor = powder.GetComponent<Powder_spwnr>().colorLib[selectedObj.GetComponent<DragObj>().type];
                                    powder.GetComponent<ParticleSystem>().Play(true);
                                    break;
                                }
                            default:
                                break;
                        }

                        
                    }
                    else
                    {
                        Debug.Log("No hit object");
                        if (selectedObj)
                        {
                            selectedObj.GetComponent<Outline>().enabled = false; 
                            selectedObj = null;
                        }
                        //selectedObj.GetComponent<Outline>().OutlineColor = Color.green;
                        Cursor.SetCursor(null, Vector2.zero, cursorMode);
                        
                    }
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
        if (grab)
        {
            selectedObj.transform.parent = null;
            var go = Instantiate(spwnr, selectedObj.transform.position, Quaternion.identity);
            go.SetActive(true);
            go.GetComponent<PearlSpwnr>().i = selectedObj.GetComponent<DragObj>().type;
            grab = false;
            Destroy(selectedObj);
        }
        if (click)
        {
            fosset.GetComponent<Pour>().type_selected = selectedObj.GetComponent<DragObj>().type;
            fosset.GetComponent<Pour>().PourLiquid();
            click = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (selectedObj && grab)
        {
            selectedObj.transform.position = GetMouseWorldPos() + mOffset;
        }
    }
    void Select(GameObject go)
    {
        if (selectedObj != null)                    
            selectedObj.GetComponent<Outline>().enabled = false;               
            selectedObj = go;
        if (selectedObj.GetComponent<Outline>())
        {
            selectedObj.GetComponent<Outline>().enabled = true;
            selectedObj.GetComponent<Outline>().OutlineColor = Color.green;
        }
        else
        {
            selectedObj.AddComponent<Outline>();
            selectedObj.GetComponent<Outline>().OutlineColor = Color.green;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObj : MonoBehaviour {
    public Camera camUP;
    private Vector3 mOffset;
    private float mZCoord;
    private Transform mSlotPosition;
    bool inSlot;
    public bool mCanMove;
    private GameObject mSlot;
    float speed = 10f;
    // Start is called before the first frame update
    private void OnMouseDown () {
        mZCoord = camUP.WorldToScreenPoint (gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos ();
    }
    private Vector3 GetMouseWorldPos () {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return camUP.ScreenToWorldPoint (mousePoint);
    }

    private void OnMouseDrag () {
        if (!inSlot)
            transform.position = GetMouseWorldPos () + mOffset;
    }
    private void OnTriggerEnter (Collider other) {
        if (other.tag == "Slot") {
            mSlotPosition = other.transform;
            mSlot = other.gameObject;
            //mCanMove = mSlot.GetComponent<StickyUI> ().mOccupied;
            if (!mCanMove)
                inSlot = true;

            // mSlotPosition.position = new Vector3(0,0,0)* mSlotPosition.position;
            Debug.Log (other.name);
            //mCanMove=other.
            // if (transform.position == other.transform.position)
            // inSlot = false;
        }
    }
    private void OnTriggerExit (Collider other) {
        if (other.tag == "Slot") {
            inSlot = false;
            transform.parent = null;
            //mCanMove=other.GetComponent<StickyUI>().mOccupied = false;
            // transform.position = other.transform.position;
            //Debug.Log(other.transform.position);
        }
    }
    private void Update () {
        if (inSlot && !mCanMove) {
            // Move our position a step closer to the target.
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards (transform.position, mSlotPosition.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance (transform.position, mSlotPosition.position) < 0.001f) {
                transform.parent = mSlot.transform;
                //mCanMove = mSlot.GetComponent<StickyUI> ().mOccupied = true;
                // Swap the position of the cylinder.
                inSlot = false;
            }

        }

    }

}
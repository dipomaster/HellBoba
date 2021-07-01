using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObj : MonoBehaviour {
    public Camera camUP;
    public int type;
    private Vector3 mOffset;
    private float mZCoord;
    private Transform mSlotPosition;
    bool inSlot;
    public bool mCanMove;
    private GameObject mSlot;
    float speed = 10f;
    


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetLogic : MonoBehaviour
{
    public GameObject ballCollider;
    public Cloth cloth;
    // Start is called before the first frame update
    void Start()
    {
        cloth =GetComponent<Cloth>();
        ballCollider = GameObject.Find("BallPlayerHand");
    }

    // Update is called once per frame
    void Update()
    {
        if (ballCollider == null||ballCollider.name!= "BallPlayerHand")
        {
            ballCollider = GameObject.Find("BallPlayerHand");
            var colliders = new ClothSphereColliderPair[1];
            if (ballCollider)
            {
                colliders[0] = new ClothSphereColliderPair(ballCollider.GetComponent<SphereCollider>());
                cloth.sphereColliders = colliders;
            }
        }
   
        
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BobaGM : MonoBehaviour
{
    //public GameObject[] positions;
    public GameObject Cup, Table,airParticle;
    protected Boba orderDrink;
    public Boba currentDrink;
    public float speed;
    private float Acceleration = 15;

    //How fast will object reach a maximum speed
    private float Deceleration = 15;

    private int i;
    private float MaxSpeed = 10,startTime=1;
    private bool move = false, orderIN = false, air = false, reset = false;
    private float Speed = 0;
    static float t = 0.0f;
    private ParticleSystem ps;

    public void Next()
    {
        if (!move)
        {
            i++;
            Cup.GetComponent<Animator>().SetBool("Move", true);
            Table.GetComponent<Animator>().SetBool("_TableTransition", true);
            //GetComponent<Animator>().SetBool("_move", true);

            Deceleration = Random.Range(0.5f, 0.75f);

            Cup.GetComponent<Animator>().SetFloat("_COffset", Deceleration);
            MaxSpeed = Time.time;
            airMove();
            move = true;
        }
       // Debug.LogWarning(move);
    }

    public void Reset()
    {
        if (!reset)
        {
            Cup.GetComponent<Animator>().SetBool("reset", true);
            reset = true;
        }

    }
    // Start is called before the first frame update
    private void Start()
    {
        currentDrink = Cup.GetComponent<Boba>();
        orderDrink= GetComponent<Boba>();
        ps = airParticle.GetComponent<ParticleSystem>();
    }
    public void airMove()
    {
        air = true;
        startTime = Time.time;
        var no = ps.noise;
        no.strength = 1.0f;
        
    }
    //Don't touch this
    //This is the maximum speed that the object will achieve
    //How fast will object reach a speed of 0

    // Update is called once per frame
    public void Update()
    {
        //Debug.LogWarning(move);
        if (move)
        {  airMove();          
            if (Time.time > MaxSpeed + (1 / Deceleration))
            {
                Cup.GetComponent<Animator>().SetBool("Move", false);
                Table.GetComponent<Animator>().SetBool("_TableTransition", false);
                //Cup.GetComponent<Animator>().SetBool("_move", false);
                
                move = false;
                
            }
        }
        
        if (air)
        {   
            var no = ps.noise;
            no.strength = Mathf.Lerp(2f,0.1f, t*0.7f);

            t += 0.5f * Time.deltaTime;
            if (Time.time > startTime + (1 / Deceleration))
            {

                t = 0;
                air = false;
                
            }
        }
        //if (Cup.GetComponentInChildren<Rigidbody>().IsSleeping())
        //{
        //    Cup.GetComponent<Animator>().SetBool("Move", false);
        //    Table.GetComponent<Animator>().SetBool("_TableTransition", false);
        //    ///move = false;
        //}
        if (reset)
        {
            if (Time.time > MaxSpeed + (1 / Deceleration))
            {
                Cup.GetComponent<Animator>().SetBool("reset", false);

                reset = false;

            }
        }


    }

    public void OrderBoba()
    {
         orderDrink.nPearls=1;
        orderDrink.pearlsType = 0;
        orderDrink.nPowders=1;
         orderDrink.powdersType=0;
         orderDrink.nTeas=1;
         orderDrink.TeasType=0;
         orderDrink.nToppings=1;
         orderDrink.ToppingsType=0;
         orderDrink.Ice=true;
        orderIN = true;
    }
}
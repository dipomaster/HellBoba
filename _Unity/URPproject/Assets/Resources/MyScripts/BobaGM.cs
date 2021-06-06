using UnityEngine;

public class BobaGM : MonoBehaviour
{
    public GameObject[] positions;
    public GameObject Cup,Table;
    private Boba orderDrink;
    public float speed;
    private float Acceleration = 15;

    //How fast will object reach a maximum speed
    private float Deceleration = 15;

    private int i;
    private float MaxSpeed = 10;
    private bool move = false;
    private float Speed = 0;

    public void Next()
    {
        i++;
        Cup.GetComponent<Animator>().SetBool("Move", true);
        Table.GetComponent<Animator>().SetBool("_TableTransition", true);
        //GetComponent<Animator>().SetBool("_move", true);
        

        Deceleration = Random.Range(0.5f, 0.75f);
        Debug.Log(Deceleration);
                GetComponent<Animator>().SetFloat("_COffset", Deceleration);
        MaxSpeed = Time.time;
        move = true;
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    //Don't touch this
    //This is the maximum speed that the object will achieve
    //How fast will object reach a speed of 0

    // Update is called once per frame
    private void Update()
    {
        if (move)
        {
            if (Time.time > MaxSpeed + (1/ Deceleration))
            {
                Cup.GetComponent<Animator>().SetBool("Move", false);
                Table.GetComponent<Animator>().SetBool("_TableTransition", false);
                //GetComponent<Animator>().SetBool("_move", false);
                
                move = false;
            }
        }
    }
    public void OrderBoba()
    {
       // orderDrink.
    }

}
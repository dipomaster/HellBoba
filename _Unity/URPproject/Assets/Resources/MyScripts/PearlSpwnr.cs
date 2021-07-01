using UnityEngine;

public class PearlSpwnr : Spawner
{
    public Boba cup;
    public GameObject[] type;
    public int i= 0;

    // Start is called before the first frame update
    public override void Initialize()
    { 
        if (cup == null)
        {
            cup = GameObject.FindGameObjectWithTag("Cup").GetComponent<Boba>();
        }

        drop = type[i];
        dropsMax = cup.nPearls;
        cup.pearlsType = i;
    }
    public override void Spawn()
    {
        base.Spawn();
        go.transform.parent = cup.transform;
    }
}
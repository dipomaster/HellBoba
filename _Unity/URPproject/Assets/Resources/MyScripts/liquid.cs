using UnityEngine;

public class liquid : PearlSpwnr
{
    // Start is called before the first frame update

    public override void Initialize()
    {
        if (cup == null)
        {
            cup = GameObject.FindGameObjectWithTag("Cup").GetComponent<Boba>();
        }
        drop = type[i];
        dropsMax = cup.nTeas;
        cup.TeasType = i;
    }
}
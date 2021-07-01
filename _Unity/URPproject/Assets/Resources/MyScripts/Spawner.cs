using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool pour = false;
    public GameObject drop;
    public float timeStart, timeElapsed, dropsinscene = 0, dropsMax, timeMultiplier;
    public int burstSize;
    public GameObject go;

    // Start is called before the first frame update
    private void Start()
    {
        Initialize();
        timeStart = Time.time;
    }

    private void FixedUpdate()
    {
        Pouring();
    }

    // Update is called once per frame
    public virtual void Pouring()
    {
        if (dropsinscene < dropsMax)
        {
            if (pour)
            {
                if (Time.time > timeStart + (timeElapsed / timeMultiplier))
                    Spawn();
            }
            else
            {
                timeStart = Time.time;
                pour = true;
            }
        }
    }

    public virtual void Spawn()
    {
        int j;
        for (j = 0; j < burstSize; j++)
        {
            go = Instantiate(drop, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0, 0.2f),1,Random.Range(0, 0.2f)) * -1);
            go.transform.parent = this.transform;
            
            dropsinscene++;

        }
        pour = false;
    }

    public virtual void Initialize()
    {
    }
}
using UnityEngine;

public class Lightning : MonoBehaviour {

    public float speed;
    public float damage;
    public float maxSpeed;
    public float lifespan;

    public float flickerCount;

    private bool showLightningBolt;
    private float numberOfBoltsShown;
    private float count;

    private GameObject owner;
    private Rigidbody body;
    public GameObject lightning;

    public Transform firePoint;
    public Transform AimCircle;


    // Use this for initialization
    void Start()
    {
        this.count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (lifespan < Time.time)
        {
            if (showLightningBolt)
            {
                Vector3 scale = (AimCircle.position - firePoint.position);
                var lightning = Instantiate(this.lightning, this.firePoint.position, this.transform.rotation);
                var homingMissileScript = lightning.GetComponent<Lightning>();
                //lightningScript.setOwner(this.transform.gameObject);
            }
            else
            {
                lifespan += Time.time;
                flickerCount++;
            }
        }
        if (numberOfBoltsShown > flickerCount)
        {
            //then boom and destroy abject
        }

    }
    public void setOwner(GameObject owner)
    {
        this.owner = owner;
    }

    public GameObject getOwner()
    {
        return this.owner;
    }
}

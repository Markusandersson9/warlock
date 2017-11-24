using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    public float speed;
    public float damage;
    public float maxSpeed;
    public float lifespan;

    private GameObject owner;
    private GameObject[] playerObjects;
    private Rigidbody body;

    // Use this for initialization
    void Start()
    {
        this.lifespan = Time.time + lifespan;
        this.playerObjects = GameObject.FindGameObjectsWithTag("Player");
        this.body = this.transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (lifespan < Time.time)
        {
            Destroy(this.transform.gameObject);
        }

        float closestDistance = Mathf.Infinity;
        GameObject closestPlayer = null;

        foreach (var player in playerObjects)
        {
            if(player == owner)
            {
                continue;
            }
            if(closestDistance > (player.transform.position - this.transform.position).magnitude)
            {
                closestPlayer = player;
            }
        }
        Debug.Log(closestDistance +" distance");
        this.transform.LookAt(closestPlayer.transform);
        this.body.AddForce(this.transform.forward * speed);
        this.body.velocity = new Vector3(
            Mathf.Clamp(this.body.velocity.x, -maxSpeed, maxSpeed),
            0,
            Mathf.Clamp(this.body.velocity.z, -maxSpeed, maxSpeed)
        );
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

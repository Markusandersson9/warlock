using UnityEngine;

public class Fireball : MonoBehaviour {

    private Rigidbody body;

    public float speed;
    public float damage;

    private Vector3 direction;

    public Fireball(Vector3 direction)
    {
        this.direction = direction*speed;
    }

	// Use this for initialization
	void Start () {
        this.body = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setDirection(Vector3 direction)
    {
        direction.y = 0;
        this.direction = direction;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * 0.01f);
    }
}

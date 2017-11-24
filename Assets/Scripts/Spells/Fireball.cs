using UnityEngine;

public class Fireball : MonoBehaviour {

    public float speed;
    public float damage;

    private GameObject owner;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
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

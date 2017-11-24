using UnityEngine;

public class Fireball : MonoBehaviour {

    public float speed;
    public float damage;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}

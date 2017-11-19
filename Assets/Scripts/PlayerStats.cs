using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float health;

    private float fatigue;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(this.health <= 0)
        {
            Destroy(this.transform.gameObject);
        }
	}

    public void TakeDamage(float damage)
    {
        this.health -= damage;
    }
}

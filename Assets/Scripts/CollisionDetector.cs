using UnityEngine;

public class CollisionDetector : MonoBehaviour {

    private PlayerStats playerStats;
    private Rigidbody player;

	// Use this for initialization
	void Start () {
        this.playerStats = this.transform.GetComponent<PlayerStats>();
        this.player = this.transform.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider other)
    {
        var spell = other.GetComponent<Fireball>();
        this.playerStats.TakeDamage(spell.damage);
        this.player.velocity = new Vector3(10, 0, 0);
        //this.player.AddForce(new Vector3(1,0,10), ForceMode.Impulse);
        Destroy(other.gameObject);
        Debug.Log(this.playerStats.health);
    }
}

using UnityEngine;

public class CollisionDetector : MonoBehaviour {

    private PlayerState playerStats;
    private Rigidbody player;

	// Use this for initialization
	void Start () {
        this.playerStats = this.transform.GetComponent<PlayerState>();
        this.player = this.transform.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //Need to detect that collision is actually with a spell
        var spell = other.GetComponent<Fireball>();
        this.playerStats.TakeDamage(spell.damage);
        var spellOwner = spell.getOwner();
        var spellOwnerScript = spellOwner.GetComponent<PlayerState>();

        if(this.playerStats.health <= 0.0f) {
            spellOwnerScript.getPlayerStats().incrementKills();
        }

        this.player.AddForce(other.transform.forward*100, ForceMode.Impulse);

        var playerController = this.transform.GetComponent<PlayerController>();
        playerController.friction = 1.001f;             //These two values should be based on player knockback/mana
        playerController.movementAcceleration = 10;     //These two values should be based on player knockback/mana

        Destroy(other.gameObject);
        Debug.Log(this.playerStats.health);
    }
}

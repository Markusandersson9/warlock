using Assets.Scripts;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    public float health;

    private PlayerStats stats;
    private float fatigue;

    // Use this for initialization
    void Start () {
        stats = new PlayerStats();
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
        if(health <= 0)
        {
            stats.incrementDeaths();
        }
    }

    public PlayerStats getPlayerStats()
    {
        return this.stats;
    }
}

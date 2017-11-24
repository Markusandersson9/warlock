using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

    public GameObject[] players;
    public List<PlayerState> playerStates;
    
    // Use this for initialization
    void Start () {
        var playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            var playerObjectScript = player.GetComponent<PlayerState>();
            playerStates.Add(playerObjectScript);
            Debug.Log(playerObjectScript);
            Debug.Log(playerObjectScript.getPlayerStats());

        }
        
    }
	
	// Update is called once per frame
	void Update () {
        foreach (var player in playerStates)
        {
            var playerStats = player.getPlayerStats();
            var kills = playerStats.getKills();
            if(kills == 1)
            {
                Debug.Log("yes we won");
            }
        }
    }
}

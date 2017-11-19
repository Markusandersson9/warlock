using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject[] players;


	// Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");	
	}
	
	// Update is called once per frame
	void Update () {
        this.setCameraPosition();
	}

    private void setCameraPosition()
    {
        var cameraCenter = new Vector3();
        float maxDistance = 0;

        foreach (GameObject player in players)
        {
            foreach (GameObject playerTmp in players)
            {
                if (player == playerTmp)
                {
                    continue;
                }

                Vector2 distance = player.transform.position - playerTmp.transform.position;
                if (distance.magnitude > maxDistance)
                {
                    maxDistance = distance.magnitude;
                }
            }

            cameraCenter += player.transform.position;
        }
        cameraCenter = cameraCenter / players.Length;
        var targetPos = new Vector3(cameraCenter.x, 10 + maxDistance / 3, cameraCenter.z - 2);
        this.transform.position = Vector3.Lerp(this.transform.position, targetPos, 3 * Time.deltaTime); //TODO: Fix this mess!
        //this.transform.position = targetPos;
    }
}

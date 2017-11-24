using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject[] players;
    private float cameraPadding = 2f;
    private float cameraZoomSpeed = 0.15f;

    public float cameraMinX = -10000;
    public float cameraMaxX = 10000f;
    public float cameraMinY = 20f;
    public float cameraMaxY = 30f;
    private float cameraMinZ = -100000f;
    private float cameraMaxZ = 1000000f;

    private Vector3 cameraVelocity; //Only used to pass reference to SmoothDamp function
    private Camera mainCamera;
    private Vector3 cameraOffset;

	// Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");

        this.mainCamera = Camera.main;
        this.cameraOffset = this.transform.position - GetCenterOfCamera();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void FixedUpdate()
    {
        this.cameraOffset = this.transform.position - GetCenterOfCamera();

        var boundingBox = this.getPlayerBoundingBox();  //Find bounding box surronding all players
        this.moveCamera(boundingBox);                   //Move camera to fit players
    }

    private Vector3 GetCenterOfCamera()
    {
        Ray cameraRay = this.mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));     //Get ray from center of camera
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);                        //Find the ground plane (xz-plane at y = 0)
        float distanceToGround;
        groundPlane.Raycast(cameraRay, out distanceToGround);                           //Cast ray to plane, to find camera center
        return cameraRay.GetPoint(distanceToGround);
    }

    private Rect getPlayerBoundingBox()
    {
        var minX = float.MaxValue;
        var maxX = float.MinValue;
        var minY = float.MaxValue;
        var maxY = float.MinValue;

        foreach (GameObject player in players)
        {
            var playerPos = player.transform.position;
            minX = Mathf.Min(minX, playerPos.x);
            maxX = Mathf.Max(maxX, playerPos.x);
            minY = Mathf.Min(minY, playerPos.y);
            maxY = Mathf.Max(maxY, playerPos.y);
        }

        return Rect.MinMaxRect(minX - cameraPadding, minY - cameraPadding, maxX + cameraPadding, maxY + cameraPadding);
    }

    private void moveCamera(Rect boundingBox)
    {
        var distanceBetweenPlayers = (boundingBox.height + boundingBox.width) / 2;

        var targetPos = new Vector3();
        foreach (GameObject player in players)
        {
            targetPos += player.transform.position;
        }
        targetPos /= players.Length;
        targetPos += cameraOffset;
        targetPos.y = distanceBetweenPlayers;

        this.transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref cameraVelocity, cameraZoomSpeed);
       
        //Clamping positions to limit camera movement => should be done differently
        this.transform.position = new Vector3(
            //Mathf.Clamp(this.transform.position.x, cameraMinX, cameraMaxX),
            this.transform.position.x, Mathf.Clamp(this.transform.position.y, 12, 30), this.transform.position.z     //Clamps wrong when I use variables for some reason, needs debug
            //Mathf.Clamp(this.transform.position.z, cameraMinZ, cameraMaxZ)
        );

    }    
}

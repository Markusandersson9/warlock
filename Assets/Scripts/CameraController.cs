﻿using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject[] players;
    private float cameraPadding = 2f;
    private float cameraZoomSpeed = 0.15f;

    public float cameraMinX = -10;
    public float cameraMaxX = 10f;
    public float cameraMinY = 20f;
    public float cameraMaxY = 30f;
    private float cameraMinZ = -10f;
    private float cameraMaxZ = 10f;

    private Vector3 cameraVelocity; //Only used to pass reference to SmoothDamp function
    private Camera camera;
    private Vector3 cameraOffset;

	// Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");

        this.camera = Camera.main;
        this.cameraOffset = this.transform.position - GetCenterOfCamera();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void FixedUpdate()
    {
        var boundingBox = this.getPlayerBoundingBox();  //Find bounding box surronding all players
        this.moveCamera(boundingBox);                   //Move camera to fit players
    }

    private Vector3 GetCenterOfCamera()
    {
        Ray cameraRay = this.camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));     //Get ray from center of camera
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
            Mathf.Clamp(this.transform.position.x, cameraMinX, cameraMaxX),
            Mathf.Clamp(this.transform.position.y, 12, 30),     //Clamps wrong when I use variables for some reason, needs debug
            Mathf.Clamp(this.transform.position.z, cameraMinZ, cameraMaxZ)
        );

    }    
}
using UnityEngine;
using System.Collections;

public class ReticleController : MonoBehaviour {

    private Camera mainCamera;

	// Use this for initialization
	void Start () {
        this.mainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(this.mainCamera.transform.position, Vector3.up);
        var mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);        
        transform.position = new Vector3(mousePosition.x, 1, mousePosition.y);
    }
}

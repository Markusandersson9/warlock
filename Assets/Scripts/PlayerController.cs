using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;
    public string horizontalInput; //String used to get input axis for the selected player
    public string verticalInput; //String used to get input axis for the selected player

    private Rigidbody body;
    private Vector3 movementInput;
    private Vector3 movementVelocity;

	// Use this for initialization
	void Start () {
        this.body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        this.movementInput = new Vector3(Input.GetAxisRaw(horizontalInput), 0, Input.GetAxisRaw(verticalInput));
        this.movementVelocity = this.movementInput * this.movementSpeed;
	}

    void FixedUpdate()
    {
        this.body.velocity = this.movementVelocity;
    }
}

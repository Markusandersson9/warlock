using UnityEngine;

public class AimController : MonoBehaviour {

    public float movementSpeed;
    private Vector3 movementInput;
    private Vector3 movementVelocity;

    public string horizontalInput;
    public string verticalInput;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.movementInput = new Vector3(Input.GetAxisRaw(horizontalInput), Input.GetAxisRaw(verticalInput), 0);
        this.movementVelocity = this.movementInput * this.movementSpeed;
    }

    void FixedUpdate()
    {
        //this.transform.position  .velocity = this.movementVelocity;
        transform.Translate(movementVelocity * Time.deltaTime);

    }
}

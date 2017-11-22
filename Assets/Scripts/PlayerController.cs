using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementAcceleration;
    private float maximumMovementSpeed = 50;
    public float fireballCooldown;
    private float nextFireballTime = 0;

    public string horizontalInput;  //String used to get input axis for the selected player
    public string verticalInput;    //String used to get input axis for the selected player
    public string aButton;
    public float friction = 1.1f;
    private float maximumFriction = 1.1f;

    public GameObject fireball;
    public Transform firePoint;     //Point where spells fire from    

    private Rigidbody body;
    private Vector3 movementInput;
    private Vector3 movementForce;

    // Use this for initialization
    void Start()
    {
        this.body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.getMovementInput();

        if (Input.GetButtonDown(aButton))
        {
            castFireball();
        }
    }

    void FixedUpdate()
    {
        if (movementAcceleration < maximumMovementSpeed)
        {
            movementAcceleration += 0.4f;
        }

        if (friction < maximumFriction)
        {
            friction += 0.001f;
        }

        this.body.AddForce(movementForce);
        this.body.velocity = Vector3.ClampMagnitude(this.body.velocity, 12);

        //Adding some friction when no movement input
        if (movementForce.magnitude <= 0.01f) {
            this.body.velocity /= friction;
        }
    }

    void getMovementInput()
    {
        this.movementInput = new Vector3(Input.GetAxisRaw(horizontalInput), 0, Input.GetAxisRaw(verticalInput));
        this.movementForce = this.movementInput * this.movementAcceleration;
    }

    void castFireball()
    {
        if (Time.time > nextFireballTime)
        {
            var ball = Instantiate(this.fireball, this.firePoint.position, this.transform.rotation);
            if (ball != null)
            {
                var ballscript = ball.GetComponent<Fireball>();
                ballscript.setDirection(this.body.transform.forward);

            }
            this.nextFireballTime = Time.time + fireballCooldown;
        }
    }
}

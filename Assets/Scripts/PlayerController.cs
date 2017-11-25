using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Inputs
    public string horizontalInput;  //String used to get input axis for the selected player
    public string verticalInput;    //String used to get input axis for the selected player
    public string aButton;          //A or X button depending on controller type
    public string bButton;

    //Physical properties
    public float movementAcceleration;
    private float maximumMovementSpeed = 50;   
    public float friction = 1.1f;
    private float maximumFriction = 1.1f;
    private float additionalGravity = 20f; //Makes player fall faster of platform (when y is negative)

    //Cooldowns
    public float fireballCooldown;
    public float homingMissileCooldown;
    private float nextFireballTime = 0;
    private float nextHomingMissileTime = 0;

    public GameObject fireball;
    public GameObject homingMissile;

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

        this.handleButtonInputs();
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

        if(this.transform.position.y < -10)
        {
            Destroy(this.transform.gameObject);
        }

        this.movePlayer();
        this.applyFriction();
        this.addAdditionalGravity();        
    }

    void handleButtonInputs()
    {
        if (Input.GetButtonDown(aButton))
        {
            castFireball();
        }

        if (Input.GetButtonDown(bButton))
        {
            castHomingMissile();
        }
    }

    void movePlayer()
    {
        this.body.AddForce(movementForce);
        this.body.velocity = Vector3.ClampMagnitude(this.body.velocity, 12);
    }

    void addAdditionalGravity()
    {
        if (this.transform.position.y < -0.05f)
        {
            this.body.AddForce(Vector3.down * this.additionalGravity);
        }
    }

    void applyFriction()
    {
        //Adding some friction when no movement input
        if (movementForce.magnitude <= 0.01f)
        {
            this.body.velocity /= friction;
        }
    }

    void getMovementInput()
    {
        this.movementInput = new Vector3(Input.GetAxisRaw(horizontalInput), 0, Input.GetAxisRaw(verticalInput));
        this.movementForce = this.movementInput * this.movementAcceleration;
    }
    
    void castHomingMissile()
    {
        if (Time.time > nextHomingMissileTime)
        {
            var homingMissile = Instantiate(this.homingMissile, this.firePoint.position, this.transform.rotation);
            var homingMissileScript = homingMissile.GetComponent<HomingMissile>();
            homingMissileScript.setOwner(this.transform.gameObject);
            this.nextHomingMissileTime = Time.time + homingMissileCooldown;
        }
    }

    void castFireball()
    {
        if (Time.time > nextFireballTime)
        {
            var fireball = Instantiate(this.fireball, this.firePoint.position, this.transform.rotation);
            var fireballScript = fireball.GetComponent<Fireball>();
            fireballScript.setOwner(this.transform.gameObject);   
            this.nextFireballTime = Time.time + fireballCooldown;
        }
    }
}

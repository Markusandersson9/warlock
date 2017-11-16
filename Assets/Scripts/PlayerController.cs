using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    public float fireballCooldown;
    private float nextFireballTime = 0;

    public string horizontalInput; //String used to get input axis for the selected player
    public string verticalInput; //String used to get input axis for the selected player
    public GameObject fireball;

    private Rigidbody body;
    private Vector3 movementInput;
    private Vector3 movementVelocity;

    // Use this for initialization
    void Start()
    {
        this.body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.getMovementInput();

        if (Input.GetAxisRaw("Fire1") != 0)
        {
            castFireball();
        }
    }

    void FixedUpdate()
    {
        this.body.velocity = this.movementVelocity;
    }

    void getMovementInput()
    {
        this.movementInput = new Vector3(Input.GetAxisRaw(horizontalInput), 0, Input.GetAxisRaw(verticalInput));
        this.movementVelocity = this.movementInput * this.movementSpeed;
    }

    void castFireball()
    {
        if (Time.time > nextFireballTime)
        {
            var ball = Instantiate(this.fireball, this.transform.position + new Vector3(0, 0, 2), this.transform.rotation);
            if (ball != null)
            {
                var ballscript = ball.GetComponent<Fireball>();
                ballscript.setDirection(this.body.rotation.eulerAngles);

            }
            this.nextFireballTime = Time.time + fireballCooldown;
        }
    }
}

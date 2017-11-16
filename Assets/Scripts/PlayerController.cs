using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    public float cooldown;
    private float cooldownTimer = 0;
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
        this.movementInput = new Vector3(Input.GetAxisRaw(horizontalInput), 0, Input.GetAxisRaw(verticalInput));
        this.movementVelocity = this.movementInput * this.movementSpeed;
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            castFireball();
        }

        this.cooldownTimer += Time.deltaTime;
    }

    void FixedUpdate()
    {
        this.body.transform.Rotate(Vector3.right * 10);
        this.body.velocity = this.movementVelocity;
    }

    void castFireball()
    {

        if (cooldownTimer > cooldown)
        {

            var ball = Instantiate(this.fireball, this.transform.position + new Vector3(0, 0, 2), this.transform.rotation);
            if (ball != null)
            {
                var ballscript = ball.GetComponent<Fireball>();
                ballscript.setDirection(this.body.rotation.eulerAngles);

            }
            this.cooldownTimer = 0;
        }
    }
}

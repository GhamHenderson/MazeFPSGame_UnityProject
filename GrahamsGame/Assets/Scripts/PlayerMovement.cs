using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Jump
    public Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;

    // Movement
    private float speed = 10.0f;
    private float turnSpeed = 70.0f;
    private float horizontalInput;
    private float forwardInput;
    public bool isOnGround = true;
    Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        RunAndJump();
    }
 

    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
    }



    void RunAndJump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

        }

        if (speed < 1)
        {
            anim.SetBool("Walk", true);

        }

        if (speed == 0)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            speed = 17;
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            anim.SetBool("Walk", false);
            anim.SetBool("Run", true);
        }
        // Stop run on release of key
        if (Input.GetKeyUp(KeyCode.Q))
        {
            speed = 10;
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            anim.SetBool("Run", false);
            anim.SetBool("Walk", true);


        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("Knife", true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            anim.SetBool("Knife", false);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("levelup"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.CompareTag("healthpack"))
        {
            HealthBar.health += 50;
            Destroy(GameObject.FindGameObjectWithTag("healthpack"));
        }

       
    }
}

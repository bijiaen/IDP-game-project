using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform groundCheckTransform;
    public LayerMask playerMask;

    private float coinCounter = 0;
    private Rigidbody rigidbodyComponent;
    private bool jumpKeyWasPressed;
    private float horizontalInput;


    public int maxHealth = 3;
	public int currentHealth;

	public HealthBar healthBar;
    // Start is called before the first frame update
    // Start is from unity MonoBehaviour   
    void Start()
    {
        Debug.Log("Test");
        rigidbodyComponent = GetComponent<Rigidbody>();

        currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    // Update is from unity MonoBehaviour
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");



     if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(1);
		}
    }

    // FixedUpdate is called once every physic update

    void FixedUpdate()
    {
        //left and right with a and d keys
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);

        //Method #1 to check for collision: 

        //Checking for collision by checking if our spheres overlap. Which sphere? A sphere of radius 0.1, at with center at groundCheckTransform
        //Physics.OverlapSphere(groundCheckTransform.position, 0.1f) returns an array of collision points
        //So for it to not collide with anything (be in the air), Length == 1
        //Length == 1 and not 0 is because it is always colliding with the Player

        //if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1)
        //{
        //    return;
        //}

        //Method #2 to check for collision:
        //This is the more proper way to detect collision

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        //jump
        if (jumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 6, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            coinCounter++;
            Debug.Log(coinCounter);
        }

        if(collision.tag == "enemies")
        {
            var healthComponent = collision.GetComponent<Health>();
            if(healthComponent != null)
            {
                healthComponent.TakeDamage(1);
            }
        }
    }
    void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

   
}

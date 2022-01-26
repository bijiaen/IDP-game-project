using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public Transform groundCheckTransform;
    public LayerMask playerMask;

    public int maxHealth = 100; //health
	public int currentHealth;//health
    public HealthBar healthBar;//health

    public Text coinTextElement;
    private int lCoin;
    private int tCoin;
    private string coinTextValue = "Coins: 0";

    private Rigidbody rigidbodyComponent;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    public Rigidbody rb;

    // Start is called before the first frame update
    // Start is from unity MonoBehaviour   
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        
        currentHealth = maxHealth;//health
		healthBar.SetMaxHealth(maxHealth);//health

        lCoin = 0;
        tCoin = PlayerPrefs.GetInt("totalcoins", 15);

        Debug.Log("tcoin at start" + tCoin);


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
        coinTextElement.text = coinTextValue;

        //fall
        if (rb.position.y<=-10f)
        {
            GameOver();
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
            lCoin++;

            coinTextValue = "Coins: " + lCoin.ToString();
            Debug.Log(lCoin);
        }
        else if(other.gameObject.layer == 12)
        {
            Destroy(other.gameObject);
            TakeDamage(60);
        }
        else if(other.gameObject.layer == 11)
        {
            TakeDamage(20);
        }
        else if (other.gameObject.layer == 10)
        {
            Debug.Log("END OF GAME!!");
        }
        
    }

    void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0){
            GameOver();
        }
	}//health

    public void GameOver(){
        PlayerPrefs.SetInt("levelcoins", lCoin);

        SceneManager.LoadScene("GameOver");
    }

    public void EndGame()
    {
        tCoin += lCoin;
        PlayerPrefs.SetInt("totalcoins", tCoin);
        PlayerPrefs.SetInt("levelcoins", lCoin);

        //SceneManager.LoadScene();
    }
   

   
}

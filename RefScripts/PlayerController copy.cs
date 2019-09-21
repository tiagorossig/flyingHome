using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //used to restart scene
using UnityEngine.UI; //used to manipulate health and gold trackers

public class PlayerController : MonoBehaviour
{
    public Slider healthBar; //creates a public slider object to track health
    public Text coinCounter, healthCounter; //creates a text box measuring both coins collected and health remaining

    public float moveSpeed; //create a number with a decimal for our movement speed
    private bool isGrounded = true; //create a boolean to see if our box is on the ground
    private int coinsCollected = 0; //create a number for coins collected
    private int health = 100; //create a number representing our health
    private bool hasKey = false; //create a boolean to see if we have the key

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 7f; //set the movement speed to 7
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //check to see if the space bar is pressed && box is on ground
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 180); //add force to make the box jump into the air
            isGrounded = false; //the box is no longer on the ground
        }
        //this is the character controller
        //this moves the box in the direction of the axis (left or right and up or down)
        //times Time.deltaTime which allows it to run at a constant frame rate 
        //and times our movement speed so it moves more than 1f each time.
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);


    }

    private void OnCollisionEnter(Collision collision) //is called on collision with something
    {
        //checks to see if the box is on the ground after a jump
        if (collision.gameObject.tag == ("Ground") && !isGrounded)
        {
            isGrounded = true; //says that the box is on the ground now
        }

    }

    private void OnTriggerEnter(Collider other) //is called on collision with a trigger object
    {
        if (other.tag == "Coin") //check to see if the game object is tagged Coin
        {
            Instantiate(Resources.Load("effect"), other.transform.position, other.transform.rotation); //place particle on the coin collected
            Destroy(other.gameObject); //destroys the physical object in game
            coinsCollected++; //increases value by one to track number of coins collected
            coinCounter.text = "Gold: " + coinsCollected; //prints the number of coins collected on screen
        }
        if (other.tag == "Trap") //check to see if game Object is tagged Trap
        {
            health = health - 10; //subtract 10 from health
            healthBar.value = health; //updates health bar based on new value
            healthCounter.text = "Health: " + health; //prints remaining health on screen
            if (health <= 0) //checks to see if health is less than/equal to 0
            {
                // SceneManager.LoadScene(0);
            }
        }
        if (other.tag == "Key") //check to see if game object is tagged Key
        {
            Destroy(other.gameObject); //destroys the key after gaining it
            hasKey = true; //sets the boolean hasKey to true (player has key)
        }
        if (other.tag == "Door" && hasKey) //check to see if the object is tagged door and that the player had the key
        {
            other.GetComponent<Animator>().SetTrigger("Open"); //animate the door opening
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //allows us to use the slider agents

public class Enemy : MonoBehaviour
{
    public int coolDown; //create a cooldown timer
    private float attackTimer; //create an attack timer 
    public GameObject selector; //create a game object to show the enemies are selected
    public Slider HealthBar; //create a health bar for the enemy
    private int health = 50; //give the enemy 100 points of health

    // Start is called before the first frame update
    void Start()
    {
        attackTimer = coolDown; //set the attack timer equal to the cooldown timer
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime; //keeps track of the time that has passed
        if(attackTimer < 1.88f) //if my attack timer is less than a quarter of a sec, start the animation
        {
            GetComponentInChildren<Animator>().SetTrigger("Attack"); //run the animation
        }
        if (attackTimer <= 0) //check to see if the time has run out 
        {
            attackTimer = coolDown; //reset timer
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position); //have the enemy look at the player object
            //spawn a new projectile as a temporary game object named fireball
            GameObject fireball = Instantiate(Resources.Load("Projectile"), transform.position, transform.rotation) as GameObject;
            fireball.GetComponent<Rigidbody>().AddForce(transform.forward * 300); //send the firreball at the player
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Melee") //check to see if they collided with the melee attack
        {
            health -= 25; //take 25 damage from the attack
            HealthBar.value = health; //update the health bar
            if(health <= 0) //if health is less than 0
            {
                GetComponentInChildren<Animator>().SetTrigger("Die"); //play death animation
                Destroy(gameObject, 4f); //kill the enemy after the animation
            }
        }
    }
}

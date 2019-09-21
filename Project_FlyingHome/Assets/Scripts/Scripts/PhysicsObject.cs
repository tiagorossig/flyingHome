using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{

    public float minGroundNormalY = .65f; //public variables, can change in engine
    public float gravityModifier = 1f;

    protected Vector2 targetVelocity; //protected variables, only accessed by classes inheriting Physics Object
    protected bool grounded;
    protected Vector2 groundNormal;
    protected Rigidbody2D rb2d;
    protected Vector2 velocity;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16]; //hit buffer = detects objects in a scene
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);


    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>(); //get the rigidbody component reference
    }

    void Start()
    {
        contactFilter.useTriggers = false; //not checking contact w/ triggers
        //physics2D uses a layer collison matrix; function says "use these settings to check collison"
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer)); 
        contactFilter.useLayerMask = true; 
    }

    void Update() //runs ever frame - regardless of time
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity(); //gets overridden in the platform controller
    }

    protected virtual void ComputeVelocity()
    {

    }

    void FixedUpdate() //runs after a fixed number of frames
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime; //move object downward every frame
        velocity.x = targetVelocity.x;

        grounded = false; //always false (the movement function would set grounded true)

        Vector2 deltaPosition = velocity * Time.deltaTime; //the change in position 

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x); // follows the line of the ground; perpendiicular to position

        Vector2 move = moveAlongGround * deltaPosition.x; //passes to movement function; 

        Movement(move, false); //movement for x axis 

        move = Vector2.up * deltaPosition.y; //move y movement

        Movement(move, true); //boolean is to see if moving along y axis
    }

    void Movement(Vector2 move, bool yMovement)
    {
        //collisons for physics objects
        float distance = move.magnitude;

        //collison projections below::
        if (distance > minMoveDistance) //only apply collison if distance > a minimum value
        {
            //rigidbody2d.cast = ignores other colliders on player; checks to see if there's a collison
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius); //shell makes sure we dont get stuck in another collider
            hitBufferList.Clear(); //clear the list of old data
            for (int i = 0; i < count; i++) //take the hitBuffer array and add it to the list
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++) //check the normal of each hit object (determine angle)
            {
                Vector2 currentNormal = hitBufferList[i].normal; //checks the normal of the list
                if (currentNormal.y > minGroundNormalY) //if player is gonna collide w/ a piece of ground 
                {
                    grounded = true; //is on a "ground" surface
                    if (yMovement) 
                    {
                        groundNormal = currentNormal; 
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(velocity, currentNormal); //get the difference between velocity and currentNormal; prevent player from entering another collider

                if (projection < 0)
                {
                    velocity = velocity - projection * currentNormal; //cancel out the part that is stopped by collison
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius; //check is the distance is < than our distance
                distance = modifiedDistance < distance ? modifiedDistance : distance; //keeps us from being stuck in colliders
            }


        }

        rb2d.position = rb2d.position + move.normalized * distance; //add movement vector to rigidbody; move the body

    }

}
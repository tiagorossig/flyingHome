using UnityEngine;
using System.Collections;

public class camera: MonoBehaviour
{
    //instance variables
    public Transform player;
    private float center = 7.1f;

    // Update is called once per frame  
    void FixedUpdate()
    {
        //update camera pos 
        transform.position = new Vector3(0.0f, center, -10.0f);

        //if in screen 1, keep camera in screen 1
        if (player.position.y > 5)
            center = 7.1f;

        //if bird is past y = 5, start scrolling down.
        if (player.position.y < 5 && transform.position.y > -7.25)
            center = center - 0.065f;



        //This is the start of trying to automate the code for changing screens
        //instead of 5 hard coded screens 
        //ignore what's under this comment


        //RaycastHit hit;

        //if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        //    print("Found an object - distance: " + hit.distance);


    }
}
using UnityEngine;
using System.Collections;

public class CameraMovement1 : MonoBehaviour
{
    //instance variables
    public Transform player;
    private float center;

    // Update is called once per frame  
    void FixedUpdate()
    {
        //update camera pos 
        transform.position = new Vector3(0.0f, center, -10.0f);

        //if in screen 1, keep camera in screen 1
        if (player.position.y < -5.5)
            center = -7.6f;

        //if in screen 2, keep camera in screen 2
        if (player.position.y > -5.5f && player.position.y < -1.3f)
            center = -3.4f;

        //if in screen 3, keep camera in screen 3
        if (player.position.y > -1.3f && player.position.y < 2.9f)
            center = 0.8f;

        //if in screen 4, keep camera in screen 4
        if (player.position.y > 2.9f && player.position.y < 7.1f)
            center = 5.0f;

        //if in screen 5, keep camera in screen 5
        if (player.position.y > 7.1f)
            center = 9.2f;


        //This is the start of trying to automate the code for changing screens
        //instead of 5 hard coded screens 
        //ignore what's under this comment


        //RaycastHit hit;

        //if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        //    print("Found an object - distance: " + hit.distance);


    }
}
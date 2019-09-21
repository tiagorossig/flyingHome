using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    // array of waypoints to move between
    // waypoints are just empty GameObjects set at desired locations
    [SerializeField]
    Transform[] waypoints;
    // speed of enemy
    [SerializeField]
    float moveSpeed = 1f;
    // start of array
    int waypointIndex = 0;

    void Start()
    {
        // sets enemy position to first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // moves enemy in direction of next waypoint
        transform.position = Vector2.MoveTowards(transform.position,
                                                waypoints[waypointIndex].transform.position,
                                                moveSpeed * Time.deltaTime);
        // once waypoint is reached, changes waypoint to next one in array
        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }
        // changes waypoint back to first in array
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

}

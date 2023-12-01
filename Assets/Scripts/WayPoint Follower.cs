using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower: MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currrentWaypointIndex = 0;

    [SerializeField] float speed = 1f;

    void Update()
    {

        if (Vector3.Distance(transform.position, waypoints[currrentWaypointIndex].transform.position) < .1f)
        {
            currrentWaypointIndex++;
            if (currrentWaypointIndex >= waypoints.Length)
            {
                currrentWaypointIndex = 0;
            }
        }
        
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currrentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}

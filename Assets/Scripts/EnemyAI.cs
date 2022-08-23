using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 1.3f;

    Path path;
    int currentWaypoint = 0;
    bool reachEndofpath = false;

    Seeker seeker;
    Rigidbody2D myBody;


    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        myBody = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachEndofpath = true;
            return;
        }
        else
        {
            reachEndofpath = false;
            return;
        }
        Vector2 direction = (Vector2)path.vectorPath[currentWaypoint] - myBody.position.normalized;
        Vector2 Force = direction * speed * Time.deltaTime;

        myBody.AddForce(Force);

        float Distance = Vector2.Distance(myBody.position, path.vectorPath[currentWaypoint]);


    }
    void UpdatePath()
    {
        if(seeker.IsDone())
        seeker.StartPath(myBody.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}

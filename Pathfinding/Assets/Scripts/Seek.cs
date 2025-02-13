using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public GameObject target;
    public float maxVelocity, maxRotation;

    //public Transform[] waypoints;


    private int current;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (target.transform.position - transform.position).normalized;
        Vector3 velocity = dir * maxVelocity * Time.deltaTime;
        transform.position += velocity;

        //if (transform.position != waypoints[current].position)
        //{
        //    Vector3 dir = (waypoints[current].position - transform.position).normalized;
        //    Vector3 velocity = dir * maxVelocity * Time.deltaTime;
        //    transform.position += velocity;
        //}
        //else current = (current + 1) % waypoints.Length;




        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, maxRotation * Time.deltaTime);

    }
}

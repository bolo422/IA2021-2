using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    public GameObject target;
    public float maxVelocity, maxRotation;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (transform.position - target.transform.position).normalized;
        Vector3 velocity = dir * maxVelocity * Time.deltaTime;
        transform.position += velocity;

        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, maxRotation * Time.deltaTime);
    }
}

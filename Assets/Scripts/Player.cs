using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    public float acceleration;
    public float maxSpeed;
    public float friction;
    Vector3 vel;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        vel += new Vector3(h * acceleration, 0, 0) * Time.deltaTime;

        if(vel.magnitude > maxSpeed)
        {
            vel = vel.normalized * maxSpeed;
        }

        vel *= friction;

        transform.position = transform.position + vel;
    }
}
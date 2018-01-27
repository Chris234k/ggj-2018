using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour 
{
    public Ball ball;

    public float acceleration;
    public float maxSpeed;
    public float friction;

    public float throwForce;
    Vector3 vel;

    Rigidbody2D localRigid;

    void Awake()
    {
        localRigid = GetComponent<Rigidbody2D>();
    }

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

        if(Input.GetMouseButton(0))
        {
            Vector3 world_mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dir = world_mouse_pos - transform.position;
            Vector3 force = dir.normalized * throwForce;

            ball.Throw(force);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ball.Recall(transform.position, localRigid);
        }
    }
}
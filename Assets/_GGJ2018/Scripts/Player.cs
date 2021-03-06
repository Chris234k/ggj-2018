﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Prime31;

[RequireComponent(typeof(CharacterController2D))]
public class Player : MonoBehaviour
{
    public Ball ball;

    public float acceleration;
    public float maxSpeed;
    public float friction;

    public float gravityModifier;

    public float throwForce;

    private Checkpoint LastCheckPoint;

    CharacterController2D controller;

    void Awake()
    {
        controller = GetComponent<CharacterController2D>();        
    }

    void Start()
    {
        ball.Recall(transform.position, gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 world_mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = (world_mouse_pos - (Vector2)transform.position).normalized;
            Vector2 force = dir * throwForce;

            ball.Throw(force);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            ball.Recall(transform.position, gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ball.Interact();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = ball.Swap(transform.position);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        Vector2 vel = Physics2D.gravity * gravityModifier;
        vel.x = h * acceleration;

        vel *= Time.fixedDeltaTime;

        if (vel.magnitude > maxSpeed)
        {
            vel = vel.normalized * maxSpeed;
        }

        vel *= friction;

        controller.move(vel);
    }

    public void SetCheckpoint(Checkpoint inCheckpoint)
    {
        LastCheckPoint = inCheckpoint;
    }

    public void ResetPlayer()
    {
        if (LastCheckPoint != null)
        {
            transform.position = LastCheckPoint.transform.position;
            ball.Recall(transform.position, gameObject);
        }
    }
}
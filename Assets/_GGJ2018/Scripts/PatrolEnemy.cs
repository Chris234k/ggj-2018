using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PatrolEnemy : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;

    public float WalkingSpeed;
    public float RedirectionInterval;
    private int currentFacingDirection = -1;
    private float redirectionTimer;

    public bool bShouldJump;
    public float JumpStrength;
    public float JumpInterval = 0.0f;
    private float jumpTimer;

    // Use this for initialization
    void Start ()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = (Vector2)transform.position + new Vector2(currentFacingDirection * WalkingSpeed * Time.deltaTime, 0);
        redirectionTimer += Time.deltaTime;
        if (bShouldJump)
        {
            jumpTimer += Time.deltaTime;
        }
        if (jumpTimer > JumpInterval)
        {
            Jump();
        }
        if (redirectionTimer > RedirectionInterval)
        {
            RedirectMovement();
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Player playerReference = coll.gameObject.GetComponent<Player>();
            if (playerReference != null)
            {
                playerReference.ResetPlayer();
            }
        }

    }

    void RedirectMovement()
    {
        currentFacingDirection *= -1;
        redirectionTimer = 0.0f;
    }

    void Jump()
    {
        jumpTimer = 0.0f;
        Rigidbody2D.AddForce(new Vector2(0, JumpStrength));
    }
}

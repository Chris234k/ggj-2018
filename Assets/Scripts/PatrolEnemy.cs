using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PatrolEnemy : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public float WalkingSpeed;
    public float RedirectionTime;

    private int currentFacingDirection = -1;
    private float redirectionTimer;

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
        if (redirectionTimer >= RedirectionTime)
        {
            currentFacingDirection *= -1;
            redirectionTimer = 0.0f;
        }
	}
}

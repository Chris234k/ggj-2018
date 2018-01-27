using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    public LayerMask mask;
    GameObject lastHit;

    bool isHalf;

    void Update () 
	{
        if (Input.GetKeyDown(KeyCode.W))
        {
            Teleport(Vector2.up);
        }
		else if (Input.GetKeyDown(KeyCode.A))
        {
			Teleport(Vector2.left);
        }
		else if (Input.GetKeyDown(KeyCode.S))
        {
            Teleport(Vector2.down);
        }
		else if (Input.GetKeyDown(KeyCode.D))
        {
            Teleport(Vector2.right);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isHalf = !isHalf;
        }
    }

    void Teleport(Vector2 dir)
    {
        var hit = Physics2D.Raycast(transform.position, dir, 100, mask.value, 0);

        if (hit != null && hit.collider != null && hit.collider.gameObject != null)
        {
            if (lastHit != null)
            {
                lastHit.layer = 8;
            }

            transform.position = hit.transform.position;
            lastHit = hit.collider.gameObject;
            lastHit.layer = 0;
        }
    }
}

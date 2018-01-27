using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour 
{
	Rigidbody2D localRigid;

	bool isRecalling;
	public float recallSpeed;
	float recallDuration;
	Rigidbody2D recallTarget;

	bool isConnectedToPlayer;

	FixedJoint2D joint;

	void Awake()
	{
		localRigid = GetComponent<Rigidbody2D>();

		joint = gameObject.AddComponent<FixedJoint2D>();
        joint.enabled = false;
		joint.autoConfigureConnectedAnchor = false;
	}

	public void Attack()
	{

	}

	public void Throw(Vector2 force)
	{
		if(isConnectedToPlayer)
		{
			Disconnect();
			localRigid.AddForce(force);
		}
	}

	public void Recall(Vector2 pos, Rigidbody2D target)
	{
		if(!isRecalling && !isConnectedToPlayer)
		{
			isRecalling = true;
			recallTarget = target;

			localRigid.isKinematic = true;
			localRigid.velocity = Vector2.zero;
		}
	}

	void Update()
	{
		if(isRecalling)
		{
			Vector3 pos = recallTarget.transform.position;
			float dist = Vector2.Distance(transform.position, pos);
			
			if(dist > 0.005f)
			{
				transform.position = Vector2.MoveTowards(transform.position, pos, dist * recallSpeed * Time.deltaTime);
			}
			else
			{
				localRigid.isKinematic = false;
				isRecalling = false;

				if(recallTarget != null)
				{
					Connect(recallTarget);
				}
			}	
		}
	}

	void Connect(Rigidbody2D target)
	{
		localRigid.velocity = Vector2.zero;
		joint.enabled = true;
		joint.connectedBody = target;
		isConnectedToPlayer = true;
	}

	void Disconnect()
	{
		localRigid.velocity = Vector2.zero;
		joint.enabled = false;
		joint.connectedBody = null;
		isConnectedToPlayer = false;
	}
}
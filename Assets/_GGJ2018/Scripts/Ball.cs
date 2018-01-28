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
	GameObject recallTarget;

	bool isConnectedToPlayer;

	FixedJoint2D joint;

	void Awake()
	{
		localRigid = GetComponent<Rigidbody2D>();

		joint = gameObject.AddComponent<FixedJoint2D>();
        joint.enabled = false;
		joint.autoConfigureConnectedAnchor = false;
	}

	void Update()
	{
		if(isRecalling)
		{
			Vector3 pos = recallTarget.transform.position;
			float dist = Vector2.Distance(transform.position, pos);
			
			if(dist > 2.0f)
			{
				// Further = faster
				float move = dist * recallSpeed;
				move = Mathf.Max(recallSpeed, move);
				
				transform.position = Vector2.MoveTowards(transform.position, pos, move * Time.deltaTime);
			}
			else
			{
				localRigid.isKinematic = false;
				isRecalling = false;

				if(recallTarget != null)
				{
					Connect();
				}
			}
		}
	}

	public Vector2 Swap(Vector2 position)
	{
		if(!isConnectedToPlayer)
		{
			Vector2 oldPos = transform.position;
			transform.position = position;

			localRigid.velocity = Vector2.zero;

			return oldPos;
		}
		else
		{
			return position;
		}
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

	public void Recall(Vector2 pos, GameObject target)
	{
		if(!isRecalling && !isConnectedToPlayer)
		{
			isRecalling = true;
			recallTarget = target;

			localRigid.isKinematic = true;
			localRigid.velocity = Vector2.zero;
		}
	}

	void Connect()
	{
		gameObject.SetActive(false);
		transform.position = recallTarget.transform.position;
		localRigid.velocity = Vector2.zero;
		isConnectedToPlayer = true;
	}

	void Disconnect()
	{
		gameObject.SetActive(true);
		transform.position = recallTarget.transform.position;
		localRigid.velocity = Vector2.zero;
		isConnectedToPlayer = false;
	}
}
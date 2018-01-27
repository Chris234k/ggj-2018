using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour 
{
	Rigidbody2D localRigid;
	private bool isRecalling;

	void Awake()
	{
		localRigid = GetComponent<Rigidbody2D>();
	}

	public void Attack() 
	{

	}

	public void Throw(Vector2 force)
	{
		localRigid.AddForce(force);
	}

	public void Recall(Vector2 pos)
	{
		if(!isRecalling)
		{
			StartCoroutine(RecallRoutine(pos, 1f));
		}
	}

	IEnumerator RecallRoutine(Vector2 pos, float duration)
	{
		isRecalling = true;
		localRigid.isKinematic = true;
		localRigid.velocity = Vector2.zero;
		
		float elapsedTime = 0;
		while(elapsedTime < duration)
		{
			float t = elapsedTime / duration;
			transform.position = Vector2.Lerp(transform.position, pos, t);

			yield return new WaitForEndOfFrame();
			elapsedTime += Time.deltaTime;
		}
		localRigid.isKinematic = false;
		isRecalling = false;
	}
}
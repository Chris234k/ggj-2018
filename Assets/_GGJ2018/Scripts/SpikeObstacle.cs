﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeObstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

}

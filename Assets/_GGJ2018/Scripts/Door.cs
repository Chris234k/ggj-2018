using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Key keyToUnlock;

	// Use this for initialization
	void Start ()
    {
        if (keyToUnlock != null)
        {
            keyToUnlock.OnKeyActivated += HandleOnKeyActivated;
        }
	}

    void OnDestroy()
    {
        keyToUnlock.OnKeyActivated -= HandleOnKeyActivated;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void HandleOnKeyActivated()
    {
        Destroy(this.gameObject);
    }
}

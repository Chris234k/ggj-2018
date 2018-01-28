using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IBallable
{
    public delegate void KeyActivatedAction();
    public event KeyActivatedAction OnKeyActivated;

    public bool BallInteractKey;

    private SpriteRenderer spriteRenderer;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BallInteract()
    {
        if (BallInteractKey)
        {
            ActivateKey();
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && !BallInteractKey)
        {
            Destroy(coll.gameObject);
        }

    }

    void ActivateKey()
    {
        if (OnKeyActivated != null)
        {
            OnKeyActivated();
        }
        spriteRenderer.color = Color.red;
    }
}

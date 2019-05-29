using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackGround : MonoBehaviour {
	private float groundHorizantal;
	private BoxCollider2D collider;

	// Use this for initialization
	void Awake () {
		collider = GetComponent<BoxCollider2D> ();
		groundHorizantal = collider.size.y;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y>groundHorizantal) {
			RepositionBackGround ();
		}
		
	}

	private void RepositionBackGround(){
		Vector2 groundoffset = new Vector2 (0, groundHorizantal * 2f);
		transform.position = (Vector2)transform.position - groundoffset;

	}
}

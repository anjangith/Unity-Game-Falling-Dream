using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {
	private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		rigidbody.velocity = new Vector2 (0, GameControl.instance.scrollSpeed);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameControl.instance.gameOver == true) {
			rigidbody.velocity = Vector2.zero;
		
		} else {
			
			rigidbody.velocity = new Vector2 (0, GameControl.instance.scrollSpeed);
		}
	}
}

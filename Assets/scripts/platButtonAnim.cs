using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platButtonAnim : MonoBehaviour {
	public GameObject button;
	public Transform target;
	float step;
	public float speed;
	private Vector2 finalPos;

	int xPos;
	int yPos;
	// Use this for initialization
	void Start () {

		Vector2 Pos = new Vector2 (target.position.x, target.position.y);
		finalPos = Camera.main.ScreenToWorldPoint (Pos);
		xPos = Screen.width/4;
		yPos = Screen.width/4;


		
	}
	
	// Update is called once per frame
	void Update () {

		step = speed * Time.deltaTime;
		button.transform.position = Vector3.MoveTowards (button.transform.position, target.position, step);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlay : MonoBehaviour {

	RectTransform uiEle;
	//public Transform target;
	float step;
	private Vector2 finalPos;
	private Vector2 secondFinalPos;
	int xPos,yPos;

	// Use this for initialization
	void Start () {

		uiEle = gameObject.GetComponent<RectTransform> ();
		//finalPos = Camera.main.ScreenToWorldPoint (target.position);
		xPos = Screen.width / 2;
		yPos = Screen.width / 2;
		finalPos = new Vector2 (xPos, yPos);
		secondFinalPos = Camera.main.ScreenToWorldPoint (finalPos);


	}
	
	// Update is called once per frame
	void Update () {

		uiEle.position = Vector3.MoveTowards (transform.position, finalPos, 15);
		
	}
}

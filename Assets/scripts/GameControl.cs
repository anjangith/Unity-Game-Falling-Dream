using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
	public static GameControl instance;
	public bool gameOver = false;
	public float scrollSpeed=-1.5f;
	public GameObject Rbutton;


	void Awake(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}

	}
	// Use this for initialization
	void Start () {
		Rbutton.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

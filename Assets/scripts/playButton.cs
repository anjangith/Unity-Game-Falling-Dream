using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playButton : MonoBehaviour {
	public GameObject button;
	private Animator animator;
	public GameObject hand;
	public GameObject player;
	private Animator playerAnim;
	public GameObject scorePanel;
	private Vector2 finalPos;
	public bool sim = false;
	public static playButton Instance;
	public Transform pos;
	private TMPro.TextMeshProUGUI gui;
	float speed=900f;
	int xPos;
	int yPos;
	private Vector2 postFinalPos;
	private RectTransform rect;
	// Use this for initialization
	void Start () {
		animator = hand.GetComponent<Animator> ();
		playerAnim = player.GetComponent<Animator> ();
		rect = scorePanel.GetComponent<RectTransform> ();
		Vector2 vex = new Vector2 (Screen.width/2 , Screen.height/2 );
		Vector2 fin = Camera.main.ScreenToWorldPoint (vex);
	//	scorePanel.transform.position = new Vector2 (Screen.width/2-50f,Screen.height-20f);




	}

	void Awake(){
		

		if (Instance == null) {
			Instance = this;
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (sim) {


		}
		
		

		
		
	}

	public void stop ()
	{
			button.SetActive (false);
			playerAnim.SetTrigger ("fall");
			
			animator.SetTrigger ("movement");
			
			GameControl.instance.gameOver = false;
			Destroy (hand, 3);
			sim = true;

			


	}

	public void Reload(){

		SceneManager.LoadScene ("scene");



	}


}

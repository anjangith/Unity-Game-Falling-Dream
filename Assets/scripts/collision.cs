using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collision : MonoBehaviour {
	private Animator animator;
	public GameObject dynamite;
	public GameObject Rbtn;
	public Text text;
	private int count;
	public GameObject player;
	private Animator dynamiteAnimator;
	public Transform initialPos;
	public Transform finalPos;
	public GameObject panel;
	public float speed;
	public TMPro.TextMeshProUGUI score;
	public TMPro.TextMeshProUGUI panelScore;
	private float time = 0;
	private GameObject particlePrefab;
	public AudioClip backGround;
	public AudioClip starCollect;
	public AudioClip enemyBreak;
	public AudioClip enemyBlast;
	public AudioClip enemySound;
	public AudioSource audioSource;
	public GameObject scorePanel;
	private bool s=false;
	void Start(){
		animator = GetComponent<Animator> ();
		dynamiteAnimator = dynamite.GetComponent<Animator> ();
		particlePrefab = GameObject.FindWithTag ("prefab");
		particlePrefab.SetActive (false);
		playBack ();

	}



	void Update(){

		if (s) {
			
			int interval = Screen.height / 3;
			Rbtn.transform.position = Vector3.MoveTowards (Rbtn.transform.position, new Vector2(Screen.width/2,Screen.height/2), speed * Time.deltaTime);
			panel.transform.position = Vector3.MoveTowards (panel.transform.position,new Vector2(Screen.width/2,Screen.height/2+interval), speed * Time.deltaTime);
			scorePanel.SetActive (false);
		}

		if (playButton.Instance.sim) {
			particlePrefab.SetActive (true);

		}
		

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "boundary") {
			animator.SetTrigger ("break");
			playBreakSound ();
			Rbtn.SetActive (true);
			score.SetText ("SCORE " + count);

			s = true;
			GameControl.instance.gameOver = true;


		

		}

		if (coll.gameObject.tag == "enemyLeft") {


			
			animator.SetTrigger ("swipeLeft");
			GameControl.instance.gameOver = true;
			Rbtn.SetActive (true);
			playenemySound ();
			score.SetText ("SCORE " + count);
			s = true;

			Destroy (player, 2);

		}


		if (coll.gameObject.tag == "enemyRight") {



			animator.SetTrigger ("swipeRight");
			GameControl.instance.gameOver = true;
			Rbtn.SetActive (true);
			score.SetText ("SCORE " + count);
			playenemySound ();
			s = true;
			Destroy (player, 2);

		}

		if (coll.gameObject.tag == "dynamite") {

			Animator anim = coll.gameObject.GetComponent<Animator> ();
			anim.SetTrigger ("spark");
			animator.SetTrigger ("break");
			GameControl.instance.gameOver = true;
			Rbtn.SetActive (true);
			score.SetText ("SCORE " + count);
			s = true;
			PlayBlast ();
			Destroy (player, 3);



		}


	}


	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "star") {
			count++;
			starSound ();
			panelScore.SetText (" " + count);
			Destroy (other.gameObject);

		}
	}

	void playBack(){

		audioSource.clip = backGround;
		audioSource.Play ();
	}

	void PlayBlast(){
		audioSource.PlayOneShot (enemyBlast);
	}

	void starSound(){
		audioSource.PlayOneShot (starCollect);
	}

	void playenemySound(){
		audioSource.PlayOneShot (enemySound);

	}

	void playBreakSound(){
		audioSource.PlayOneShot (enemyBreak);
	}

	}

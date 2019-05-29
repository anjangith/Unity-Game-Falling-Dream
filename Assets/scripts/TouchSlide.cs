using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchSlide : MonoBehaviour {
	private Rigidbody2D rigidboy2d;
	private Vector2 firstPressPos;
	private Vector2 secondPressPos;
	private Vector3 currentSwipe;
	public float speed=2f;
	private Animator animator;
	public GameObject mainObject;
	public GameObject arrowPos;
	private GameObject instantiate;
	public float dragSpeed=1.0f;
	private GameObject spawnText;
	private Vector2 direction;

	// Use this for initialization
	void Start () {

		rigidboy2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}



	
	// Update is called once per frame
	void Update ()
	{
		if (GameControl.instance.gameOver == false) {

			if (Input.touchCount > 0) {
				Touch touch = Input.GetTouch (0); // get first touch since touch count is greater than zero

				if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
					// get the touch position from the screen touch to world point
					Vector3 touchedPos = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 10));
					// lerp and set the position of the current object to that of the touch, but smoothly over time.
					transform.position = Vector3.Lerp (transform.position, touchedPos, Time.deltaTime);
					secondPressPos = Input.GetTouch (0).position;
					Vector2 touch1 = Camera.main.WorldToScreenPoint (firstPressPos);
					Vector2 touch2 = Camera.main.WorldToScreenPoint (secondPressPos);
					direction = (new Vector2 (mainObject.transform.position.x, mainObject.transform.position.y) - touch2).normalized;
					//rigidboy2d.AddForce (direction * speed,ForceMode2D.Force);
					//Vector2 newPos=Vector2.MoveTowards(mainObject.transform.position,touch2,Time.deltaTime*speed);
					//	rigidboy2d.MovePosition(newPos);

					if (direction.x > transform.position.x) {
						animator.SetTrigger ("right");
					} else {
						animator.SetTrigger ("left");
					}
				}
				/*Vector2 pos = new Vector2 (mainObject.transform.position.x, mainObject.transform.position.y + 1);
					Quaternion rotation = Quaternion.LookRotation (direction,Vector3.up);
					instantiate =(GameObject) Instantiate (arrowPos,pos, Quaternion.FromToRotation(secondPressPos,direction));
					Destroy (instantiate, 0.1f);
					Debug.Log ("" + rigidboy2d.velocity.magnitude);
				}

				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
					

				}
			}*/



				/*if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
				firstPressPos = Input.GetTouch (0).position;
			}
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
				secondPressPos = Input.GetTouch (0).position;
				Vector2 touch1 = Camera.main.WorldToScreenPoint (firstPressPos);
				Vector2 touch2 = Camera.main.WorldToScreenPoint (secondPressPos);
				direction = (touch2 - touch1).normalized;
				rigidboy2d.AddForce (direction * speed,ForceMode2D.Force);
				//Vector2 newPos=Vector2.MoveTowards(mainObject.transform.position,touch2,Time.deltaTime*speed);
			//	rigidboy2d.MovePosition(newPos);

				if (direction.x > transform.position.x) {
					animator.SetTrigger ("right");
				} else {
					animator.SetTrigger ("left");
				}
				Vector2 pos = new Vector2 (mainObject.transform.position.x, mainObject.transform.position.y + 1);
				Quaternion rotation = Quaternion.LookRotation (direction,Vector3.up);
				instantiate =(GameObject) Instantiate (arrowPos,pos, Quaternion.FromToRotation(secondPressPos,direction));
				Destroy (instantiate, 0.1f);
				Debug.Log ("" + rigidboy2d.velocity.magnitude);

			}

			if (rigidboy2d.velocity.magnitude > 0.5f) {

				rigidboy2d.drag = dragSpeed;
			}*/




			}
		}

	}
}



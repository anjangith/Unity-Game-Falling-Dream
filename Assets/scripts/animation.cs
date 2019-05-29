using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour {
	public Transform[] positions;
	public GameObject enemy;
	private float timer;
	private int count=10;
	private GameObject instantiate;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", count,count);
		
	}

	void Awake(){
		timer = Time.time + count;
		

	}

	void Spawn(){

		instantiate=(GameObject)Instantiate (enemy, positions [0].position, transform.rotation);
		Destroy (instantiate,3);


	}

	void Update(){

		if (timer < Time.time) {

			count = 1;


			timer = Time.time + count;

		}

	}
	
	// Update is called once per frame
/*	void Update () {
		
		if (timer < Time.time) {
			
			instantiate = (GameObject)Instantiate (enemy, positions [0].position, transform.rotation);

			int size = positions.Length;


			adjustPos (enemy);
			StartCoroutine (Wait ());
		
			timer = Time.time + 5;
			

			 

		}

		
		
	}

	void adjustPos(GameObject obj){
		
		
		obj.transform.position = new Vector2 (positions [count].position.x,positions[count].position.y);
		count++;

	}

	IEnumerator Wait(){

		yield return new WaitForSeconds (3);
		instantiate.SetActive (false);
	}*/
		
}

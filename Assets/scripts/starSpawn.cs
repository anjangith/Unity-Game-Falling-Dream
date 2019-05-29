using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starSpawn : MonoBehaviour {

	public GameObject star;
	public int maxTime=8;
	public int minTime=3;
	private float time;
	public Transform[] positions;
	private float spawnTime;
	private GameObject instatiate;
	private int count = 0;
	private int randromPoint;

	// Use this for initialization
	void Start () {
		setRandomTime ();
		time = minTime;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameControl.instance.gameOver == false) {

			time += Time.deltaTime;
			if (time >= spawnTime) {

				spawnObject ();
				setRandomTime ();
			}
		}
		
	}

	void setRandomTime(){

		spawnTime=Random.Range (minTime, maxTime);
	}

	void spawnObject(){


		time = 0;
		randromPoint = Random.Range (0, 8);
		instatiate = (GameObject)Instantiate (star, positions[randromPoint].position, positions[randromPoint].rotation);
		checkLimit ();
		Destroy (instatiate, 3);


	}

	void checkLimit(){
		int limit = positions.Length;
		if (count == limit-1) {
			count = 0;
		} else {
			count++;
		}


	}
}

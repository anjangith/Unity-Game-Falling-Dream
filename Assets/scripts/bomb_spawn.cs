using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_spawn: MonoBehaviour {

	public GameObject bomb;
	public int maxTime=8;
	public int minTime=3;
	private float time;
	public Transform[] positions;
	private float spawnTime;
	private GameObject instatiate;
	private int count = 0;
	private int randromPoint;
	public GameObject star;

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
		StartCoroutine (alert(randromPoint));  



	}

	void checkLimit(){
		int limit = positions.Length;
		if (count == limit-1) {
			count = 0;
		} else {
			count++;
		}


	}

	IEnumerator alert(int random){

		instatiate = (GameObject)Instantiate (star, positions [random].position, positions [random].rotation);
		Destroy (instatiate, 2);
		yield return new WaitForSeconds (2);
		yield return StartCoroutine (bombSpawn(random));

	}

	IEnumerator bombSpawn(int random){

		instatiate = (GameObject)Instantiate (bomb, positions[random].position, positions[random].rotation);
		checkLimit ();
		Destroy (instatiate, 3);
		yield return null;
	}
}

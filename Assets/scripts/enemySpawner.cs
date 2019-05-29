using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {
	public GameObject enemyLeft;
	public GameObject enemyRight;
	public int maxTime=8;
	public int minTime=3;
	private float time;
	public Transform[] positionLeft;
	public Transform[] positionRight;
	private float spawnTime;
	private GameObject instatiate;
	private int count = 0;
	private int alternateKey=0;
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
		randromPoint = Random.Range (0, 6);
		if (alternateKey == 0) {
			instatiate = (GameObject)Instantiate (enemyRight,positionRight[randromPoint].position, positionRight [randromPoint].rotation);
			print ("this is right enemy");
			alternateKey = 1;
		} else if(alternateKey==1){
			instatiate = (GameObject)Instantiate (enemyLeft, positionLeft [randromPoint].position, positionLeft [randromPoint].rotation);
			print ("this is left enemy");
			alternateKey = 0;

		}
		checkLimit ();
		Destroy (instatiate, 3);


	}

	void checkLimit(){
		int limit = positionLeft.Length + positionRight.Length;
		if (count == limit-1) {
			count = 0;
		} else {
			count++;
		}


	}
}

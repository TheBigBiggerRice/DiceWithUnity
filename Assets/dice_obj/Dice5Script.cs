using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice5Script: MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 diceVelocity;


	//use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	//update is called once per frame
	void Update() {
		diceVelocity = rb.velocity;
		if (Input.touchCount > 0) {
			Touch myTouch = Input.touches[0];
			if (myTouch.phase == TouchPhase.Began) {
				DiceNumberTextScript.diceNumber = 0;
				float dirX = Random.Range (0, 500);
				float dirY = Random.Range (0, 500);
				float dirZ = Random.Range (0, 500);
				transform.position = new Vector3 (0, 2, -1);
				transform.rotation = Quaternion.identity;
				rb.AddForce (transform.up * 500);
				rb.AddTorque (dirX, dirY, dirZ);
			}
		}
		Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
		pos.x = Mathf.Clamp(pos.x, (float)0.1, (float)0.9);
		pos.y = Mathf.Clamp(pos.y, (float)0.1, (float)0.9);
		Vector3 speed = rb.velocity;
		if(pos.x == 0 || pos.x == 1)
			speed.x = 0;
		if(pos.y == 0 || pos.y == 1)
			speed.y = 0;
		transform.position = Camera.main.ViewportToWorldPoint(pos);
		rb.velocity = speed;
	}
}
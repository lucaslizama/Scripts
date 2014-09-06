using UnityEngine;
using System.Collections;

public class Medusa_Moves : MonoBehaviour {

	public float speed;
	public float idx;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (idx == 1) {
			moveLeft(speed);
		}
		else if(idx == 2) {
			moveRight(speed);
		}
	}

	void moveLeft (float speed) {

		transform.Translate (new Vector3 (-speed, 0f, 0f));
	}

	void moveRight (float speed) {
		
		transform.Translate (new Vector3 (speed, 0f, 0f));
	}
}

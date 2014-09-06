using UnityEngine;
using System.Collections;

public class debrisMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector3(-10, 0, 0);
    }
}

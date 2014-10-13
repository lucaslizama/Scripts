using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour
{
	public bool sleep;
	public float velocidadH;
	public float velocidadV;

	private float verticalSpeed;
	private float horizontalSpeed;
	
	void Awake () 
	{
	}

	// Use this for initialization
	void Start ()
	{
		horizontalSpeed = 0f;
		verticalSpeed = 0f;
		sleep = false;
	}

	// Update is called once per frame
	void Update ()
	{
		//Controles verticales
		if(Input.GetButton("P1_up")){
			verticalSpeed = velocidadV;
		}else if(Input.GetButton("P1_down")){
			verticalSpeed = -velocidadV;
		}else{
			verticalSpeed = 0f;
		}
		//Controles horizontales
		if(Input.GetButton("P1_right")){
			horizontalSpeed = velocidadH;
		}else if(Input.GetButton("P1_left")){
			horizontalSpeed = -velocidadH;
		}else{
			horizontalSpeed = 0f;
		}
	}

	void FixedUpdate ()
	{
		rigidbody2D.velocity = new Vector2(horizontalSpeed,verticalSpeed);

		if (sleep == true) {
				gameObject.rigidbody2D.Sleep ();
		}

		Physics2D.IgnoreLayerCollision (9, 10, true);
		Physics2D.IgnoreLayerCollision (9, 11, true);
		Physics2D.IgnoreLayerCollision (10, 11, false);
		Physics2D.IgnoreLayerCollision (10, 12, false);
		Physics2D.IgnoreLayerCollision (11, 11, true);
		Physics2D.IgnoreLayerCollision (11, 12, true);
	}
}

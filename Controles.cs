using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour
{
	private Vector3 detenerVelocidad;
	public float Vspeed;
	public float maxHSpeed;
	public float translateSpeed;
	public bool sleep;
	public float movementSpeed;
	public float fallingSpeed;



	void Awake () 
	{
	}

	// Use this for initialization
	void Start ()
	{
		detenerVelocidad = new Vector3 (rigidbody2D.velocity.x, 0, 0);
		sleep = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Exit") == true) {
				Application.LoadLevel ("Submarine_Intro");
		}

		if (Input.GetButton ("P1_jump") == true) {
			rigidbody2D.velocity = new Vector2(0f,movementSpeed);
			if(Input.GetButton("P1_right")){
				rigidbody2D.velocity = new Vector2(movementSpeed,movementSpeed);
			}else if(Input.GetButton("P1_left")){
				rigidbody2D.velocity = new Vector2(-movementSpeed,movementSpeed);
			}
		}

		if (Input.GetButton ("P1_right") == true && Input.GetButton ("P1_jump") == false) {
				rigidbody2D.velocity = new Vector2(movementSpeed,-fallingSpeed);
		}
		if (Input.GetButton ("P1_left") == true && Input.GetButton ("P1_jump") == false) {
				rigidbody2D.velocity = new Vector2(-movementSpeed,-fallingSpeed);
		}
		if (Input.GetButton ("P1_right") == false && Input.GetButton ("P1_left") == false && Input.GetButton("P1_jump") == false) {
				rigidbody2D.velocity = new Vector2(0f,-fallingSpeed);
		}
	}

	void FixedUpdate ()
	{

		if (sleep == true) {
				gameObject.rigidbody2D.Sleep ();
		}

		Physics2D.IgnoreLayerCollision (9, 10, true);
		Physics2D.IgnoreLayerCollision (9, 11, true);
		Physics2D.IgnoreLayerCollision (10, 11, false);
		Physics2D.IgnoreLayerCollision (10, 12, false);
		Physics2D.IgnoreLayerCollision (11, 11, true);
		Physics2D.IgnoreLayerCollision (11, 12, true);

		detenerVelocidad = new Vector3 (rigidbody2D.velocity.x, 0, 0);
	}
}

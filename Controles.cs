using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour 
{
	private Vector3 detenerVelocidad;

    public float Vspeed;
	public float maxHSpeed;
	public float translateSpeed;
	public bool sleep;
    
	// Use this for initialization
	void Start () 
    {
		detenerVelocidad = new Vector3(rigidbody2D.velocity.x,0,0);
		sleep = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonDown("Exit") == true)
        {
            Application.LoadLevel("Submarine_Intro");
        }

        if (gameObject.name == "Jugador")
        {
            if (Input.GetButtonDown("P1_jump") == true)
            {
                rigidbody2D.velocity = detenerVelocidad;
            }

            if (Input.GetButton("P1_jump") == true)
            {
                rigidbody2D.velocity = new Vector3(maxHSpeed, Vspeed, 0f);
            }

			if (Input.GetButton("P1_right") == true)
			{
				rigidbody2D.velocity = new Vector3(maxHSpeed,rigidbody2D.velocity.y,0);
			}
			if (Input.GetButton("P1_left") == true)
			{
				rigidbody2D.velocity = new Vector3(-maxHSpeed,rigidbody2D.velocity.y,0);
            }
			if(Input.GetButton("P1_right") == false && Input.GetButton("P1_left") == false)
			{
				rigidbody2D.velocity = new Vector3(0,rigidbody2D.velocity.y,0);
			}

            if (Input.GetAxis("P1_Horizontal") > 0f)
            {
                rigidbody2D.velocity = new Vector3(maxHSpeed, rigidbody2D.velocity.y, 0);
            }
            else if (Input.GetAxis("P1_Horizontal") < 0f)
            {
                rigidbody2D.velocity = new Vector3(-maxHSpeed, rigidbody2D.velocity.y, 0);
            }
            else if (Input.GetAxis("P1_Horizontal") == 0f && !Input.GetButton("P1_right") && !Input.GetButton("P1_left"))
            {
                rigidbody2D.velocity = new Vector3(0, rigidbody2D.velocity.y, 0);
            }
        }
	}

    void FixedUpdate()
    {
		if(sleep == true)
		{
			gameObject.rigidbody2D.Sleep();
		}

		Physics2D.IgnoreLayerCollision(9, 10,true);
		Physics2D.IgnoreLayerCollision(9, 11,true);
		Physics2D.IgnoreLayerCollision(10, 11,false);
        Physics2D.IgnoreLayerCollision(10, 12,false);
        Physics2D.IgnoreLayerCollision(11, 11, true);
        Physics2D.IgnoreLayerCollision(11, 12, true);

		detenerVelocidad = new Vector3(rigidbody2D.velocity.x,0,0);
    }
}

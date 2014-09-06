using UnityEngine;
using System.Collections;

public class Jugador : MonoBehaviour {

	public int vida;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		if(vida <= 0)
		{
			Application.LoadLevel(2);
		}
	}

	void OnTriggerEnter2D(Collider2D cosas)
	{
		if(cosas.gameObject.tag == "medusa")
		{
			Destroy(cosas.gameObject);
			vida = vida - 1;
		}
	}
}

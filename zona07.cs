using UnityEngine;
using System.Collections;

public class zona07 : MonoBehaviour {

	public Controles cont;
	public Transform jugador;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D zona7)
	{
		if(zona7.gameObject.name == "Jugador")
		{

		}
	}


	float calculateRotation(GameObject target)
	{
		float deltaX = target.transform.position.x - transform.position.x;
		float deltaY = target.transform.position.y - transform.position.y;
		float angulo = Mathf.Atan2 (deltaY, deltaX) * Mathf.Rad2Deg;
		return angulo;
	}
}

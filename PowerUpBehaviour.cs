using UnityEngine;
using System.Collections;

public class PowerUpBehaviour : MonoBehaviour {


	GameObject cannon;
    float timer;

	// Use this for initialization
	void Start () 
	{
        timer = 0f;
        rigidbody2D.AddForce(new Vector2(Random.Range(-100, 100), Random.Range(100, 300)));
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FixedUpdate()
	{
        timer += Time.deltaTime;
		cannon = GameObject.Find("Cannon");
        if (timer >= 3f)
        {
            Destroy(gameObject);
        }
	}
    

	void OnTriggerEnter2D(Collider2D jugador)
	{
		if(jugador.gameObject.name == "Jugador")
		{
			cannon.GetComponent<Cannon>().bulletEnergyUp(1);
			Destroy(gameObject);
		}
	}
	
}

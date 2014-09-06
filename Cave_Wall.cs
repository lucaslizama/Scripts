using UnityEngine;
using System.Collections;

public class Cave_Wall : MonoBehaviour {

	Grenade gr;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D objeto)
	{
		if(objeto.gameObject.tag == "Bomb")
		{
			if(objeto.gameObject.name == "Grenade(Clone)")
			{
				gr = objeto.gameObject.GetComponent<Grenade>();
				gr.explode = true;
			}
		}

		if(objeto.gameObject.tag == "bullet")
		{
			if(objeto.gameObject.name == "bullet(Clone)")
			{
				bullet bala = objeto.gameObject.GetComponent<bullet>();
				bala.hit = true;
			}
		}
	}
}

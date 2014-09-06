using UnityEngine;
using System.Collections;

public class chest : MonoBehaviour {

	private Animator anim;
	private int randomNumber;

	public GameObject[] loot;
	public Transform lootSpawn;
	public bool openChest;
	public int lootSize;


	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		openChest = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(openChest == true)
		{
			anim.SetBool("Open",true);
		}
	}

	void OnCollisionEnter2D(Collision2D bullet)
	{
		if(bullet.gameObject.tag == "bullet")
		{
			anim.SetBool("Open",true);
			bullet bb = bullet.gameObject.GetComponent<bullet>();
			bb.destroy = true;
		}

		if(bullet.gameObject.tag == "Bomb")
		{
			if(bullet.gameObject.name == "Grenade(Clone)")
			{
				Grenade gr = bullet.gameObject.GetComponent<Grenade>();
				gr.explode = true;
			}
		}
	}

	//Metodo que Instancia
	void lanzarGemas()
	{
		for(int i = 0; i < lootSize; i++)
		{
			randomNumber = Random.Range(0,7);
			Instantiate(loot[randomNumber],transform.position,transform.rotation);
        }
    }
}

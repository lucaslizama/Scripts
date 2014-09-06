using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {

	public bool explode;
	public bool destroy;
	public bool sleep;
	public float launchForce;
	public int damage;
	public AudioClip explosion;

		
	private Vector3 force;
	private float angle;
	private Animator anim;
	private AudioSource sonido;


	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		sonido = GetComponent<AudioSource> ();
		explode = false;
		destroy = false;
		sleep = false;

		angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
		rigidbody2D.AddForce(new Vector2(launchForce * Mathf.Cos(angle),launchForce * Mathf.Sin(angle)));
	}

	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(destroy == true)
		{
			destroyGrenade();
		}

		if(sleep == true)
		{
			rigidbody2D.Sleep();
		}
		else
		{
			rigidbody2D.WakeUp();
		}

		if(explode == true)
		{
			sleep = true;
			anim.SetTrigger("Explode");
		}

	}

	void OnTriggerStay2D(Collider2D objetos)
	{
		if(explode == true && objetos.name == "Debris")
		{
			DebrisDestroy deb;
			deb = objetos.GetComponent<DebrisDestroy>();
			deb.destroy = true;
		}

		if(explode == true && objetos.tag == "Chest")
		{
			chest cofre;
			cofre = objetos.GetComponent<chest>();
			cofre.openChest = true;
		}

		if(explode == true && objetos.tag == "medusa")
		{
			Medusa med;
			med = objetos.GetComponent<Medusa>();
			med.hp = med.hp - damage;
		}


	}

	void destroyGrenade()
	{
		Destroy (gameObject);
	}

	void playSound()
	{
		sonido.PlayOneShot(explosion);
	}
	
}

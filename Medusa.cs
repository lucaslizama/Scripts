using UnityEngine;
using System.Collections;

public class Medusa : MonoBehaviour
{
		public int hp;
		public float medusaSpeed;
		public int behaveIDX;
		public bool sleep;
		public GameObject[] bloodSpawns;
		private	Animator anim;
		private BoxCollider2D caja;
		private CircleCollider2D circulo;
		private int spawnNumber;


		// Use this for initialization
		void Start ()
		{
				sleep = false;
				anim = GetComponent<Animator> ();
				caja = GetComponentInChildren<BoxCollider2D> ();
				circulo = GetComponentInChildren<CircleCollider2D> ();
		}
	
		void FixedUpdate ()
		{
				if (sleep == true && behaveIDX == 0) {
						dormirObjeto ();
				}

				if (hp <= 0) {
						morir ();
				}

				if (behaveIDX == 1) {
						moveLeft (medusaSpeed);
				} else if (behaveIDX == 2) {
						moveRight (medusaSpeed);
				}
		}

		void OnCollisionEnter2D (Collision2D objeto)
		{
				if (objeto.gameObject.tag == "Bomb") {
						if (objeto.gameObject.name == "Grenade(Clone)") {
								print ("Impacto");
								Grenade gr = objeto.gameObject.GetComponent<Grenade> ();
								gr.explode = true;
						}
				}

				if (objeto.gameObject.tag == "bullet") {
						if (objeto.gameObject.name == "bullet(Clone)") {
								hp = hp - 1;
								bullet bala = objeto.gameObject.GetComponent<bullet> ();
								bala.hit = true;
								if (hp > 0) {
										spawnNumber = Random.Range (0, 4);
										bloodSpawns [spawnNumber].SetActive (true);
										spawnNumber = spawnNumber + 1;
								}
						}
				}


		}

		void moveLeft (float medusaSpeed)
		{
				transform.Translate (new Vector3 (-(this.medusaSpeed), 0f, 0f));
		}

		void moveRight (float medusaSpeed)
		{
				transform.Translate (new Vector3 (this.medusaSpeed, 0f, 0f));
		}

		public void morir ()
		{
				caja.enabled = false;
				circulo.enabled = false;
				anim.SetTrigger ("Death");
		}

		void destruir ()
		{
				Destroy (gameObject);
		}
			
		void dormirObjeto ()
		{
				rigidbody2D.Sleep ();
		}
}

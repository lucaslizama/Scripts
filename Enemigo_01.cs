using UnityEngine;
using System.Collections;

public class Enemigo_01 : MonoBehaviour
{

		public float translateSpeed;
		public float followDistance;
		int vida;
		float translateSpeedY;
		float playerX;
		float playerY;
		float enemyX;
		float enemyY;
		float enemyAngle;
		GameObject jugador;

		// Use this for initialization
		void Start ()
		{
				translateSpeedY = Random.Range (-20f, 20f) / 100f;
		}

		void FixedUpdate ()
		{
        
				jugador = GameObject.Find ("Jugador");

				playerX = jugador.transform.position.x;
				playerY = jugador.transform.position.y;
        
				enemyX = transform.position.x;
				enemyY = transform.position.y;

				enemyAngle = Mathf.Atan2 ((enemyY - playerY), (enemyX - playerX)) * Mathf.Rad2Deg;
		
				if (Vector2.Distance (jugador.transform.position, transform.position) <= followDistance) {
						transform.rotation = Quaternion.Euler (0f, 0f, enemyAngle);
						transform.Translate (translateSpeed, translateSpeedY, 0f);
				}

		}
}

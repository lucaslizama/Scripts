using UnityEngine;
using System.Collections;

public class Advancer : MonoBehaviour {

	public bool[] zonasDisponibles;
	public Transform[] posicionZonas;
	public float velocidadCamara;
	public GameObject camara;
	public GameObject pivote;

	
	private Vector3 cameraPos;
	private int i;
	private float cameraAngle;
	private float pivotAngle;
	private float zoneX;
	private float zoneY;
	private Vector3 cameraRot;
	private Vector3 pivotRot;

	// Use this for initialization
	void Start () {
		i = 0;
		cameraPos = Vector3.zero;
		cameraRot = Vector3.zero;
		pivotRot = Vector3.zero;
		zoneX = 0f;
		zoneY = 0f;
		pivotAngle = 0f;
		cameraAngle = 0f;
	}

	void FixedUpdate()
	{
		if(cameraPos.x >= posicionZonas[i].position.x && i < posicionZonas.Length - 1)
		{
			i = i + 1;
			zoneX = posicionZonas [i].position.x - pivote.transform.position.x;
			zoneY = posicionZonas [i].position.y - pivote.transform.position.y;
			pivotAngle = Mathf.Atan2 (zoneY, zoneX) * Mathf.Rad2Deg;
			pivotRot = new Vector3 (0f, 0f, pivotAngle);
			pivote.transform.rotation = Quaternion.Euler(pivotRot);
		}

		//Esto mantiene el angulo de la camara fijo.
		cameraAngle = Mathf.Clamp (cameraAngle, 0f, 0f);
		cameraRot = new Vector3 (0f, 0f, cameraAngle);
		camara.transform.rotation = Quaternion.Euler (cameraRot);

		//Esto fija la trayectoria de la camara.

	}

	void OnTriggerStay2D(Collider2D player)
	{
		if(player.name == "Jugador")
		{
			cameraPos = pivote.transform.position;

			if(zonasDisponibles[i] == true && cameraPos.x <= posicionZonas[i].position.x)
			{
				pivote.transform.Translate(velocidadCamara,0f,0f);
				cameraPos.x = Mathf.Clamp(cameraPos.x,cameraPos.x,posicionZonas[i].position.x);
			}
		}
	}
}

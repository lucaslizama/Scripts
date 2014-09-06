using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour
{

		IEnumerator changeLevel ()
		{
				yield return new WaitForSeconds (1);
				Application.LoadLevel ("Submarine_Intro");
		}

		// Use this for initialization
		void Start ()
		{
				StartCoroutine (changeLevel ());
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}

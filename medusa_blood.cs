using UnityEngine;
using System.Collections;

public class medusa_blood : MonoBehaviour
{
	

		private Transform parent;

		// Use this for initialization
		void Start ()
		{
			
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		void apagar(){
			gameObject.SetActive(false);
		}

		void destruirObjeto ()
		{
				Destroy (gameObject);
		}
}

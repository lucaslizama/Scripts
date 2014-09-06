using UnityEngine;
using System.Collections;

public class Particle_sort : MonoBehaviour
{

		public string layer;
		public int numeroLayer;

		void Start ()
		{
				particleSystem.renderer.sortingLayerName = layer;
				particleSystem.renderer.sortingOrder = numeroLayer;
		}

		void FixedUpdate ()
		{
		
		}
}

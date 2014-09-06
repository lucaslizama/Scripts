using UnityEngine;
using System.Collections;

public class animationResizer : MonoBehaviour {
	
	 private Animator anim;

	// Use this for initialization
	void Start () 
	{	
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if(Input.GetKeyDown(KeyCode.F))
		{
			anim.SetTrigger("Big");
		}

		if(Input.GetKeyDown(KeyCode.G))
		{
			anim.SetTrigger("Small");
        }
	}
}

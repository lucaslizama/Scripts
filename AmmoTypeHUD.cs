using UnityEngine;
using System.Collections;

public class AmmoTypeHUD : MonoBehaviour {

	public Texture[] ammoIcons;
	public int iconIndex;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		guiTexture.texture = ammoIcons [iconIndex];
	}
}

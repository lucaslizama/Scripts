using UnityEngine;
using System.Collections;

public class GUI_Intro : MonoBehaviour {


	public Texture Start;
	public Texture Star_Over;
	public Texture Exit;
	public Texture Exit_Over;

	void OnMouseUp()
	{
		if(guiTexture.name == "Start")
		{
            Application.LoadLevel("Submarine_Game_01");
		}

		if(guiTexture.name == "Exit")
		{
			Application.Quit();
		}
	}


	void OnMouseOver()
	{
		if(guiTexture.name == "Start")
		{
			guiTexture.texture = Star_Over;
		}

		if(guiTexture.name == "Exit")
		{
			guiTexture.texture = Exit_Over;
		}
	}


	void OnMouseExit()
	{
		if(guiTexture.name == "Start")
		{
			guiTexture.texture = Start;
		}

		if(guiTexture.name == "Exit")
		{
			guiTexture.texture = Exit;
		}
	}
}

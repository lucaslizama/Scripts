using UnityEngine;
using System.Collections;

public class GUI_Scene : MonoBehaviour {

    int power;
    int level;
    GameObject cannon;

	// Use this for initialization
	void Start () 
    {
        power = 0;
        level = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void FixedUpdate()
    {
        if (GameObject.Find("Cannon") != null)
        {
            cannon = GameObject.Find("Cannon");
            power = cannon.GetComponent<Cannon>().getEnergy();
            level = cannon.GetComponent<Cannon>().getAmmoIndex();
        }
        

        if (gameObject.guiText.name == "Energy")
        {
            gameObject.guiText.text = "Energy: " + power;
        }

        if (gameObject.guiText.name == "Level")
        {
			gameObject.guiText.text = "Weapon: " + level;
        }
    }
}

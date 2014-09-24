using UnityEngine;
using System.Collections;

public class Application_Actions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void cargaNivel(int level)
    {
        Application.LoadLevel(level);
    }

    public void cierraJuego()
    {
        Application.Quit();
    }
}

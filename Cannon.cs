using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

    Vector3 mousePos;
    Vector3 objectPos;
    float angle;
	GameObject cannonTip;
	
    public int ammoIndex;
	public int bulletEnergy;
    public GameObject[] ammo;
	public AmmoTypeHUD ammoIcon;
	public AudioSource shoot;
	public AudioClip [] bulletSounds;
    

	// Use this for initialization
	void Start () 
	{
		ammoIndex = 0;
		bulletEnergy = 0;
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           	Instantiate(ammo[ammoIndex], cannonTip.transform.position, transform.rotation);
			shoot.PlayOneShot(bulletSounds[0]);
        }

		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			ammoIndex = 0;
			ammoIcon.iconIndex = 0;
		}

		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			ammoIndex = 1;
			ammoIcon.iconIndex = 1;
		}

		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			ammoIndex = 2;
			ammoIcon.iconIndex = 2;
		}
    }
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//Este bloque controla la posicion del Mouse respecto del cañon
		cannonTip = GameObject.Find("Cannon_Tip");
        mousePos = Input.mousePosition;
        mousePos.z = 0.0f;
        objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        Vector3 rotationVector = new Vector3(0, 0, angle);
        transform.rotation = Quaternion.Euler(rotationVector);
	}

	public void bulletEnergyUp(int bulletEnergy)
	{
		this.bulletEnergy = this.bulletEnergy + bulletEnergy;
	}

    public int getEnergy()
    {
        return bulletEnergy;
    }

    public int getAmmoIndex()
    {
        return ammoIndex;
    }

}

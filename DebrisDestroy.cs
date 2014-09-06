using UnityEngine;
using System.Collections;

public class DebrisDestroy : MonoBehaviour {

	public GameObject [] powerUp;
	public bool destroy;
	public int lootSize;

    private float timer;
	private int randomNumber;


	// Use this for initialization
	void Start () 
    {
        //timer = 0f;
		destroy = false;
	}
		
  	void FixedUpdate()
    {
		if(destroy == true)
		{
			for(int i = 0; i < lootSize; i++)
			{
				randomNumber = Random.Range(0,7);
				Instantiate(powerUp[randomNumber],transform.position,transform.rotation);
			}
			Destroy(gameObject);
		}
    }

    void OnTriggerEnter2D(Collider2D cosa)
    {
        //Instancia 5 PowerUps y los lanza en direcciones random.
        if (cosa.gameObject.tag == "bullet")
        {
			for(int i = 0; i < lootSize; i++)
			{
				randomNumber = Random.Range(0,7);
				Instantiate(powerUp[randomNumber],transform.position,transform.rotation);
			}
            Destroy(gameObject);
            Destroy(cosa.gameObject); 
        }
    }
}

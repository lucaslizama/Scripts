using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	
	public bool sleep;
	public bool destroy;
	public bool hit;
	public float launchForce;
	
	private Vector3 force;
    private float timer;
	private float angle;
	private Animator anim;
	private BoxCollider2D box;

	// Use this for initialization
	void Start () 
    {
		angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
		rigidbody2D.AddForce(new Vector2(launchForce * Mathf.Cos(angle),launchForce * Mathf.Sin(angle)));
		sleep = false;
		hit = false;
		anim = GetComponent<Animator> ();
		box = GetComponent<BoxCollider2D> ();
        timer = 0f;
	}

    void FixedUpdate()
    {
		if(hit == true)
		{
			box.enabled = false;
			sleep = true;
			anim.SetTrigger("Hit");
		}

		if(destroy == true)
		{
			destroyObject();
		}

		if(sleep == true)
		{
			rigidbody2D.Sleep();
		}else
		{
			rigidbody2D.WakeUp();
		}

        timer += Time.deltaTime;

        if (timer >= 5)
        {
			destroyObject();
        }
    }


	void destroyObject()
	{
		Destroy (gameObject);
	}


}

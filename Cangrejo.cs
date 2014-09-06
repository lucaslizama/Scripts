using UnityEngine;
using System.Collections;

public class Cangrejo : MonoBehaviour
{

    public float velocidad;
    public int vida;
    public int behaveNumber;
    public GameObject spike;
    public Transform spikeSpwan;

    private Animator anim;
    private Transform espinaSpawn;
    private float spikeRotationAngle;
    private int contador;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        contador = 0;
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rigidbody2D.velocity = new Vector2(velocidad, rigidbody2D.velocity.y);

        //Enviamos el valor de la velocidad al animador
        anim.SetFloat("speed", rigidbody2D.velocity.x);

        //Si la velocidad es negativa espejamos al cangrejo	
        if (velocidad < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (velocidad > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (velocidad == 0)
        {
            anim.SetTrigger("Stop");
        }

        //Destruimos al cangrejo si su vida llega a 0
        if (vida == 0)
        {
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D bala)
    {
        if (bala.tag == "bullet")
        {
            bullet disparo = bala.GetComponent<bullet>();
            disparo.hit = true;
            vida = vida - 1;
        }

    }


    public void moveRight()
    {
        velocidad = 2f;
    }

    public void moveLeft()
    {
        velocidad = -2f;
    }

    //Metodo que calcula el angulo entre cangrejo y jugador.
    public float calculaAngulo(GameObject obj)
    {

        GameObject jugador = GameObject.Find("Jugador");
        GameObject objeto = obj;
        float deltax = jugador.transform.position.x - objeto.transform.position.x;
        float deltay = jugador.transform.position.y - objeto.transform.position.y;

        return (Mathf.Atan2(deltay, deltax) * Mathf.Rad2Deg);
    }



}
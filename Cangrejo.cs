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
    private Color spriteColor;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        contador = 0;
        spriteColor = GetComponent<SpriteRenderer>().color;
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

        //Comportamientos segun behaveNumber.

        if (behaveNumber == 1)
        {
            StartCoroutine("flash");
            behaveNumber = 0;
        }


        //Destruimos al cangrejo si su vida llega a 0
        if (vida == 0)
        {
            Destroy(gameObject);
        }
        
    }

    //Metodo que es llamado una sola vez cuando un colider entra en la 
    //zona trigger del cangrejo.
    void OnTriggerEnter2D(Collider2D bala)
    {
        if (bala.tag == "bullet")
        {
            bullet disparo = bala.GetComponent<bullet>();
            disparo.hit = true;
            vida = vida - 1;
            behaveNumber = 1;
        }

    }

    void OnBecameVisible()
    {
        behaveNumber = 2;
    }

    public void moveRight()
    {
        velocidad = 2f;
    }

    public void moveLeft()
    {
        velocidad = -2f;
    }

    public IEnumerator flash()
    {
        spriteColor.a = 0.78f;
        spriteColor.b = 0f;
        spriteColor.g = 0f;
        GetComponent<SpriteRenderer>().color = spriteColor;
        yield return new WaitForSeconds(0.1f);
        spriteColor.a = 1f;
        spriteColor.b = 1f;
        spriteColor.g = 1f;
        GetComponent<SpriteRenderer>().color = spriteColor;
        StopCoroutine("flash");
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
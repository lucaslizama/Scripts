using UnityEngine;
using System.Collections;

public class Cangrejo : MonoBehaviour
{

    public float velocidad;
    public float delayDisparo;
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

    // Update is called once per frame
    void FixedUpdate()
    {
        //Declaramos que la velocidad en x del cangrejo sera siempre la varible velocidad
        rigidbody2D.velocity = new Vector2(velocidad, rigidbody2D.velocity.y);

        //Enviamos el valor de la velocidad al animador
        anim.SetFloat("speed", velocidad);

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

        spikeRotationAngle = calculaAngulo();

        if (behaveNumber == 1)
        {
            StartCoroutine("shooting",delayDisparo);
            
            print(contador);
            if (contador == 9)
            {
                behaveNumber = 0;
                contador = 0;
            }
            
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

    //Metodo que dispara a intervalos un objeto spike.
    IEnumerator shooting(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(spike, spikeSpwan.position, Quaternion.Euler(0f, 0f, spikeRotationAngle));
        contador++;
        StopCoroutine("shooting");
    }

    //Metodo que calcula el angulo entre cangrejo y jugador.
    public float calculaAngulo()
    {

        GameObject jugador = GameObject.Find("Jugador");
        GameObject cangrejo = gameObject;
        float deltax = jugador.transform.position.x - cangrejo.transform.position.x;
        float deltay = jugador.transform.position.y - cangrejo.transform.position.y;

        return (Mathf.Atan2(deltay, deltax) * Mathf.Rad2Deg);
    }



}
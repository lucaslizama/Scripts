using UnityEngine;
using System.Collections;

public class Medusa : MonoBehaviour
{
    public int hp;
    public bool recieveDamage;
    public bool swim;
    public float intensidadNado;
    public GameObject[] bloodSpawns;
	public GameObject jugador;

    private Animator anim;
    private BoxCollider2D caja;
    private CircleCollider2D circulo;
    private Color medusaColor;
    private int spawnNumber;
	private float deltaX;
	private float deltaY;
	private float angulo;
    private float timer;
	private Vector3 rotacion;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        caja = GetComponentInChildren<BoxCollider2D>();
        circulo = GetComponentInChildren<CircleCollider2D>();
        medusaColor = GetComponent<SpriteRenderer>().color;
		jugador = GameObject.Find("Jugador");
		deltaX = 0f;
		deltaY = 0f;
        angulo = calculaAngulo();
		rotacion = Vector3.zero;
    }

    void FixedUpdate()
    {
        angulo = calculaAngulo();
        rotarMedusa();


        if (hp <= 0)
        {
            morir();
        }

        if (swim == true)
        {
            avanzar();
        }

        if (recieveDamage == true)
        {
            StartCoroutine("flash");
            recieveDamage = false;
        }

        

    }

    void OnCollisionEnter2D(Collision2D objeto)
    {
        if (objeto.gameObject.tag == "Bomb")
        {
            if (objeto.gameObject.name == "Grenade(Clone)")
            {
                print("Impacto");
                Grenade gr = objeto.gameObject.GetComponent<Grenade>();
                gr.explode = true;
            }
        }

        if (objeto.gameObject.tag == "bullet")
        {
            if (objeto.gameObject.name == "bullet(Clone)")
            {
                recieveDamage = true;
                hp = hp - 1;
                bullet bala = objeto.gameObject.GetComponent<bullet>();
                bala.hit = true;
                if (hp > 0)
                {
                    spawnNumber = Random.Range(0, 4);
                    bloodSpawns[spawnNumber].SetActive(true);
                    spawnNumber = spawnNumber + 1;
                }
            }
        }
    }

    private void swimTrue()
    {
        swim = true;
    }

    private void swimFalse()
    {
        swim = false;
    }

    private void avanzar()
    {
        
        deltaX = jugador.transform.position.x - transform.position.x;
        deltaY = jugador.transform.position.y - transform.position.y;

        rigidbody2D.velocity = new Vector2(Mathf.Cos(angulo - 90f) * intensidadNado,Mathf.Sin(angulo - 90f) * intensidadNado);
    }

    private void rotarMedusa()
    {
        rotacion = new Vector3(0f, 0f, (angulo - 90f));
        transform.rotation = Quaternion.Euler(rotacion);
    }

    private float calculaAngulo()
    {
        deltaX = jugador.transform.position.x - transform.position.x;
        deltaY = jugador.transform.position.y - transform.position.y;

        angulo = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg;

        return angulo;
    }

    public IEnumerator flash()
    {
        //medusaColor.a = 0.78f;
        medusaColor.b = 0f;
        medusaColor.g = 0f;
        GetComponent<SpriteRenderer>().color = medusaColor;
        yield return new WaitForSeconds(0.1f);
        //medusaColor.a = 1f;
        medusaColor.b = 1f;
        medusaColor.g = 1f;
        GetComponent<SpriteRenderer>().color = medusaColor;
        StopCoroutine("flash");
    }

    public void morir()
    {
        caja.enabled = false;
        circulo.enabled = false;
        anim.SetTrigger("Death");
    }


    void destruir()
    {
        Destroy(gameObject);
    }

    void dormirObjeto()
    {
        rigidbody2D.Sleep();
    }
}

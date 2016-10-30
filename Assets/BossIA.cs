using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class BossIA : MonoBehaviour
{

    //Variable de activacion de Boss IA.
    //Se activa cuando el trigger circular de bossfight da la señal a la variable.
    public static bool alerta = false;
    //Atributos de Boss
    public Rigidbody2D balaPrefab;
    public float attackSpeed = 25;
    public float cooldown;
    public float bulletSpeed = 500;
    public float saltoCD;
	public float tiempoInicio = Time.time;
	public int vidas;
	public string terminoNivel;

    public float ypos = 1f;   //   usado para lograr que salga del lugar de ignicion
    public float xpos = 0.2f; //   usado para lograr que salga del lugar de ignicion

    //Objetivo - Probablemente el Player.
    private Transform target;
    public ControlPlayer gameManager;

    //Sonido del disparo.
    public AudioSource disparo;

    //Atributos de movimiento de la bala.
    public float moveSpeed = 5;
    public float jumpSpeed = 200;
    public Rigidbody2D rb;

    //establezco el daño que recibira
    int damageValue = 1;

    //Variables para la funcionalidad del Patrulleo
    protected double distanciaMaxima = 0;
    protected double distanciaMinima = 0;
    bool DistanciaAgarrada = false;

    // Variable booleana que controla la dirección del patrullaje como una bandera.
    bool moveRight = true;

    void Awake()
    {
        gameManager = GameObject.Find("Player").GetComponent<ControlPlayer>();
        alerta = false;
		vidas = 5;
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Player").GetComponent<ControlPlayer>();
        GameObject tmp = GameObject.FindGameObjectWithTag("Player");
        if (tmp != null)
        {
            this.target = tmp.transform;
        }

    }

    //Este trigger para entrar es para conseguir el collider de la plataforma "Soil".
    void OnTriggerEnter2D(Collider2D col)
    {

        //Asigno a DistanciaMaxima el punto más largo de la plataforma y 
        //a DistanciaMinima el principio de la plataforma
        if (col.gameObject.tag == "SoilBoss")
        {
            ExtraerDistanciaPlataforma(col);
        }

		if (col.gameObject.tag == "Bullet1" || col.gameObject.tag == "Bullet2") {
			vidas--;

			if (vidas == 0)
				SceneManager.LoadScene (terminoNivel);
		}
			
    }

    // Update is called once per frame
    void Update()
    {
        if (alerta)
        {
            if (Time.time >= cooldown)
            {
                if (saltoCD%3 == 0)
                {
                    Fire();
                }
            }
			saltoCD += (Time.time - tiempoInicio);
            if (saltoCD%5 == 0)
            {
				this.GetComponent<Rigidbody2D> ().AddForce (Vector2.up);
            }
        }
        Patrulleo();
    }



    //Funcion que permite traer la distancia de la plataforma en la cual patrullará.
    public void ExtraerDistanciaPlataforma(Collider2D col)
    {
        if (!DistanciaAgarrada)
        {
            var size = col.GetComponent<Collider2D>();
            distanciaMaxima = col.gameObject.transform.position.x + (size.bounds.size.x / 2);
            distanciaMinima = col.gameObject.transform.position.x - (size.bounds.size.x / 2);
            DistanciaAgarrada = true;
        }
    }

    //Función de patrulleo para que vaya de lado a lado en las plataformas aparentemente.
    public void Patrulleo()
    {

        if (moveRight)
        {
            //Movimiento hacia la izquierda siempre y cuando esté en el rango
            if (this.transform.position.x > this.distanciaMinima)
            {
                this.GetComponent<Rigidbody2D>().position -= Vector2.right * moveSpeed * Time.deltaTime;
                this.transform.eulerAngles = new Vector2(0, 180);
            }
            else
            {
                moveRight = false;
            }
        }
        else
        {
            //Movimiento hacia la derecha siempre y cuando esté en el rango
            if (this.transform.position.x < this.distanciaMaxima - 1)
            {
                this.GetComponent<Rigidbody2D>().position += Vector2.right * moveSpeed * Time.deltaTime;
                this.transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                moveRight = true;
            }
        }
    }

    //Función que hace que dispares un cono directo hacia el jugador. 
    private void Fire()
    {
        Vector2 dir;
        disparo.Play();
        dir = target.transform.position - transform.position;
        dir = dir.normalized;

        Rigidbody2D bPrefab = Instantiate(balaPrefab,
        new Vector3(transform.position.x + xpos,
                    transform.position.y + ypos,
                    transform.position.z),
                    Quaternion.identity) as Rigidbody2D;

        bPrefab.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed);
        cooldown = Time.time + attackSpeed * 2;
    }



    void FixedUpdate()
    {
    }
}

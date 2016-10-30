using UnityEngine;
using System.Collections;
//Actualmente heredando de ControlEnemy Para poder lograr que persiga
public class FollowEnemy : ControlEnemy
{
    public float walkSpeed;
    public float maxFallSpeed;
    public float jumpImpulse;

    private Transform target;
    private Rigidbody2D body;
    private Vector2 movement;

    private float horInput;

    public bool persiguiendo = false;
    public bool isGrounded = false;
    public Transform compSuelo;
    float comprobadorRadio = 0.03f;
    public LayerMask mascaraSuelo;

    private float time;

    void Start()
    {

        this.body = this.GetComponent<Rigidbody2D>();
        this.movement = new Vector2();

        this.time = 0;

        gameManager = GameObject.Find("Player").GetComponent<ControlPlayer>();
        GameObject tmp = GameObject.FindGameObjectWithTag("Player");
        if (tmp != null)
        {
            this.target = tmp.transform;
        }
    }

    //Update donde busca hacia donde perseguir cuando sea la hora
    //y patrulleo en su dado caso.
    void Update()
    {
        this.time += Time.deltaTime;

        // search for the player
        if (this.target)
        {
            if (this.transform.position.x < this.target.position.x)
            {
                this.horInput = 1;
            }
            else if (this.transform.position.x > this.target.position.x)
            {
                this.horInput = -1;
            }
        }
        else
        {
            this.horInput = 0;
        }

        //Aquí en el update es donde cortamos de la raiz la transicion
        // de la herencia si no está en los limites caminables
        //y aquí también se puede lograr que si no está persiguiendo ni
        //patrulle por estar cerca, haga una animacion, se quede quieto, etc.
        // se puede lograr mucho en este preciso lugar.

        //Básicamente: si está persiguiendo y no está dentro 
        //de los limites, que patrulle.
        if (!persiguiendo || (this.transform.position.x < this.distanciaMinima || this.transform.position.x > this.distanciaMaxima))
        {
            base.Patrulleo();
        }


    }

    // =============================

    void FixedUpdate()
    {
    }
    //perseguimiento método.
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            persiguiendo = true;
            isGrounded = Physics2D.OverlapCircle(compSuelo.position, comprobadorRadio, mascaraSuelo);
            this.movement = this.body.velocity;

            if (col.gameObject.tag == "Player")
            {
                // Movimiento horizontal limitado al grounded.
                if (this.isGrounded)
                {
                    this.movement.x = horInput * walkSpeed;
                }

            }

            // Limitacion de la velocidad de caida
            if (!this.isGrounded)
            {
                if (this.movement.y < this.maxFallSpeed)
                    this.movement.y = this.maxFallSpeed;
            }
            this.body.velocity = this.movement;

        }
    }
    //al salir de perseguir que vuelva a patrullar.
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            persiguiendo = false;
    }
    // =============================
    void Detect()
    {
        if (this.isGrounded)
        {
            this.movement.y = jumpImpulse;

        }
    }
    //para almacenar las distancias para patrullar, metodo heredado.
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Soil")
        {
            base.ExtraerDistanciaPlataforma(col);
        }
    }
    // =============================


}

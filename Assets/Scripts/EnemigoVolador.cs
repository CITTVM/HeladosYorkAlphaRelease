using UnityEngine;
using System.Collections;
using System;

public class EnemigoVolador : Character
{

    private IVoladorState currentState;

    public GameObject Target { get; set; }

    //referencia a ControlPlayer
    public ControlPlayer gameManager;

    //establezco el daño que recibira
    int damageValue = 1;

    //Variable Booleana para controlar cada tanto tiempo que al estar colisionando con el obstaculo dañará al player
    bool Dañando = true;

    // Use this for initialization
    public int a;
    public int b;
    private int alpha; //
    private float centroX;
    private float centroY;

    public override void Start()
    {
        base.Start();
        ChangeState(new IdleState());
    }

    void Update()
    {
        currentState.Execute();
    }

    public void ChangeState(IVoladorState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter(this);

    }


    public void Awake()
    {
        gameManager = GameObject.Find("Player").GetComponent<ControlPlayer>();

        centroX = this.transform.position.x; //CentroX es la posición actual del ovni-pajaro en el EJE X
        centroY = this.transform.position.y; //CentroY es la posición actual del ovni-pajaro en el EJE Y

    }

    public void Ataque()
    {

        alpha += 10;

        float coordenadaX = centroX + (a * Mathf.Sin(alpha * .005f)); //Ecuación mat movimiento circular y ovalado en el eje X
        float coordenadaY = centroY + (b * Mathf.Cos(alpha * .005f)); //Ecuación mat movimiento circular y ovalado en el eje Y

        this.gameObject.transform.position = new Vector3(coordenadaX, coordenadaY, -2); //MOVIMIENTO CIRCUlAR A TRAVES DE LOS EJES X e Y

        if (alpha > 1220) //una vuelta completa hasta el inicio de la prox vuelta.
        {

            alpha = 0;
        }

        if (this.Target != null)
        {
            Dañando = false;
            Debug.Log("Mirá como te mato");
            gameManager.SendMessage("PlayerDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
            gameManager.SendMessage("TakenDamage", SendMessageOptions.DontRequireReceiver);
            StartCoroutine("TakeDamage");

        }


    }

    public override IEnumerator TakeDamage()
    {
       yield return new WaitForSeconds(1.5f);
       Dañando = true;
    }
}

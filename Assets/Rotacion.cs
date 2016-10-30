using UnityEngine;
using System.Collections;

public class Rotacion : MonoBehaviour {
    //referencia a GameManager
    public ControlPlayer gameManager;


    //establezco el daño que recibira
    int damageValue = 1;
    //Variable Booleana para controlar cada tanto tiempo que al estar colisionando con el obstaculo dañará al player
    bool Dañando = true;

    [SerializeField]
    private int velocidadBarraGiratoria = -20;

    //referencia a GameManager


    void Awake()
    {
        gameManager = GameObject.Find("Player").GetComponent<ControlPlayer>();
    }
    void Start() {

    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player" && Dañando)
        {
            Dañando = false;
            gameManager.SendMessage("PlayerDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
            gameManager.SendMessage("TakenDamage", SendMessageOptions.DontRequireReceiver);
            //Activo la rutina para desactivar el boolean
            StartCoroutine("Reactivar_Daño");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
            //Activo la rutina para desactivar el boolean
            StartCoroutine("Reactivar_Daño");
        
    }


    //el Yield return devolverá el tiempo que es necesario para volver a activar la booleana.
    IEnumerator Reactivar_Daño()
    {
        yield return new WaitForSeconds(1);
        Dañando = true;
    }

    //Rotacion.
     void Update () 
    {
        RotacionObstaculo();
	}



     void RotacionObstaculo()
    {
        transform.Rotate(Vector3.forward * velocidadBarraGiratoria);
    }
}

using UnityEngine;
using System.Collections;

public class pajaroIA : MonoBehaviour
{

    // Use this for initialization

    public int a;
    public int b;
    public float centroX;
    public float centroY;
    public int alpha; //
    public float coordenadaX; //Cordenadas en EJE X
    public float coordenadaY; //Coordenadas en EJE Y
    public bool ataque = false;


    /* void OnTriggerEnter2D(Collider2D col)
     {

         if (col.gameObject.tag == "Player")
         {
             Debug.Log("Esta dentro del collider por primera vez");
             ataque = true; //Se valida el ataque si el personaje entra en el espacio o collider del ovni.
         }
     }
     */
    void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Sigues dentro del collider");
            ataque = true; //Se valida el ataque si el personaje entra en el espacio o collider del ovni.
        }
    }


    void Start()
    {
        ataque = true; //El pajaro-ovni da una vuelta completa al iniciar para que quede en la posición inicial de cada vuelta.
        
    }

    void Awake()
    {
        centroX = this.transform.position.x; //CentroX es la posición actual del ovni-pajaro en el EJE X
        centroY = this.transform.position.y; //CentroY es la posición actual del ovni-pajaro en el EJE Y
        
    }
    void Update()
    {
        if (true)
        {

        }

        if (ataque)
        {
           

                alpha += 10;

                coordenadaX = centroX + (a * Mathf.Sin(alpha * .005f)); //Ecuación mat movimiento circular y ovalado en el eje X
                coordenadaY = centroY + (b * Mathf.Cos(alpha * .005f)); //Ecuación mat movimiento circular y ovalado en el eje Y

            this.gameObject.transform.position = new Vector2(coordenadaX, coordenadaY); //MOVIMIENTO CIRCUlAR A TRAVES DE LOS EJES X e Y

            if (alpha > 1220) //una vuelta completa hasta el inicio de la prox vuelta.
            {
                ataque = false;
                alpha = 0;
            }

        }

     }
       
 }




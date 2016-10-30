using UnityEngine;
using System.Collections;

public class Contacto : MonoBehaviour
{
    [SerializeField]
    private EnemigoVolador volador;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            volador.Target = other.gameObject;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            volador.Target = null;
        }
    }
}
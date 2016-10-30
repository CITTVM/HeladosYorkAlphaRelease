using UnityEngine;
using System.Collections;

public class TriggerBossFight : MonoBehaviour
{ 
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            BossIA.alerta = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            BossIA.alerta = false;
    }
}
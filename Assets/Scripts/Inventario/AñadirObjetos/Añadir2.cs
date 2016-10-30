using UnityEngine;
using System.Collections;

public class Añadir2 : MonoBehaviour {

	public JugadorInventario jugadorInventario;


	public GameObject bullet2;

	//id de los helados en la bd
	public int ID;

	void Start(){

		//weapon03.SetActive(false);

		//bullet1.gameObject.SetActive(true);


	}


	// cuando colisione el personaje con 1 helado este se agrega al inventario y se activa el arma
	//
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			jugadorInventario.AgregarObjeto (ID);
			print ("se agrego el objeto al inventario");
			Destroy (gameObject);




		}



	}
}

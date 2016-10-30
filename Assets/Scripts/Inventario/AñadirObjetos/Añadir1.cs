using UnityEngine;
using System.Collections;

public class Añadir1 : MonoBehaviour {


	//referencia al script jugadorinventario
	public JugadorInventario jugadorInventario;


	public GameObject bullet1;




	//id de los helados en la bd
	public int ID;


	void Start(){

		//weapon03.SetActive(false);



		//bullet2.gameObject.SetActive(false);

	}


	// cuando colisione el personaje con 1 helado este se agrega al inventario y se activa el arma
//
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			jugadorInventario.AgregarObjeto(ID);
			print ("se agrego el objeto al inventario");
			Destroy(gameObject);





			}



		}


//	void OnTriggerEnter2D(Collider2D col){
//
//		if(col.gameObject.tag == "Player"){
//			jugadorInventario.AgregarObjeto (ID);
//			Destroy (gameObject);
//			bullet1.SetActive(true);
//			bullet2.SetActive(true);
//
//
//			}



		}



	







	

	



	

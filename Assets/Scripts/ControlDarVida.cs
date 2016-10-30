using UnityEngine;
using System.Collections;

public class ControlDarVida : MonoBehaviour {

	//referencia a GameManager
	public GameManager gameManager;




	//VIDA QUE GANARA
	int VidaGanada=1;

	// cuando el player colisione con el helado, se llama al metodo playervida
	void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.tag == "Player"){
			
			gameManager.SendMessage("PlayerVida", VidaGanada, SendMessageOptions.DontRequireReceiver);


		}
	}




}

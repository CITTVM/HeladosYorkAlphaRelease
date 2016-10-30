using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	//referencia al script del jugador
	public ControlPlayer controlPlayer;


	//controlar la textura del player
	public Texture playerHealthTexture;

	//variables 
	public float screenPositionX;
	public float screenPositionY;

	public float iconSizeX = 25;
	public float iconSizeY = 25;

	//iniciara con 3 health
	public int playerHealth = 5;





	//para quitar health o agregar health
	void OnGUI(){
		for(int h = 0; h > playerHealth; h++) {
			GUI.DrawTexture(new Rect(screenPositionX + (h * iconSizeX), screenPositionY, iconSizeX, iconSizeY), playerHealthTexture, ScaleMode.ScaleToFit, true, 0);
		}

	}
	//METODO PARA QUITAR VIDAS 
	void PlayerDamaged(int vida)
	{

		if (playerHealth > 0) {

			playerHealth -= vida;
		}

		if(playerHealth <= 0){
			playerHealth = 0;
			RestartScene();

		}

	}


	//reinicia la escena
	void RestartScene(){

		SceneManager.LoadScene("Test");

	}




	//METODO QUE AUMENTA VIDA (como maximo 5)

	void PlayerVida(int vida){

		if (playerHealth < 5) {

			playerHealth += vida;
		}



	
	}
		
	}












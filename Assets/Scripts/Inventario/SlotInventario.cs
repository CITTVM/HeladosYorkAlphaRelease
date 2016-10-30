using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotInventario : MonoBehaviour {
//
	public int ID;
	public Image Child;
	public marcador Marcador;
    public JugadorInventario Inventario;
    public Text cantidad;
	public GameObject bullet1;
	public GameObject bullet2;
//


	void Start(){

		bullet1.SetActive(false);
		bullet2.SetActive(false);

	}

	public void click(){


	if (Inventario.Objetos[ID].Objeto != null)
		{

			if (Marcador.ID != ID)
		{
		    Marcador.transform.position = transform.position;
			Marcador.ID = ID;
			//Inventario.Usar(ID);

		} 

			else 
			{



			}
         }
	}

	public void marcadore(){
		
		if (Marcador.ID == 0) {
		
			//bullet1.SetActive (true);
			bullet1.SetActive(true);
			bullet2.SetActive(false);
		} else  
		
		{
			bullet1.SetActive(false);
			bullet2.SetActive(true);

		}

	}


//
//	if (weapon01.activeSelf){
//		weapon01.SetActive(false);
//		weapon02.SetActive(true);
//
//
//
//		//weapon03.SetActive(true);
//	}
//	else{
//		weapon01.SetActive(true);
//		weapon02.SetActive(false);
//		//weapon02.SetActive(true);
//
//	}




















	void Update(){
//
		Child.sprite = Inventario.Objetos[ID].sprite;
     	cantidad.text = Inventario.Cantidad[ID].ToString();
	}
//



//	public void ActivarArmaConMarcador(){
//
//		if (Marcador.ID = 0) {
//			bullet1.SetActive(true);
//			bullet2.SetActive(false);
//		} else if(Marcador.ID = 1) {
//
//			bullet1.SetActive(false);
//			bullet2.SetActive(true);
//		
//		
//		}

	}
















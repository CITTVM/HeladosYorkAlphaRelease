using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EquipoInventario : MonoBehaviour {


	public int ID;
	public Image Child;
    public JugadorInventario Inventario;

	void Update(){
		
		Child.sprite = Inventario.Equipo[ID].sprite;
	
	}











}

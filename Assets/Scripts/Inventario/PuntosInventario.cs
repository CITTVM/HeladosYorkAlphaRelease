using UnityEngine;
using System.Collections;

public class PuntosInventario : MonoBehaviour {

	public JugadorInventario JI;
	public int ID;
	//public GameObject go;





	public void Refrescar ()
	{
	


		//if (go != null) {


			GameObject go = Instantiate(JI.Equipo [ID].Objeto) as GameObject;
			go.transform.parent = transform;
			go.transform.localPosition = Vector3.zero;
		
		//}






	}
}

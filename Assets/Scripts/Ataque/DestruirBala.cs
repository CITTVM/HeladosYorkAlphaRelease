using UnityEngine;
using System.Collections;

public class DestruirBala : MonoBehaviour {



	void OnBecameInvisible ()
	{
		//Destruimos el objeto padre cuando salga fuera de la pantalla

		Destroy(gameObject);
	}
}

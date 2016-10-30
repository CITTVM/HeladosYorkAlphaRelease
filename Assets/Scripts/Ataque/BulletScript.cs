using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.gameObject.tag == "Enemy") {
			Destroy (gameObject);
			Destroy (col.gameObject);
		
		} 

		if (col.gameObject.tag == "Boss")
			Destroy (gameObject);
	}




}

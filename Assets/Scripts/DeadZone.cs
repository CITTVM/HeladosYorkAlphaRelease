using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void RestartScene(){

		SceneManager.LoadScene("GameOver");

	}

	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.gameObject.tag == "DeadZone") {

			RestartScene ();

		}
	}


}

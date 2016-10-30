using UnityEngine;
using System.Collections;

public class weaponScript : MonoBehaviour {

	public GameObject[] weapons;
	public GameObject weaponHere;


	void Start () {
		weaponHere = weapons [Random.Range (0, weapons.Length)];
		GetComponent<SpriteRenderer> ().sprite = weaponHere.GetComponent<SpriteRenderer> ().sprite;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	
	}








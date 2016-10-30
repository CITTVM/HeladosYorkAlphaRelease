using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NivelTermino : MonoBehaviour {

	public string menuPrincipal;

	public void irMenuPrincipal(){
		SceneManager.LoadScene (menuPrincipal);
	}
}

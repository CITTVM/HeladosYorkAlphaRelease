using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public string mainScene;

	public void VolverMenuPrincipal()
	{
		SceneManager.LoadScene (mainScene);
	}
}

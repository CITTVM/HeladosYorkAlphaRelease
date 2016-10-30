using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class prueba : MonoBehaviour {

	[SerializeField]
	private Text loadingText;
	// Use this for initialization
	void Start () {
		((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
	}
	
	// Update is called once per frame
	void Update () {
		loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

		MovieTexture pelicula = (MovieTexture)GetComponent<Renderer> ().material.mainTexture;

		if (!pelicula.isPlaying) {
			pelicula.Play();
		}
	}
}

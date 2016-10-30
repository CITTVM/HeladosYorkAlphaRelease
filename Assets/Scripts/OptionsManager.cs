using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour {

    private Slider _musicSlider;
    public string mPrincipal;
    public MusicManager musicManager;

	// Use this for initialization
	void Start () {
        _musicSlider = GameObject.Find("Slider").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MusicSliderUpdate(float valor)
    {
        musicManager.SetVolume(valor);
    }

    public void MusicToggle(bool valor)
    {
        _musicSlider.interactable = valor;
        musicManager.SetVolume(valor ? _musicSlider.value : 0f);
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene(mPrincipal);
    }
}

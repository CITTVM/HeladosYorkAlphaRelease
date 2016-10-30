using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public void SetVolume(float valor)
    {
        GetComponent<AudioSource>().volume = valor;
    }
}

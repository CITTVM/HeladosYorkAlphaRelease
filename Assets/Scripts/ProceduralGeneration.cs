using UnityEngine;
using System.Collections;
using System;

public class ProceduralGeneration : MonoBehaviour {

    public GameObject enemigo;
    public int cantEnemigos;
    public int min, max;

    private int maxEnemigos;
	// Use this for initialization
	void Start () {
        //maxEnemigos = cantEnemigos;
	}
	
	// Update is called once per frame
	void Update () {
        Generar();
	}

    private void Generar()
    {

        if (maxEnemigos <= cantEnemigos)
        {
            Instantiate(enemigo, RandomPosition(), Quaternion.identity);
        }
    }

    Vector2 RandomPosition()
    {
        int x, y;
        x = UnityEngine.Random.Range(min, max);
        y = UnityEngine.Random.Range(min, max);

        return new Vector2(x, y);
    }
}

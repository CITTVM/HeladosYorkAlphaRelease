using UnityEngine;
using System.Collections;

public class SettingSpawnPointLocation : MonoBehaviour {

    public GameObject[] spawns;
    private Vector3[] vectores;
    private int contador = 0;
    /////Enemigo1 volador/////
    public GameObject enemigo1;
    public GameObject enemigo2;
    public GameObject enemigo3;
    private int aire = 0;
    private int[] specialSpawn;
    public int cantidadEnemigos;
    public float[] anchoSpawns;


	// Use this for initialization
	void Start () {
        spawns = GameObject.FindGameObjectsWithTag("Soil");
        vectores = new Vector3[spawns.Length];
        specialSpawn = new int[spawns.Length];
        anchoSpawns = new float[spawns.Length];
        foreach (GameObject spawn in spawns)
        {
            var size = spawn.GetComponent<Collider2D>();
            anchoSpawns[contador] = (size.bounds.size.y / 1.7f);
            vectores[contador] = new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, 1);
            contador++;
        }
	}

    // Update is called once per frame
    void Update () {
        InstanciacionProcedimental();
	}
    //Hace falta sumar el Y a los enemigos dependiendo de el grosor de la
    //plataforma. yo subi sólo un poco y en algunas plataformas se ve bien 
    //nadamás.
    private void InstanciacionProcedimental()
    {
        int indicador = Random.Range(0, vectores.Length);
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < cantidadEnemigos)
        {
            if (Random.Range(0f,1f) >= 0.5f)
            {
				Instantiate(enemigo3, new Vector3(vectores[indicador].x, vectores[indicador].y + 2.8f + anchoSpawns[indicador], vectores[indicador].z), Quaternion.identity);
            }
            else if (Random.Range(0f,1f) >= 0.5f)
            {
				Instantiate(enemigo2, new Vector3(vectores[indicador].x, vectores[indicador].y + anchoSpawns[indicador], vectores[indicador].z), Quaternion.identity);
            }
            else
            {
				Instantiate(enemigo1, new Vector3(vectores[indicador].x, vectores[indicador].y + 7.5f + anchoSpawns[indicador], (float)(vectores[indicador].z - 1.0f) ), Quaternion.identity);
            }
        }
    }
}

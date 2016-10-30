using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CapaParalaje : MonoBehaviour {

    ///Script que se usa directamente en los gameObjects que usan las capas de background.
    /// 

    //Variables para normar la velocidad de movimiento en los 2 ejes y si el movimiento es en oposición.
    public float speedX;
    public float speedY;
    public bool moveInOppositeDirection;

    //Variables que tienen relevancia para la posición de la cámara.
    private Transform cameraTransform;
    private Vector3 previousCameraPosition;
    private bool previousMoveParallax;
    private OpcionParalaje options;

    //Método que entra en rigor cuando en el editor desde la camara utilizada se habilita el movimiento del paralaje.
    void OnEnable()
    {
        GameObject gameCamera = GameObject.Find("Main Camera");
        options = gameCamera.GetComponent<OpcionParalaje>();
        cameraTransform = gameCamera.transform;
        previousCameraPosition = cameraTransform.position;
    }

    //En tiempo real se realizan los calculos de la posición relativa de la camara en el nivel para subir los calculos a las capas de background.
    void Update()
    {
        if (options.moveParallax && !previousMoveParallax)
            previousCameraPosition = cameraTransform.position;

        previousMoveParallax = options.moveParallax;

        if (!Application.isPlaying && !options.moveParallax)
            return;

        Vector3 distance = cameraTransform.position - previousCameraPosition;
        float direction = (moveInOppositeDirection) ? -1f : 1f;
        transform.position += Vector3.Scale(distance, new Vector3(speedX, speedY)) * direction;

        previousCameraPosition = cameraTransform.position;
    }
}

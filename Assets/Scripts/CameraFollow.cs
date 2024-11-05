using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
   public GameObject player;
    public float cameraSpeed = 0.25f; 
    public Vector3 offset;

    // L�mites del mapa
    public Vector2 minLimit; // L�mite inferior izquierdo (Xmin, Ymin)
    public Vector2 maxLimit; // L�mite superior derecho (Xmax, Ymax)
    void Start()
    {
        player = GameObject.FindWithTag("Personaje");
    }

    // Update is called once per frame
    void Update()
    {

        // La posici�n deseada de la c�mara
        Vector3 desiredPosition = player.transform.position + offset;

        // Limitar la posici�n de la c�mara dentro de los l�mites del mapa
        float clampedX = Mathf.Clamp(desiredPosition.x, minLimit.x, maxLimit.x);
        float clampedY = Mathf.Clamp(desiredPosition.y, minLimit.y, maxLimit.y);

        // La posici�n limitada de la c�mara
        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        // Hacer que la c�mara se mueva suavemente hacia la posici�n deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, cameraSpeed);

        // Asignar la nueva posici�n a la c�mara
        transform.position = smoothedPosition;
    }
}

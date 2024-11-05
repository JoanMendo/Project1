using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
   public GameObject player;
    public float cameraSpeed = 0.25f; 
    public Vector3 offset;

    // Límites del mapa
    public Vector2 minLimit; // Límite inferior izquierdo (Xmin, Ymin)
    public Vector2 maxLimit; // Límite superior derecho (Xmax, Ymax)
    void Start()
    {
        player = GameObject.FindWithTag("Personaje");
    }

    // Update is called once per frame
    void Update()
    {

        // La posición deseada de la cámara
        Vector3 desiredPosition = player.transform.position + offset;

        // Limitar la posición de la cámara dentro de los límites del mapa
        float clampedX = Mathf.Clamp(desiredPosition.x, minLimit.x, maxLimit.x);
        float clampedY = Mathf.Clamp(desiredPosition.y, minLimit.y, maxLimit.y);

        // La posición limitada de la cámara
        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        // Hacer que la cámara se mueva suavemente hacia la posición deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, cameraSpeed);

        // Asignar la nueva posición a la cámara
        transform.position = smoothedPosition;
    }
}

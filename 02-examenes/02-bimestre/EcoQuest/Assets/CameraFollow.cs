using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // El transform del personaje a seguir
    public float smoothing = 5f;   // La velocidad de suavizado de la cámara
    public Vector3 offset;         // La distancia de la cámara al personaje

    void Start()
    {
        // Calcula la distancia inicial entre la cámara y el personaje
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // La posición deseada es la posición del personaje más el offset
        Vector3 targetPosition = target.position + offset;

        // Suaviza el movimiento de la cámara hacia la posición deseada
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.fixedDeltaTime);
    }
}
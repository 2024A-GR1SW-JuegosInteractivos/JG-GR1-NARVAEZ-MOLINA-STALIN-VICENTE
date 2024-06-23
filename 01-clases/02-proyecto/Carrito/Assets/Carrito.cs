using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define una clase llamada Carrito que hereda de MonoBehaviour
public class Carrito : MonoBehaviour
{
    // Define variables serializables para controlar la velocidad de giro y de movimiento
    [SerializeField] float steerSpeed = 200f; // Velocidad de giro
    [SerializeField] float moveSpeed = 15f;   // Velocidad de movimiento inicial
    [SerializeField] float velocidadRapido = 20f; // Velocidad al tocar el objeto "Rapido"
    [SerializeField] float velocidadLento = 5f;   // Velocidad al tocar el objeto "Lento"

    // Método llamado al inicio del juego
    void Start()
    {
        // Este método está vacío, no se ejecuta ninguna acción al inicio
    }

    // Método llamado una vez por frame
    void Update()
    {
        // Calcula la cantidad de giro basado en la entrada horizontal y la velocidad de giro
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        // Calcula la cantidad de movimiento basado en la entrada vertical y la velocidad de movimiento
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        // Aplica la rotación al objeto
        transform.Rotate(0, 0, -steerAmount);
        // Aplica la traslación al objeto
        transform.Translate(0, moveAmount, 0);
    }

    // Método llamado cuando otro objeto colisiona con este objeto
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto colisionado tiene la etiqueta "Rapido"
        if (other.tag == "Rapido")
        {
            // Imprime un mensaje en la consola
            Debug.Log("Ir Rapido");
            // Cambia la velocidad de movimiento a velocidadRapido
            moveSpeed = velocidadRapido;
        }
        // Verifica si el objeto colisionado tiene la etiqueta "Lento"
        if (other.tag == "Lento")
        {
            // Imprime un mensaje en la consola
            Debug.Log("Ir Lento");
            // Cambia la velocidad de movimiento a velocidadLento
            moveSpeed = velocidadLento;
        }
    }
}
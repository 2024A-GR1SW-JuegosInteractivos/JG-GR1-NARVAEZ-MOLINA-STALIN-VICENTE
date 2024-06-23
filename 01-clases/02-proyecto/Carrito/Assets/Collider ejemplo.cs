using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define una clase llamada ColliderEjemplo que hereda de MonoBehaviour
public class ColliderEjemplo : MonoBehaviour
{
    // Define variables serializables para controlar el retraso en la destrucción y los colores
    [SerializeField] float delayDestroy = 0.5f; // Tiempo de retraso antes de destruir el objeto
    private bool tienePaquete; // Indica si se tiene un paquete (por defecto es false)
    [SerializeField] Color32 tienePaqueteColor = new Color32(255,0,0,255); // Color cuando tiene un paquete
    [SerializeField] Color32 noTienePaqueteColor = new Color32(0,255,0,255); // Color cuando no tiene un paquete
    private SpriteRenderer spriteRenderer; // Referencia al componente SpriteRenderer

    // Método llamado al inicio del juego
    private void Start()
    {
        // Obtiene el componente SpriteRenderer del objeto
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Método llamado cuando ocurre una colisión
    void OnCollisionEnter2D(Collision2D other)
    {
        // Imprime un mensaje en la consola al detectar una colisión
        Debug.Log("Ouch!");
    }

    // Método llamado cuando otro objeto entra en el trigger de este objeto
    void OnTriggerEnter2D(Collider2D other)
    {
        // Imprime un mensaje en la consola al detectar la entrada en el trigger
        Debug.Log("Entrando en trigger!");

        // Verifica si el objeto colisionado tiene la etiqueta "Paquete" y no tiene paquete actualmente
        if (other.tag == "Paquete" && !tienePaquete)
        {
            // Imprime un mensaje en la consola
            Debug.Log("Recogio paquete");
            // Cambia el estado de tienePaquete a true
            tienePaquete = true;
            // Cambia el color del SpriteRenderer al color de "tienePaquete"
            spriteRenderer.color = tienePaqueteColor;
            // Destruye el objeto colisionado después de un retraso
            Destroy(other.gameObject, delayDestroy);
        }

        // Verifica si el objeto colisionado tiene la etiqueta "Cliente" y tiene un paquete
        if (other.tag == "Cliente" && tienePaquete)
        {
            // Cambia el estado de tienePaquete a false
            tienePaquete = false;
            // Cambia el color del SpriteRenderer al color de "noTienePaquete"
            spriteRenderer.color = noTienePaqueteColor;
            // Imprime un mensaje en la consola
            Debug.Log("Dejo paquete!");
        }
    }
}
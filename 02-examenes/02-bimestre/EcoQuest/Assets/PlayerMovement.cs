using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Configuración del Movimiento")]
    public float velocidadDeMovimiento = 5f;

    [Header("Animación")]
    private Animator animator;

    // Referencia al componente Rigidbody2D
    private Rigidbody2D rb2D;

    // Variables para almacenar el movimiento del jugador
    private float movimientoHorizontal;
    private float movimientoVertical;
    private bool mirandoDerecha = true; // Para controlar la dirección en la que mira el personaje

    void Start()
    {
        // Obtén el componente Rigidbody2D y Animator al iniciar el juego
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Captura el input del jugador para el movimiento horizontal (teclas de flecha o A/D)
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
        movimientoVertical = Input.GetAxisRaw("Vertical") * velocidadDeMovimiento;

        // Configura los parámetros en el Animator para controlar las animaciones
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));
        animator.SetFloat("Vertical", Mathf.Abs(movimientoVertical));
        animator.SetFloat("Speed", Mathf.Abs(movimientoHorizontal) + Mathf.Abs(movimientoVertical)); // Para controlar la animación de correr

        // Verifica la dirección del movimiento y voltea al personaje si es necesario
        if (mirandoDerecha && movimientoHorizontal < 0)
        {
            Girar();
        }
        else if (!mirandoDerecha && movimientoHorizontal > 0)
        {
            Girar();
        }
    }

    void FixedUpdate()
    {
        // Aplica el movimiento horizontal y vertical al Rigidbody2D
        rb2D.velocity = new Vector2(movimientoHorizontal, movimientoVertical);
    }

    void Girar()
    {
        // Cambia la dirección en la que está mirando el personaje
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
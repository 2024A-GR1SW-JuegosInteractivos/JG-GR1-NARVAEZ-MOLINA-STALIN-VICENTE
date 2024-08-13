using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclingManager : MonoBehaviour
{
    public bool isCorrectBasurero = true;  // Variable que indica si el jugador está en un basurero correcto
    private GameObject objetoRecogido = null;  // El objeto que el jugador está llevando
    private Animator animator;  // Referencia al Animator del jugador

    private void Start()
    {
        // Obtener la referencia al Animator del jugador
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Soltar el objeto si se presiona la tecla 'F'
        if (Input.GetKeyDown(KeyCode.F) && objetoRecogido != null)
        {
            Debug.Log("Soltando objeto: " + objetoRecogido.tag);
            objetoRecogido.transform.SetParent(null);
            objetoRecogido = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Recoger el objeto reciclable si aún no estamos cargando uno
        if (objetoRecogido == null)
        {
            if (other.CompareTag("Plastico") || other.CompareTag("Vidrio") || other.CompareTag("Papel") || other.CompareTag("Organico"))
            {
                objetoRecogido = other.gameObject;
                objetoRecogido.transform.SetParent(transform);  // Adjuntar el objeto al jugador
                objetoRecogido.transform.position = transform.position;  // Colocar el objeto en la posición del jugador
                Debug.Log("Has recogido el ítem reciclable con el tag: " + objetoRecogido.tag);
            }
        }

        // Verificar si estamos llevando un objeto y estamos entrando en un basurero
        else if (objetoRecogido != null)
        {
            if (other.CompareTag("PlasticoBasurero") && objetoRecogido.CompareTag("Plastico") ||
                other.CompareTag("VidrioBasurero") && objetoRecogido.CompareTag("Vidrio") ||
                other.CompareTag("PapelBasurero") && objetoRecogido.CompareTag("Papel") ||
                other.CompareTag("OrganicoBasurero") && objetoRecogido.CompareTag("Organico"))
            {
                Debug.Log("Reciclaje correcto: " + objetoRecogido.tag + ". Eliminando objeto.");
                Destroy(objetoRecogido);
                objetoRecogido = null;
                isCorrectBasurero = true;  // Estás en el basurero correcto
            }
            else
            {
                Debug.Log("Reciclaje incorrecto. No puedes reciclar " + objetoRecogido.tag + " en " + other.tag + ".");
                isCorrectBasurero = false;  // Estás en el basurero incorrecto
                animator.SetTrigger("ouch");  // Activar la animación de error
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Si salimos de un basurero y fue incorrecto, volvemos a activar la variable
        if (!isCorrectBasurero && (other.CompareTag("PlasticoBasurero") || 
                                   other.CompareTag("VidrioBasurero") || 
                                   other.CompareTag("PapelBasurero") || 
                                   other.CompareTag("OrganicoBasurero")))
        {
            Debug.Log("Saliste del basurero incorrecto: " + other.tag + ". Puedes intentar reciclar nuevamente.");
            isCorrectBasurero = true;  // Volver a permitir el reciclaje
        }
    }
}
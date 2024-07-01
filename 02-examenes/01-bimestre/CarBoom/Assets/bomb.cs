using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    private Transform currentCar; // El carrito al que está pegada la bomba
    public float countdown = 10f; // Tiempo en segundos antes de que la bomba explote
    private float timer;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        timer = countdown;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void AttachToCar(Transform car)
    {
        currentCar = car;
        transform.SetParent(car);
        transform.localPosition = Vector3.zero; // Ajusta la posición de la bomba al centro del carrito
        Debug.Log("Bomba pegada al carrito: " + car.name);
    }

    private void Update()
    {
        if (currentCar != null)
        {
            timer -= Time.deltaTime;
            UpdateColor();
            Debug.Log("Tiempo restante de la bomba: " + timer.ToString("F2") + "s");

            if (timer <= 0)
            {
                Explode();
            }
        }
    }

    private void UpdateColor()
    {
        float t = timer / countdown;
        Color bombColor = Color.Lerp(Color.red, Color.green, t);
        spriteRenderer.color = bombColor;
    }

    private void Explode()
    {
        if (currentCar != null)
        {
            Debug.Log("Bomba explotó en el carrito: " + currentCar.name);
            Destroy(currentCar.gameObject);
        }
        Destroy(gameObject); // Destruye la bomba
        RestartGame(); // Reinicia el juego
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BumperCar bumperCar = collision.GetComponent<BumperCar>();
        if (bumperCar != null && bumperCar.transform != currentCar)
        {
            AttachToCar(bumperCar.transform);
            bumperCar.hasBomb = true;
            timer = countdown; // Reinicia el temporizador al pasar la bomba
        }
    }

    public float GetTimer()
    {
        return timer;
    }

    private void RestartGame()
    {
        Debug.Log("Reiniciando el juego...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
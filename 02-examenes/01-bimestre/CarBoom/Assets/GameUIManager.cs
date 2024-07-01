using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Text bombTimerText;
    public Text gameDataText;
    public Bomb bomb; // Referencia a la bomba

    void Update()
    {
        if (bomb != null)
        {
            bombTimerText.text = "Bomb Timer: " + bomb.GetTimer().ToString("F2") + "s";
        }

        // Aquí puedes actualizar otros datos del juego, por ejemplo:
        gameDataText.text = "Car 1 has bomb: " + FindObjectOfType<CarController>().GetComponent<BumperCar>().hasBomb.ToString();
        gameDataText.text += "\nCar 2 has bomb: " + FindObjectOfType<CarController>().GetComponent<BumperCar>().hasBomb.ToString();
    }
}
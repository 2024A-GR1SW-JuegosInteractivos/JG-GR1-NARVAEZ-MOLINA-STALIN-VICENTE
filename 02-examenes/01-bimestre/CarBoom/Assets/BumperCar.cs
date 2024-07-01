using UnityEngine;

public class BumperCar : MonoBehaviour
{
    public bool hasBomb = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bomb bomb = collision.gameObject.GetComponentInChildren<Bomb>();
        if (bomb != null && !hasBomb)
        {
            bomb.AttachToCar(transform);
            hasBomb = true;
        }
    }
}
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 80f;
    public string horizontalInputName = "Horizontal";
    public string verticalInputName = "Vertical";

    void Update()
    {
        float horizontal = Input.GetAxis(horizontalInputName);
        float vertical = Input.GetAxis(verticalInputName);

        // Movimiento hacia adelante y hacia atrás
        Vector3 movement = transform.up * vertical * speed * Time.deltaTime;
        // Rotación
        Vector3 rotation = Vector3.forward * -horizontal * turnSpeed * Time.deltaTime;

        transform.Translate(movement, Space.World);
        transform.Rotate(rotation, Space.World);
    }
}
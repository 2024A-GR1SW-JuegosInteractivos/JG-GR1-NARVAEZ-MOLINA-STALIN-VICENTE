using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f;
    public string horizontalInputName = "Horizontal";
    public string verticalInputName = "Vertical";

    void Update()
    {
        float horizontal = Input.GetAxis(horizontalInputName);
        float vertical = Input.GetAxis(verticalInputName);

        Vector3 movement = transform.right * vertical * speed * Time.deltaTime;
        Vector3 rotation = Vector3.back * horizontal * turnSpeed * Time.deltaTime;

        transform.Translate(movement, Space.World);
        transform.Rotate(rotation, Space.World);
    }
}
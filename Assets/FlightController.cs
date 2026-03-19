using UnityEngine;

public class FlightController : MonoBehaviour
{
    public float speed = 12f;
    public float rotationSpeed = 40f;

    void Update()
    {
        float move = 0f;
        float turn = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
            move = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.DownArrow))
            move = -speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
            turn = -rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
            turn = rotationSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * turn);
    }
}
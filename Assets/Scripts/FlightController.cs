using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f;
    [SerializeField] private float yawSpeed = 45f;
    [SerializeField] private float rollSpeed = 45f;
    [SerializeField] private float thrustSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        float pitchInput = Input.GetAxis("Vertical");
        float yawInput = Input.GetAxis("Horizontal");

        float rollInput = 0f;
        if (Input.GetKey(KeyCode.Q)) rollInput = 1f;
        else if (Input.GetKey(KeyCode.E)) rollInput = -1f;

        float pitch = -pitchInput * pitchSpeed * Time.deltaTime;
        float yaw = yawInput * yawSpeed * Time.deltaTime;
        float roll = rollInput * rollSpeed * Time.deltaTime;

        transform.Rotate(pitch, yaw, roll);
    }

    private void HandleThrust()
    {
        float thrust = 0f;

        if (Input.GetKey(KeyCode.Space)) thrust = 1f;
        else if (Input.GetKey(KeyCode.LeftShift)) thrust = -1f;

        transform.Translate(Vector3.forward * thrust * thrustSpeed * Time.deltaTime);
    }
}
//FlightController.cs
// CENG 454 HW1: Sky-High Prototype
// Author:Gizemnur ÇIRTAN
// Studdent ID: 230446049



using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f ; //degrees/seconds
    [SerializeField] private float yawSpeed = 45f; //degrees/seconds
    [SerializeField] private float rollSpeed = 45f; //degrees/seconds
    [SerializeField] private float thrustSpeed = 5f; //units/seconds

    //Task 3-A Declare a private rigidbody field name "rb" 
    private Rigidbody rb;

    void Start()
    {
        //Task 3-B
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        //call movement every frame
        HandleRotation();
        HandleThrust();
    }

    //task 3-c
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

    //task 3-d
    private void HandleThrust()
    {
        float thrust = 0f;

        if (Input.GetKey(KeyCode.Space)) thrust = 1f;
        else if (Input.GetKey(KeyCode.LeftShift)) thrust = -1f;

        transform.Translate(Vector3.forward * thrust * thrustSpeed * Time.deltaTime);
    }
}
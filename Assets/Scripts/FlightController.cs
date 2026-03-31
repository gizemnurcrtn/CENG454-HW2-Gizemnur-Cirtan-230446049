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
        rb = GetComponent<Rigidbody>(); //get rigidbody
        rb.freezeRotation = true; //stop unity physic rotation 
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
        //pitch
        float upDownInput = Input.GetAxis("Vertical");
        transform.Rotate( Vector3.right * upDownInput*pitchSpeed*Time.deltaTime);
        //left right rotation
        float leftRightInput = Input.GetAxis("Horizontal");
        transform.Rotate( Vector3.up * leftRightInput *yawSpeed * Time.deltaTime) ;
        // Roll (q e)
        float rollValue = 0f ;
        if (Input.GetKey(KeyCode.Q))
        {
            rollValue = 1f; // turn left
        }
       
        else if (Input.GetKey(KeyCode.E))
        {
            rollValue = -1f; //turn right

        }
        //rotate around z-axis based on Q or E key
        transform.Rotate(Vector3.forward* rollValue * rollSpeed *Time.deltaTime);

    }

    //task 3-d
    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }

    }
}
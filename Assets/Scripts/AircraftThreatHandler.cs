//aircraftthraethandler.cs
using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private AudioSource hitAudioSource;
    [SerializeField] private FlightExamManager examManager;

    private Rigidbody rb;

    private void Start() //Task-3G: cache getcomponent<rigidbody>() into 'rb'
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collision) //Task-3H: if the missible hits the aircraft,apply the chosen penalty
    {
        if (!collision.CompareTag("Missile"))
            return;

        if (hitAudioSource != null)
            hitAudioSource.Play();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
            transform.rotation = respawnPoint.rotation;
        }

        if (examManager != null)
            examManager.FailMission();

        Destroy(collision.gameObject);
    }
}

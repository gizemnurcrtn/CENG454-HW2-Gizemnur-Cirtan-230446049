using UnityEngine;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (examManager != null)
            examManager.EnterDangerZone();
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (examManager != null)
            examManager.ExitDangerZone();
    }
}
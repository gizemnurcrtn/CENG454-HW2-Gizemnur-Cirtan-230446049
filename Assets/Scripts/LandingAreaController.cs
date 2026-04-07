using UnityEngine;

public class LandingAreaController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (examManager == null)
            return;

        if (examManager.CanCompleteLanding())
            examManager.SetMissionComplete();
        else
            examManager.RejectEarlyLanding();
    }
}
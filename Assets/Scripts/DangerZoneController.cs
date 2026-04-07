using System.Collections;
using UnityEngine;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private Transform playerTarget;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (examManager != null)
            examManager.EnterDangerZone();

        if (activeCountdown == null)
            activeCountdown = StartCoroutine(MissileCountdown());
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (activeCountdown != null)
        {
            StopCoroutine(activeCountdown);
            activeCountdown = null;
        }

        if (missileLauncher != null)
            missileLauncher.DestroyActiveMissile();

        if (examManager != null)
            examManager.ExitDangerZone();
    }

    private IEnumerator MissileCountdown()
    {
        yield return new WaitForSeconds(missileDelay);

        if (missileLauncher != null && playerTarget != null)
            missileLauncher.Launch(playerTarget);

        activeCountdown = null;
    }
}
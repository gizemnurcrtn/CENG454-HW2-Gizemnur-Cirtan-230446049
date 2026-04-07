//dangerzonecontroller.cs
using System.Collections;
using UnityEngine;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private Transform playerTarget;
    [SerializeField] private float missileDelay = 5f;
    [SerializeField] private AudioSource warningAudioSource;

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player")) //todo:confirm the player tag
            return;

        if (examManager != null)
            examManager.EnterDangerZone(); //push the warning masage

        if (warningAudioSource != null)
            warningAudioSource.Play();

        if (activeCountdown == null)
            activeCountdown = StartCoroutine(MissileCountdown()); //start the delayed missile launch countdown
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!collision.CompareTag("Player")) //confirm the player tag
            return;

        if (activeCountdown != null)
        {
            StopCoroutine(activeCountdown); //cancel any pending launch coutdown
            activeCountdown = null;
        }

        if (missileLauncher != null)
            missileLauncher.DestroyActiveMissile(); //destroy the active missile and clear the HUD warning

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
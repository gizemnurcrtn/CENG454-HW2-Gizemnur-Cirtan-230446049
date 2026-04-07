//missilelauncher.cs
//CENG454-HW2 Midterm: Sky-High Prototype2
//Author:Gizemnur Çırtan
//Student ID:230446049

using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioSource launchAudioSource;

    private GameObject activeMissile;

    public GameObject Launch(Transform target)
    {
        //Task-3A: instantiate the missile at launchpoint
        //Task-3B: give the missile its target
        //Task-3C: play launch audio and return the spawned missile
        if (missilePrefab == null || launchPoint == null || target == null)
            return null;

        if (activeMissile != null)
            return activeMissile;

        activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);

        MissileHoming homing = activeMissile.GetComponent<MissileHoming>();
        if (homing != null)
            homing.SetTarget(target);

        if (launchAudioSource != null)
            launchAudioSource.Play();

        return activeMissile;
    }

    public void DestroyActiveMissile()

    {
        //Task-3D: destroy the current missile safely if one exists
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }
    }
}

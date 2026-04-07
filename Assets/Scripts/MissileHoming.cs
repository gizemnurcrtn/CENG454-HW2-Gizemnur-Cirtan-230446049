//missilehoming.cs
using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float turnSpeed = 5f;

    private Transform target;

    public void SetTarget(Transform newTarget)

    {
        //Task-3E: cache the aircraft transform
        target = newTarget;
    }

    private void Update()
    {
        //Task-3F: rorate toward the target and move forward
        if (target == null)
            return;

        Vector3 direction = (target.position - transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            turnSpeed * Time.deltaTime
        );

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
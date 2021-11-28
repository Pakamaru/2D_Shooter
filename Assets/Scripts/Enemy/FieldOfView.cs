using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField]
    private float radius;
    [SerializeField]
    private float angle;

    [SerializeField]
    private LayerMask targetMask;
    [SerializeField]
    private LayerMask obstacleMask;

    private bool canSee;

    private void Start()
    {
        StartCoroutine(FoVRoutine());
    }

    private IEnumerator FoVRoutine()
    {
        float delay = 0.5f;
        WaitForSeconds wait = new WaitForSeconds(delay);
        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider2D[] rangeChecks = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), radius, targetMask);
        if (rangeChecks.Length > 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.position, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                {
                    canSee = true;
                }
                else
                {
                    canSee = false;
                }
            }
            else
            {
                canSee = false;
            }
        }
        else if (canSee)
        {
            canSee = false;
        }
    }

    public bool InView()
    {
        return canSee;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
	public float radius = 5f;
	[Range(1, 360)] public float angle = 45f;

	public GameObject playerRef;

	public LayerMask targetMask;
	public LayerMask obstructionMask;

	public bool canSeePlayer { get; private set; }

	private void Start()
	{
		playerRef = GameObject.FindGameObjectWithTag("Player");
		StartCoroutine(FOVRoutine());

	}
	private IEnumerator FOVRoutine()
	{
		WaitForSeconds wait = new WaitForSeconds(0.2f);

		while (true)
		{
			yield return wait;
			FieldOfViewCheck();
		}
	}

	private void FieldOfViewCheck()
	{
		Collider2D[] rangeChecks = Physics2D.OverlapCircleAll(transform.position, radius, targetMask);
		if (rangeChecks.Length > 0)
		{
			Transform target = rangeChecks[0].transform;
			Vector2 directionToTarget = (target.position - transform.position).normalized;

			if (Vector2.Angle(transform.rotation.y == 180 ? -transform.right : transform.right, directionToTarget) < angle / 2)
			{
				float distanceToTarget = Vector2.Distance(transform.position, target.position);
				if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
				{
					canSeePlayer = true;
					Debug.Log("Player Found");
					playerRef.GetComponentInParent<Player_Sus_Meter>().UpdateSus(1f);
					//Destroy(GameObject.FindGameObjectWithTag("Player"));
				}
				else
				{
					canSeePlayer = false;
				}
			}
			else
			{
				canSeePlayer = false;
			}
		}
		else if (canSeePlayer)
		{
			canSeePlayer = false;
		}
	}

    private void OnDrawGizmos()
    {
		Gizmos.color = Color.white;
		UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

		Vector3 angle01 = DirectionFromAngle(-angle / 2);
		Vector3 angle02 = DirectionFromAngle(angle / 2);

		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
		Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);

		if (canSeePlayer)
        {
			Gizmos.color = Color.green;
			Gizmos.DrawLine(transform.position, playerRef.transform.position);
        }
	}

	private Vector2 DirectionFromAngle(float angleInDegrees)
    {
		return (Vector2)(Quaternion.Euler(0, 0, angleInDegrees) *
			(transform.rotation.y == 180 ? -transform.right : transform.right));
	}
}


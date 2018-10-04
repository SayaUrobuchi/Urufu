using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour {

	public Transform Target;
	public float Speed = 1.5f;
	public float TraceDistance = .3f;
	public float DistanceToSpeedRate = 2f;
	public float DistanceToStop = .05f;

	private Rigidbody2D rb;
	private bool tracing = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Target != null)
		{
			Vector2 dir = (Target.position - transform.position);
			if (!tracing)
			{
				if (dir.magnitude < TraceDistance)
				{
					return;
				}
				tracing = true;
			}
			else
			{
				rb.velocity = dir.normalized * (Speed + (dir.magnitude * DistanceToSpeedRate));
				if (dir.magnitude < DistanceToStop)
				{
					rb.velocity = Vector2.zero;
					tracing = false;
				}
			}
		}
	}
}

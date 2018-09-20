using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour {

	public Transform Target;
	public float Speed = .6f;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Target != null)
		{
			Vector2 dir = (Target.position - transform.position).normalized;
			rb.velocity = dir * Speed;
		}
	}
}

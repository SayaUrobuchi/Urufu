using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMover : MonoBehaviour {

	public float Speed = 2.5f;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = Vector2.right * Speed;
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}

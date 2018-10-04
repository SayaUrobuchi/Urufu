using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpable : MonoBehaviour {

	public string GroundTag = "Block";
	public float Force = 10f;
	public Rigidbody2D JumperRB;
	public bool CanJumpNow = true;
	
	private int grounded = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (CanJumpNow && IsGrounded() && JumperRB != null)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				JumperRB.velocity += Vector2.up * Force;
			}
		}
	}

	public bool IsGrounded()
	{
		return grounded > 0;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == GroundTag)
		{
			grounded++;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.tag == GroundTag)
		{
			grounded--;
		}
	}
}

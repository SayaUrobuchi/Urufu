using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharaControl : MonoBehaviour {

	public enum MoveType
	{
		Velocity, 
		Force, 
		Transform, 
	}

	public MoveType MoveWay = MoveType.Velocity;
	public float Speed = 100f;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = Vector2.left;
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		if (MoveWay == MoveType.Velocity)
		{
			rb.velocity = (new Vector2(x, y)) * Speed;
		}
		else if (MoveWay == MoveType.Transform)
		{
			transform.Translate(new Vector2(x, y) * Speed / 10);
		}
		else if (MoveWay == MoveType.Force)
		{
			rb.AddForce(new Vector2(x, y) * Speed);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("collide!!");
	}
}

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
	public Animator AniMaid;  // 指定要改變 Parameter 的 Animator
	public bool Flip = false;

	private Rigidbody2D rb;
	private SpriteRenderer spr;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = Vector2.left;
		if (AniMaid == null)
		{
			AniMaid = GetComponent<Animator>();
		}
		spr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis("Horizontal");
		//float y = Input.GetAxis("Vertical");
		float y = rb.velocity.y;
		float accerate = 1f;
		if (Input.GetKey(KeyCode.LeftShift))  // 按住 Shift 加速
		{
			accerate = 2f;
		}
		if (MoveWay == MoveType.Velocity)
		{
			rb.velocity = new Vector2(x * Speed * accerate, y);
		}
		else if (MoveWay == MoveType.Transform)
		{
			transform.Translate(new Vector2(x * Speed / 10 * accerate, y));
		}
		else if (MoveWay == MoveType.Force)
		{
			rb.AddForce(new Vector2(x * Speed * accerate, y));
		}
		if (Flip)
		{
			if (x > 0f)
			{
				Flip = false;
			}
		}
		else
		{
			if (x < 0f)
			{
				Flip = true;
			}
		}
		spr.flipX = Flip;
		if (AniMaid != null)  // 如果有設定 Animator 就改變參數
		{
			AniMaid.SetFloat("MoveSpeed", accerate);
			AniMaid.SetFloat("MoveHDir", Mathf.Abs(x));
		}
	}
}

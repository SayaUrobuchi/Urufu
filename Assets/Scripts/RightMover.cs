using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMover : MonoBehaviour {

	public int Integer = 8;
	public float Float = .25f;
	public bool Bool = true;
	public string String = "Shxt";

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		Debug.Log(Integer);
		Debug.Log(Float);
		Debug.Log(Bool);
		Debug.Log(String);
	}
	
	// Update is called once per frame
	void Update ()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		float speedRate = 1f;
		if (Input.GetKey(KeyCode.LeftControl))
		{
			speedRate = 2.5f;
		}
		rb.velocity = new Vector2(x, y) * speedRate;
	}
}

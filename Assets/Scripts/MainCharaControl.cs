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
	}
	
	// Update is called once per frame
	void Update () {
		float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (MoveWay == MoveType.Velocity)
        {
            rb.velocity = (new Vector2(hor, ver)) * Speed * Time.deltaTime;
        }
        else if (MoveWay == MoveType.Transform)
        {
            transform.Translate(new Vector2(hor, ver) * Speed * Time.deltaTime / 10);
        }
        else if (MoveWay == MoveType.Force)
        {
            rb.AddRelativeForce(new Vector2(hor, ver) * Speed * Time.deltaTime);
            //rb.AddForce(new Vector2(hor, ver) * Speed * Time.deltaTime);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collide!!");
    }
}

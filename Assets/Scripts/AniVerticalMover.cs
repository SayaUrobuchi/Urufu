using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniVerticalMover : MonoBehaviour {

	public AnimationCurve Curve = new AnimationCurve();
	public float StartY = 0f;
	public float DeltaY = 10f;
	public float MoveTime = 1f;

	private float timer = 0f;
	private float tempX;

	// Use this for initialization
	void Start () {
		tempX = transform.localPosition.x;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= MoveTime)
		{
			timer -= MoveTime;
		}
		float curY = StartY + (DeltaY-StartY) * Curve.Evaluate(timer / MoveTime);
		transform.localPosition = new Vector2(tempX, curY);
	}
}

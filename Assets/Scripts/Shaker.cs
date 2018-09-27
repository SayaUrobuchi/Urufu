using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour {

	public float Power = .01f;
	public float ShakeInterval = .01f;
	public bool Shake = false;

	private float timer;
	private Vector3 pos;

	// Use this for initialization
	void Start () {
		pos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (Shake)
		{
			timer += Time.deltaTime;
			if (timer >= ShakeInterval)
			{
				timer -= ShakeInterval;
				transform.localPosition = pos + new Vector3(Random.Range(0f, Power), Random.Range(0f, Power));
			}
		}
		else
		{
			transform.localPosition = pos;
		}
	}
}

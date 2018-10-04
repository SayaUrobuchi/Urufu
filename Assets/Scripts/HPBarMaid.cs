using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarMaid : MonoBehaviour {

	public float Speed = 1f;
	public Image CurrentBar;

	private float targetRate = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CurrentBar != null)
		{
			Vector3 scale = CurrentBar.transform.localScale;
			scale.x = Mathf.Lerp(scale.x, targetRate, Speed * Time.deltaTime);
			CurrentBar.transform.localScale = scale;
		}
	}

	public void SetHPRate(float rate)
	{
		targetRate = Mathf.Clamp01(rate);
	}
}

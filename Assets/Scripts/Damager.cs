using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

	public string TargetTag = "Enemy";
	public int Damage = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == TargetTag)
		{
			MBattler mb = collision.GetComponent<MBattler>();
			if (mb != null)
			{
				mb.TakeDamage(Damage);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycler : MonoBehaviour {

	public string[] RecycleTargetTag = new string[] { "Shot" };

	private Dictionary<string, bool> recycleTable = new Dictionary<string, bool>();

	// Use this for initialization
	void Start () {
		for (int i = 0; i < RecycleTargetTag.Length; i++)
		{
			recycleTable[RecycleTargetTag[i]] = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (recycleTable.ContainsKey(collision.tag))
		{
			Destroy(collision.gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZankiMaid : MonoBehaviour {

	public int Limit = 8;
	public GameObject ZankiTemplate;

	private List<GameObject> list = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
		{
			Remove();
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			Add();
		}
	}

	public void Add()
	{
		ChangeTo(list.Count + 1);
	}

	public void Remove()
	{
		ChangeTo(list.Count - 1);
	}

	public void ChangeTo(int value)
	{
		int targetCount = Mathf.Clamp(value, 0, Limit);
		if (list.Count < targetCount)
		{
			while (list.Count < targetCount)
			{
				list.Add(Instantiate(ZankiTemplate, transform));
			}
		}
		else if (list.Count > targetCount)
		{
			while (list.Count > targetCount)
			{
				Destroy(list[list.Count-1]);
				list.RemoveAt(list.Count-1);
			}
		}
	}
}

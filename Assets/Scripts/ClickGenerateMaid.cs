using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickGenerateMaid : MonoBehaviour {

	public GameObject GenerateTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GenerateTarget != null)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Vector3 mousePos = Input.mousePosition;
				Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
				worldPos.z = 0;
				GameObject obj = Instantiate(GenerateTarget);
				obj.transform.position = worldPos;
			}
		}
	}
}

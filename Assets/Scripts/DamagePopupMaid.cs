using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePopupMaid : MonoBehaviour {

	public static DamagePopupMaid Summon;
	public GameObject DamagePopupTemplate;

	// Use this for initialization
	void Start () {
		Summon = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Popup(int value, Vector3 worldPos)
	{
		if (DamagePopupTemplate != null)
		{
			GameObject p = Instantiate(DamagePopupTemplate, transform);
			Text t = p.GetComponentInChildren<Text>();
			t.text = value.ToString();
			p.transform.position = worldPos;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGMMaid : MonoBehaviour {

	public AudioClip[] BGMList;

	private AudioSource audioSource;
	private int dice;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		dice = Random.Range(0, BGMList.Length);
		if (BGMList != null && dice < BGMList.Length && audioSource != null)
		{
			audioSource.loop = true;
			audioSource.clip = BGMList[dice];
			audioSource.Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

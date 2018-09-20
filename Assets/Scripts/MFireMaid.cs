using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFireMaid : MonoBehaviour {

	public bool InputToFire = true;  // 是否吃輸入發射；敵方的話就不應該
	public KeyCode FireKey = KeyCode.Z;  // 發射鍵
	public GameObject ShotObject;  // 被發射的東西
	public Transform ShotPosition;  // 發射位置；作為定位點的可用 Transform 型別
	public int ShotPerSecond = 3;  // 射速最多每秒幾發

	private float timer = 0f;
	private float shotInterval;

	// Use this for initialization
	void Start () {
		shotInterval = 1f / ShotPerSecond;  // 預先算出每發間隔秒數
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0f)  // 如果在發射冷卻中
		{
			timer -= Time.deltaTime;
		}
		else if (InputToFire && Input.GetKey(FireKey))  // 如果不在冷卻、且有按發射的話
		{
			Shot();
		}
	}

	private void Shot()  // 發射!!
	{
		if (ShotObject != null)
		{
			GameObject shot = Instantiate(ShotObject);  // 複製 ShotObject 生成被發射物
			Vector2 pos = transform.position;  // 抓取目前物件的世界座標作為預設發射點
			if (ShotPosition != null)  // 如果有指定發射位置
			{
				pos = ShotPosition.position;  // 將發射點改為發射參照點的世界座標
			}
			shot.transform.position = pos;  // 將發射物的座標定位到發射座標
			timer = shotInterval;  // 進入發射冷卻
		}
	}
}

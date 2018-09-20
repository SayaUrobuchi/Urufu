using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 裝載後才能使用 Text

public class TextDisplayMaid : MonoBehaviour {

	public string DisplayText;  // 實際要顯示的目標文字
	public float Speed = 1f;  // 顯示速度：字/每秒
	public float DisplayTime = 2f;  // 顯示多久就重新來過；負數代表不重新來過

	private Text textContainer;  // 存 Text Component 用
	private float timer = 0f;  // 計時器
	private int displayProgress = 0;  // 顯示到第幾個字

	// Use this for initialization
	void Start () {
		textContainer = GetComponent<Text>();  // 抓取身上的 TextComponent
		resetDisplayProgress();  // 先重設顯示進度
	}
	
	// Update is called once per frame
	void Update () {
		// 如果還沒顯示完
		if (displayProgress < DisplayText.Length)
		{
			timer += Time.deltaTime;  // 計時
			float timePerCharacter = 1 / Speed;  // 換算出每字需要的秒數
			while (timer >= timePerCharacter)  // 如果時間累積到該顯示下個字了
			{
				timer -= timePerCharacter;
				displayProgress++;  // 多顯示一個字
			}
			displayProgress = Mathf.Min(displayProgress, DisplayText.Length);  // 限制目前字數不超過目標字數
			textContainer.text = DisplayText.Substring(0, displayProgress);  // 將顯示的文字設成目標文字的前幾個字
		}
		// 顯示完的話，如果需要重新來過就繼續計時
		else if (DisplayTime > 0f)
		{
			timer += Time.deltaTime;
			if (timer >= DisplayTime)  // 顯示時間結束
			{
				resetDisplayProgress();  // 重置顯示進度
				timer -= DisplayTime;  // 重置計時器
			}
		}
	}

	private void resetDisplayProgress()
	{
		textContainer.text = "";  // 將顯示文字清空
		displayProgress = 0;  // 顯示進度歸零
	}
}

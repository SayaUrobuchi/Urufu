using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MBattler : MonoBehaviour {

	public Text HPTextContainer;
	public Text MaxHPTextContainer;
	public HPBarMaid HPBar;
	public int HP;
	public int MaxHP;
	public int ChangePerTick = -4;  // 每次的變動量
	public float TimePerTick = .5f;  // 每次變動間隔幾秒
	public float DamageInterval = .8f;  // 受傷後無敵時間

	private float timer = 0f;
	private float damageTimer = 0f;

	// Use this for initialization
	void Start () {
		if (MaxHPTextContainer)
		{
			MaxHPTextContainer.text = MaxHP.ToString();  // 最大血量通常不變，可以一開始就設好，之後不動
		}
		OnHPChanged();  // 一開始先讓血量顯示目前值，否則變動前會維持預設的不正確數字
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= TimePerTick)  // 如果到了血量該變動的間隔
		{
			timer -= TimePerTick;
			HP += ChangePerTick;
			OnHPChanged();
		}
		if (damageTimer > 0f)  // 受傷後無敵時間倒計時
		{
			damageTimer -= Time.deltaTime;
		}
	}

	private void OnHPChanged()  // 血量改變時要做的事
	{
		HP = Mathf.Clamp(HP, 0, MaxHP);  // 把血量卡在 0 和 MaxHP 之間
		if (HPTextContainer != null)  // 如果有參照到 HP 顯示 UI 的話
		{
			HPTextContainer.text = HP.ToString();  // 利用 .ToString() 可將數字轉成字串
		}
		if (HPBar != null)
		{
			HPBar.SetHPRate((float)HP/MaxHP);
		}
		if (HP == 0)
		{
			Destroy(gameObject);
		}
	}

	public void TakeDamage(int damage, bool interval = true, bool ignoreInterval = false)
	{
		if (ignoreInterval || damageTimer <= 0f)
		{
			HP -= damage;
			if (interval)
			{
				damageTimer = DamageInterval;
			}
			DamagePopupMaid.Summon.Popup(damage, transform.position);
			OnHPChanged();
		}
	}
}

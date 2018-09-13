using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToolTip : UIElement 
{
	[SerializeField]
	Vector3 tooltipOffset;

	[SerializeField]
	TextMeshProUGUI title;

	[SerializeField]
	TextMeshProUGUI alive;

	[SerializeField]
	TextMeshProUGUI inCastle;

	[SerializeField]
	TextMeshProUGUI dead;

	Vector2 screenSize;

	public void Start()
	{
		screenSize = new Vector2(Screen.width, Screen.height);
	}

	public override void Tick(float _deltaTime)
	{
		Vector2 pos = Input.mousePosition;
		transform.position = new Vector2(pos.x + (screenSize.x / tooltipOffset.x), pos.y + (screenSize.y / tooltipOffset.y));
		
	}

	public void UpdateToolTip(string _title, int _alive, int _inCastle, int _dead)
	{
		this.title.text = _title;
		this.alive.text = _alive.ToString();
		this.inCastle.text = _inCastle.ToString();
		this.dead.text = _dead.ToString();
	}
}

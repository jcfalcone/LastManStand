using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarLocal : UIElement 
{
	[SerializeField]
	TemplateUnits target;
	
	[SerializeField]
	Image fillBar;

	[SerializeField]
	float threshold = 2;

	[SerializeField]
	float speed;

	[SerializeField]
	Vector3 offset;

	float currHealth = 1;

	bool hasTarget = false;
	
	// Update is called once per frame
	public override void Tick (float _deltaTime) 
	{
		if(target == null)
		{
			if(this.currHealth != 1)
			{
				this.fillBar.fillAmount = Mathf.Lerp(this.fillBar.fillAmount, this.currHealth, _deltaTime * 2f);
			}

			return;
		}

		this.hasTarget = true;

		Vector3 targetPos = target.transform.position;
		targetPos.y = transform.position.y;

		if(Vector3.Distance(targetPos, transform.position) > this.threshold)
		{
			transform.position = targetPos;
			return;
		}

		transform.position = Vector3.Lerp(transform.position, targetPos, _deltaTime * this.speed);

		this.fillBar.fillAmount = Mathf.Lerp(this.fillBar.fillAmount, this.target.HealthRatio, _deltaTime * 2f);
	}

	public void SetTarget(TemplateUnits _target)
	{
		this.target = _target;
	}

	public void SetHealthBar(float _targetHealth)
	{
		this.currHealth = _targetHealth;
	}

	public override bool HasToDestroy()
	{
		return this.hasTarget && this.target == null;
	}
}

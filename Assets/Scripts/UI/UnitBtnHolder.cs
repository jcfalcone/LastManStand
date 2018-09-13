using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Falcone.Variables;

public class UnitBtnHolder : UIElement 
{
	[SerializeField]
	Image blockBtn;

	[SerializeField]
	FloatScriptable timePerc;

	[SerializeField]
	IntScriptable currAmountUnit;

	public override void Tick(float _deltaTime)
	{
		if(this.currAmountUnit.value == 0)
		{
			this.blockBtn.fillAmount = this.timePerc.value;

			if(!this.blockBtn.gameObject.activeSelf)
			{
				this.blockBtn.gameObject.SetActive(true);
			}
		}
		else
		{
			if(this.blockBtn.gameObject.activeSelf)
			{
				this.blockBtn.gameObject.SetActive(false);
			}
		}
	}
}

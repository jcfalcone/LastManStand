using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;
using Falcone.Events;
using Falcone.Variables;

[CreateAssetMenu(menuName="AI/Spawn/Add Unit")]
public class AddUnits : TemplateAction 
{
	[SerializeField]
	float cooldown;

	[SerializeField]
	IntScriptable currUnits;

	[SerializeField]
	IntScriptable totalUnits;

	[SerializeField]
	FloatScriptable addUnitTimerPerc;

	
	[SerializeField]
	GameEvent uiEvent;

	float remainCoolDown;

	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		if(!AIMaster.instance.HasStarted())
		{
			return;
		}
		
		if(this.currUnits.value >= this.totalUnits.value)
		{
			this.remainCoolDown = this.cooldown;
			return;
		}

		this.remainCoolDown -= _delta;
		this.addUnitTimerPerc.value = this.remainCoolDown / this.cooldown;

		if(this.remainCoolDown <= 0)
		{
			this.currUnits.value++;
			this.remainCoolDown = this.cooldown;

			this.uiEvent.Raise();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Actions/Set Stopping Distance")]
public class SetStoppingDistance : TemplateAction 
{
	[SerializeField]
	float stopDistance;

	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		TemplateUnits unit = _controller as TemplateUnits;

		unit.agent.stoppingDistance = this.stopDistance;
	}
}

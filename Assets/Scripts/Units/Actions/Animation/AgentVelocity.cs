using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Animations/Velocity")]
public class AgentVelocity : TemplateAction 
{
	[SerializeField]
	string VariableName;

	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		TemplateUnits unit = _controller as TemplateUnits;

		unit.anim.SetFloat(this.VariableName, unit.agent.velocity.magnitude);
	}
}

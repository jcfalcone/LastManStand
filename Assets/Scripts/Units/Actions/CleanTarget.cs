using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Actions/Clear Target")]
public class CleanTarget : TemplateAction
{
	Vector3 vectorZero = Vector3.zero;
	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		TemplateUnits unit = _controller as TemplateUnits;
		unit.targetPosition = this.vectorZero;
		unit.targetBuild = null;
		unit.targetBuildData = null;
	}
}

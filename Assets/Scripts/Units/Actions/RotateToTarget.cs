using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Actions/Rotate to Target")]
public class RotateToTarget : TemplateAction
{
	[SerializeField]
	float rotationSpeed = 2;

	Vector3 vectorZero = Vector3.zero;

	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		TemplateUnits unit = _controller as TemplateUnits;

		Vector3 targetPosition = this.vectorZero;

		if(unit.targetEnemy != null)
		{
			targetPosition = unit.targetEnemy.transform.position;
		}
		else if(unit.targetBuildData != null && unit.targetBuildData.obj != null)
		{
			targetPosition = unit.targetBuildData.obj.transform.position;
		}
		else
		{
			targetPosition = unit.agent.destination;
		}

		Vector3 direction = (targetPosition - unit.transform.position).normalized;
		direction.y = 0;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        unit.transform.rotation = Quaternion.Slerp(unit.transform.rotation, lookRotation, Time.deltaTime * this.rotationSpeed);
	}
}

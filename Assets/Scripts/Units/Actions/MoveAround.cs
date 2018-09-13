using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/MoveAround")]
public class MoveAround : TemplateAction
{
	[SerializeField]
	CityData data;

	Vector3 vectorZero = Vector3.zero;

	Vector3 StartPosition;
	Vector3 NextPosition;
	Vector3 NextDirection;
	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		TemplateUnits unit = _controller as TemplateUnits;

		if(unit.targetPosition == vectorZero)
		{
			unit.targetPosition = Random.insideUnitSphere * this.data.Radius;
			unit.targetPosition.y = _controller.transform.position.y;
			unit.agent.SetDestination(unit.targetPosition);
		}
	}
}

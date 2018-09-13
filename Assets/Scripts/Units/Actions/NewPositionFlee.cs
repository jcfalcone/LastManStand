using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Actions/Flee Position")]
public class NewPositionFlee : TemplateAction 
{
	[SerializeField]
	string buildTag;

	[SerializeField]
	float distance;

	Vector3 vectorZero = Vector3.zero;

	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		if(!_controller.gameObject.activeSelf)
		{
			return;
		}

		TemplateUnits unit = _controller as TemplateUnits;

		if(unit.targetPosition == vectorZero)
		{
			if(unit.targetBuild == null)
			{
				Vector3 newPosition = unit.transform.forward * Random.Range(this.distance, this.distance);
				newPosition += unit.transform.right * Random.Range(-this.distance, this.distance);

				unit.targetPosition = newPosition;
				unit.targetPosition.y = _controller.transform.position.y;
				unit.targetBuild = null;
				
				unit.agent.SetDestination(unit.targetPosition);
			}

		}
	}
}

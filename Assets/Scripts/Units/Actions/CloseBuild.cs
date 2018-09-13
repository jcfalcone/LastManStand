using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Actions/Closest Build")]
public class CloseBuild : TemplateAction 
{
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
			ConstructionData data = CityMaster.instance.GetClosestBuild(_controller.transform.position);

			if(data != null)
			{

				unit.targetPosition = data.obj.transform.position;
				unit.targetPosition.y = _controller.transform.position.y;
				unit.targetBuild = data.ID;
				unit.targetBuildData = data;
				
				unit.agent.SetDestination(unit.targetPosition);
			}

		}
	}
}

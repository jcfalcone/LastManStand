using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Actions/Build Position")]
public class BuildPosition : TemplateAction 
{
	[SerializeField]
	string buildTag;

	[SerializeField]
	bool checkIsAlive = false;

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
			if(checkIsAlive)
			{
				if(!CityMaster.instance.IsBuildAlive(this.buildTag))
				{
					return;
				}
			}

			if(CityMaster.instance.HasFreeSlot(this.buildTag))
			{
				ConstructionData data = CityMaster.instance.FindBuild(this.buildTag);

				unit.targetPosition = data.obj.transform.position;
				unit.targetPosition.y = _controller.transform.position.y;
				unit.targetBuild = this.buildTag;
				unit.targetBuildData = data;
				
				unit.agent.SetDestination(unit.targetPosition);
			}

		}
	}
}

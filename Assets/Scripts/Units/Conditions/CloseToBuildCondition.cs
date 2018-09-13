using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Conditions/Close to Build")]
public class CloseToBuildCondition : TemplateCondition
{
	[SerializeField]
	bool checkUnitsSlot; 

	[SerializeField]
	float minDistance;

	public override bool CheckCondition(TemplateControllerCustom _object)
	{
		TemplateUnits units = _object as TemplateUnits;

		if(units.targetBuild == null)
		{
			return false;
		}
		
		if(Vector3.Distance(units.targetPosition, units.transform.position) < this.minDistance)
		{
			if(this.checkUnitsSlot && !CityMaster.instance.HasFreeSlot(units.targetBuild))
			{
				return false;
			}

			return true;
		}

		return false;
	}
}

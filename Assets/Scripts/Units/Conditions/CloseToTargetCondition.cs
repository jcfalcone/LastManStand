using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Conditions/Close to Target")]
public class CloseToTargetCondition : TemplateCondition
{
	public override bool CheckCondition(TemplateControllerCustom _object)
	{
		TemplateUnits units = _object as TemplateUnits;
		
		if(Vector3.Distance(units.agent.destination, units.transform.position) < units.agent.stoppingDistance)
		{
			return true;
		}

		return false;
	}
}

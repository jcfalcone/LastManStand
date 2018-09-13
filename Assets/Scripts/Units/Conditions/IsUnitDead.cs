using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Conditions/Is Dead")]
public class IsUnitDead : TemplateCondition 
{
	public override bool CheckCondition(TemplateControllerCustom _object)
	{
		TemplateUnits units = _object as TemplateUnits;

		if(!units.isAlive)
		{
			return true;
		}

		return false;
	}
}

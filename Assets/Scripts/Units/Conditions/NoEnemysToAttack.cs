using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Conditions/No Enemys to Attack")]
public class NoEnemysToAttack : TemplateCondition 
{
	public override bool CheckCondition(TemplateControllerCustom _object)
	{
		TemplateUnits guard = _object as TemplateUnits;

		if(guard.targetEnemys.Count <= 0)
		{
			return true;
		}

		return false;
	}
}

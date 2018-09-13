using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Conditions/Has Attackers")]
public class HasAttackers : TemplateCondition 
{
	public override bool CheckCondition(TemplateControllerCustom _object)
	{
		return CityMaster.instance.HasAttackers();
	}
}

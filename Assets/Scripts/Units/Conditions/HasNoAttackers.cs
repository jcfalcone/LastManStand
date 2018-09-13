using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Conditions/Has No Attackers")]
public class HasNoAttackers : TemplateCondition 
{
	public override bool CheckCondition(TemplateControllerCustom _object)
	{
		return !CityMaster.instance.HasAttackers();
	}
}

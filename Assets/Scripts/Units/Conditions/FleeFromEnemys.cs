using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Conditions/Flee")]
public class FleeFromEnemys : TemplateCondition
{
	[SerializeField]
	LayerMask layerEnemys;

	[SerializeField]
	float radius;

	public override bool CheckCondition(TemplateControllerCustom _object)
	{
		if(Physics.CheckSphere(_object.transform.position, this.radius, this.layerEnemys))
		{
			return true;
		}

		return false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Conditions/No Enemys")]
public class NoEnemysAround : TemplateCondition
{
	[SerializeField]
	LayerMask layerEnemys;

	[SerializeField]
	float radius;

	[SerializeField]
	bool CheckHidden;

	public override bool CheckCondition(TemplateControllerCustom _object)
	{
		if(!Physics.CheckSphere(_object.transform.position, this.radius, this.layerEnemys))
		{
			TemplateUnits unit = _object as TemplateUnits;

			if(this.CheckHidden && unit.isHidden)
			{
				return false;
			}
			
			return true;
		}

		return false;
	}
}

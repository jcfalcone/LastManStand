using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Conditions/No Enemys with Timer")]
public class NoEnemysAroundWithTimer : TemplateCondition
{
	[SerializeField]
	LayerMask layerEnemys;

	[SerializeField]
	float radius;

	[SerializeField]
	float maxTimeWithoutEnemys;

	public override bool CheckCondition(TemplateControllerCustom _object)
	{
		TemplateUnits unit = _object as TemplateUnits;

		if(!Physics.CheckSphere(_object.transform.position, this.radius, this.layerEnemys))
		{
			if(Time.timeSinceLevelLoad - unit.TimeSinceLastEnemy < this.maxTimeWithoutEnemys)
			{
				return false;
			}

			return true;
		}

		unit.TimeSinceLastEnemy = Time.timeSinceLevelLoad;

		return false;
	}
}

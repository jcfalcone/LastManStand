using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Actions/Attack Enemys")]
public class AttackEnemys : TemplateAction 
{
	[SerializeField]
	float Threshold = 2;

	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		if(!(_controller is TemplateUnits))
		{
			return;
		}

		TemplateUnits unit = _controller as TemplateUnits;

		if(unit.targetEnemys.Count <= 0)
		{
			return;
		}

		if(unit.targetEnemys[0].obj == null)
		{
			unit.targetEnemys.RemoveAt(0);
			return;
		}


		if(unit.targetEnemys[0].type != TargetType.Construction)
		{
			if(unit.targetEnemy == null)
			{
				unit.targetEnemy = unit.targetEnemys[0].obj.GetComponent<TemplateUnits>();
				unit.agent.SetDestination(unit.targetEnemy.transform.position);
				return;
			}

			if(Vector3.Distance(unit.agent.destination, unit.targetEnemy.transform.position) > Threshold)
			{
				unit.agent.SetDestination(unit.targetEnemy.transform.position);
			}
			
			if(!unit.targetEnemy.isAlive)
			{
				unit.targetEnemy = null;
				unit.targetEnemys.RemoveAt(0);
			}
		}
		else
		{
			if(unit.targetBuild == null)
			{
				ConstructionData data = CityMaster.instance.FindBuildByGameObject(unit.targetEnemys[0].obj);

				unit.targetBuild = data.ID;
				unit.targetBuildData = data;

				unit.agent.SetDestination(unit.targetBuildData.obj.transform.position);
			}
			
			if(!CityMaster.instance.IsBuildAlive(unit.targetBuild))
			{
				unit.targetBuild = null;
				unit.targetBuildData = null;
				unit.targetEnemys.RemoveAt(0);
			}
		}
	}
}

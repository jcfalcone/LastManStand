using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Actions/Apply Damage")]
public class ApplyDamage : TemplateAction 
{

	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		TemplateUnits unit = _controller as TemplateUnits;
		

		if(Vector3.Distance(unit.transform.position, unit.agent.destination) > unit.attackDistance || (unit.targetEnemy == null && unit.targetBuild == null))
		{
			return;
		}

		if(unit.currAttackCoolDown <= 0)
		{
			if(unit.targetEnemy != null)
			{
				unit.targetEnemy.ApplyDamage(unit, unit.attackDamage);
				unit.anim.Play("Attack");
				unit.currAttackCoolDown = unit.attackCoolDown;
			}
			else if(unit.targetBuild != null)
			{
				CityMaster.instance.AttackBuild(unit.attackDamage, unit.targetBuild, unit);
				unit.currAttackCoolDown = unit.attackCoolDown;
			}
		}

		unit.currAttackCoolDown -= _delta;
	}
}

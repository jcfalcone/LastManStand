using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Actions/Attack Last Attacker")]
public class AttackLastAttacker : TemplateAction 
{
	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		TemplateUnits unit = _controller as TemplateUnits;

		if(unit.lastAttacker != null)
		{
			if(!unit.lastAttacker.isAlive)
			{
				unit.lastAttacker = null;
				return;
			}

			unit.targetEnemys.Clear();

			unit.targetEnemy = unit.lastAttacker;
			unit.AddTarget(TargetType.Attacker, unit.lastAttacker.gameObject);

			unit.agent.SetDestination(unit.lastAttacker.transform.position);
		}
	}
}

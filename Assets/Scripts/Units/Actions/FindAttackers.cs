using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Actions/Find Attackers")]
public class FindAttackers : TemplateAction 
{
	[SerializeField]
	float radius;

	[SerializeField]
	LayerMask mask;

	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		Guards unit = _controller as Guards;
		
		if(!CityMaster.instance.HasAttackers())
		{
			if(unit.targetEnemys.Count > 0)
			{
				return;	
			}

			Collider[] colliders = Physics.OverlapSphere(unit.transform.position, this.radius, this.mask);

			for(int count = 0; count < colliders.Length; count++)
			{
				unit.AddTarget(TargetType.Close, colliders[count].gameObject);
			}

			return;
		}

		if(unit.targetEnemys.Count > 0 && unit.targetEnemys[0].type != TargetType.Attacker)
		{
			unit.targetEnemys.Clear();
		}

		TemplateUnits enemy = CityMaster.instance.GetAttacker();

		if(enemy != null && !unit.HasTarget(TargetType.Attacker, enemy.gameObject))
		{
			unit.AddTarget(TargetType.Attacker, enemy.gameObject);
		}
	}
}

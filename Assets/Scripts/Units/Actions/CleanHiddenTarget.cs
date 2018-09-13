using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Actions/Clean Hidden Target")]
public class CleanHiddenTarget : TemplateAction 
{
	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		TemplateUnits unit = _controller as TemplateUnits;

		if(unit.targetEnemy != null)
		{
			if(unit.targetEnemy.isHidden)
			{
				unit.targetEnemy = null;
				unit.targetEnemys.RemoveAt(0);
			}
		}
	}
}

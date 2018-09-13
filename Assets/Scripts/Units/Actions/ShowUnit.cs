using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Actions/Show Unit")]
public class ShowUnit : TemplateAction 
{
	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		TemplateUnits unit = _controller as TemplateUnits;

		if(CityMaster.instance.RemoveFromBuild(unit.targetBuild, unit))
		{
			unit.isHidden = false;
			unit.gameObject.SetActive(true);
		}
	}
}

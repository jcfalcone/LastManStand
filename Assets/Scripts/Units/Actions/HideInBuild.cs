using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Actions/Hide In Build")]
public class HideInBuild : TemplateAction 
{

	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		TemplateUnits unit = _controller as TemplateUnits;

		if(CityMaster.instance.HideInBuild(unit.targetBuild, unit))
		{
			unit.isHidden = true;
			unit.gameObject.SetActive(false);
		}
	}
}

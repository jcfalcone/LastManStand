using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/UI/Add to UI")]
public class AddToUI : TemplateAction 
{
	[SerializeField]
	Color color;

	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		UIManager.instance.AddUnit(_controller as TemplateUnits, this.color);
	}
}

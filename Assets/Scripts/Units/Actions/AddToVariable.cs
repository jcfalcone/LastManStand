using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;
using Falcone.Variables;

[CreateAssetMenu(menuName="AI/Actions/Add to Variable")]
public class AddToVariable : TemplateAction 
{
	[SerializeField]
	IntScriptable variable;

	[SerializeField]
	int amount = 1;

	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		this.variable.value += this.amount;
	}
}

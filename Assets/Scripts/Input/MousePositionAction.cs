using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.Variables;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="Input/Mouse Position")]
public class MousePositionAction : TemplateAction 
{
	[SerializeField]
	Vector2Scriptable mousePosition;
	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		this.mousePosition.value = Input.mousePosition;
	}
}

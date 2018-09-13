using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.Variables;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="Input/Mouse Scroll")]
public class MouseScrollAction : TemplateAction
{
	[SerializeField]
	FloatScriptable mouseScroll;
	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		this.mouseScroll.value = Input.GetAxis("Mouse ScrollWheel");
	}
}

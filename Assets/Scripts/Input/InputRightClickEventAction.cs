using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.Variables;
using Falcone.Events;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="Input/Right Click Event")]
public class InputRightClickEventAction : TemplateAction
{
	[SerializeField]
	GameEvent rightclickDownEvent;

	[SerializeField]
	GameEvent rightclickUpEvent;

	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		if(Input.GetButtonDown("Fire2"))
		{
			this.rightclickDownEvent.Raise();
		}
		else if(Input.GetButtonUp("Fire2"))
		{
			this.rightclickUpEvent.Raise();
		}
	}
}

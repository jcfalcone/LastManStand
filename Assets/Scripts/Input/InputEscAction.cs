using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.Variables;
using Falcone.Events;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="Input/Esc Event")]
public class InputEscAction : TemplateAction
{
	[SerializeField]
	GameEvent escEvent;

	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		if(Input.GetKey(KeyCode.Escape))
		{
			this.escEvent.Raise();
		}
	}
}

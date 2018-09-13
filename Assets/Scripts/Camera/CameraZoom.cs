using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;
using Falcone.Variables;

[CreateAssetMenu(menuName="Camera/Zoom")]
public class CameraZoom : TemplateAction
{
	[SerializeField]
	float speed = 9f;

	[SerializeField]
	float minY;

	[SerializeField]
	float maxY;

	[SerializeField]
	FloatScriptable mouseScroll;

	[SerializeField]
	TransformScriptable cameraHolder;

	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		if(this.mouseScroll.value != 0)
		{
			Vector3 cameraPos = this.cameraHolder.value.position;

			cameraPos.y = Mathf.Lerp(cameraPos.y, cameraPos.y + this.mouseScroll.value * this.speed, this.speed *  _delta);
			Debug.Log(cameraPos.y);

			cameraPos.y = Mathf.Clamp(cameraPos.y, this.minY, this.maxY);

			this.cameraHolder.value.position = cameraPos;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;
using Falcone.Variables;

[CreateAssetMenu(menuName="Camera/Movement")]
public class CameraMove : TemplateAction
{
	[SerializeField]
	float threshold = 100;

	[SerializeField]
	float speed = 9f;

	[SerializeField]
	float minSpeed = 9f;

	[SerializeField]
	float maxSpeed = 9f;

	[SerializeField]
	Vector3 minPosition;

	[SerializeField]
	Vector3 maxPosition;


	[SerializeField]
	Vector2Scriptable mousePosition;

	[SerializeField]
	TransformScriptable cameraHolder;

	Vector3 vectorZero = Vector3.zero;
	Vector3 vectorForward = Vector3.forward;
	Vector3 vectorRight = Vector3.right;

	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		Vector3 totalMovement = this.vectorZero;

		if(this.mousePosition.value.x < this.threshold && this.cameraHolder.value.position.x > this.minPosition.x)
		{
			totalMovement += -this.vectorRight * Mathf.Clamp(this.speed * Mathf.Abs(1 - (this.mousePosition.value.x / this.threshold)), this.minSpeed, this.maxSpeed);
		}
		else if(this.mousePosition.value.x > Screen.width - this.threshold && this.cameraHolder.value.position.x < this.maxPosition.x)
		{
			float posMouse = Mathf.Abs(this.mousePosition.value.x - (Screen.width - this.threshold));
			totalMovement += this.vectorRight * Mathf.Clamp(this.speed * (posMouse / this.threshold), this.minSpeed, this.maxSpeed);
		}

		if(this.mousePosition.value.y < this.threshold && this.cameraHolder.value.position.z > this.minPosition.z)
		{
			totalMovement += -this.vectorForward * Mathf.Clamp(this.speed * Mathf.Abs(1 - (this.mousePosition.value.y / this.threshold)), this.minSpeed, this.maxSpeed);
		}
		else if(this.mousePosition.value.y > Screen.height - this.threshold && this.cameraHolder.value.position.z < this.maxPosition.z)
		{
			float posMouse = Mathf.Abs(this.mousePosition.value.y - (Screen.height - this.threshold));
			totalMovement += this.vectorForward * Mathf.Clamp((this.speed * (posMouse / this.threshold)), this.minSpeed, this.maxSpeed);
		}

		if(totalMovement != this.vectorZero)
		{
			this.cameraHolder.value.position += totalMovement * _delta;
		}
	}
}

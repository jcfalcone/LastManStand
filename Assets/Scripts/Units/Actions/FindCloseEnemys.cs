using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.BehaviourEditor;

[CreateAssetMenu(menuName="AI/Actions/Find Close Enemys")]
public class FindCloseEnemys : TemplateAction
{
	[SerializeField]
	float radius;

	[SerializeField]
	LayerMask mask;

	[SerializeField]
	TargetType type = TargetType.Close;


	public override void Execute(TemplateControllerCustom _controller, float _delta = 0)
	{
		if(!(_controller is TemplateUnits))
		{
			return;
		}

		TemplateUnits units = _controller as TemplateUnits;

		units.targetEnemys.Clear();

		Collider[] colliders = Physics.OverlapSphere(units.transform.position, this.radius, this.mask);

		for(int count = 0; count < colliders.Length; count++)
		{
			if(!colliders[count].gameObject.activeSelf)
			{
				continue;
			}

			units.AddTarget(this.type, colliders[count].gameObject);
		}
	}
}

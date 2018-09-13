using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIElement : MonoBehaviour {

	public abstract void Tick(float _deltaTime);

	public virtual bool HasToDestroy()
	{
		return false;
	}
}

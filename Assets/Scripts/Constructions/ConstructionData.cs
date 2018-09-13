using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConstructionData
{
	public string ID;
	public bool allowUnits;
	[HideInInspector]
	public int currUnits;
	public int totalUnits;

	public GameObject obj;

	public Material material;

	public List<TemplateUnits> unitsInside;

	public int currHealth;
	public int totalHealth;

	public HealthBarLocal healthBar;

	public GameObject uiMapElement;

	public void Init()
	{
		this.currUnits = 0;
		this.currHealth = this.totalHealth;
		
		Renderer[] render = this.obj.GetComponentsInChildren<Renderer>();

		this.material = new Material(render[0].material);

		for(int count = 0; count < render.Length; count++)
		{
			render[count].material = this.material;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.Variables;


public class CityMaster : Singleton<CityMaster> 
{
	[SerializeField]
	Color FullHealth;

	[SerializeField]
	Color EndHealth;

	[SerializeField]
	List<ConstructionData> data;

	Dictionary<int, int> attackedDic;

	List<List<TemplateUnits>> attackedList;

	// Use this for initialization
	void Awake () 
	{
		instance = this;	
	}

	void Start()
	{
		for(int count = 0; count < this.data.Count; count++)
		{
			this.data[count].Init();
			this.data[count].currHealth = this.data[count].totalHealth;
		}

		this.attackedList = new List<List<TemplateUnits>>();
		this.attackedDic = new Dictionary<int, int>();

		for(int count = 0; count < this.data.Count; count++)
		{
			this.data[count].uiMapElement = UIManager.instance.AddConstruction(this.data[count].obj.transform, Color.white);
		}
	}

	void Update()
	{

		for(int count = 0; count < this.data.Count; count++)
		{
			this.data[count].material.color = Color.Lerp(this.EndHealth, this.FullHealth, (float)this.data[count].currHealth / (float)this.data[count].totalHealth);
		}
	}
	
	public ConstructionData FindBuild(string _ID)
	{
		return this.data.Find(x => x.ID == _ID);
	}
	
	public ConstructionData FindBuildByGameObject(GameObject _gameObject)
	{
		return this.data.Find(x => x.obj == _gameObject);
	}

	public ConstructionData GetClosestBuild(Vector3 _position)
	{
		ConstructionData closest = null;
		float closestDist = -1;

		for(int count = 0; count < this.data.Count; count++)
		{
			float thisDist = Vector3.Distance(this.data[count].obj.transform.position, _position);

			if((thisDist < closestDist || closestDist == -1) && this.data[count].currHealth > 0)
			{
				closestDist = thisDist;
				closest = this.data[count];
			}
		}

		return closest;
	}

	public bool HideInBuild(string _ID, TemplateUnits _unit)
	{
		ConstructionData data = this.FindBuild(_ID);
		
		if(data.currUnits < data.totalUnits)
		{
			data.unitsInside.Add(_unit);
			return true;
		}

		return false;
	}

	public bool RemoveFromBuild(string _ID, TemplateUnits _unit)
	{
		ConstructionData data = this.FindBuild(_ID);
		
		if(data.unitsInside.Contains(_unit))
		{
			data.unitsInside.Remove(_unit);
			return true;
		}

		return false;
	}

	public bool HasFreeSlot(string _ID)
	{
		ConstructionData data = this.FindBuild(_ID);
		
		if(data.unitsInside.Count < data.totalUnits)
		{
			return true;
		}

		return false;
	}

	public void AttackedObj(string _ID, TemplateUnits _unit)
	{
		int index = -1;
		int IDHash = _ID.GetHashCode();

		if(!this.attackedDic.ContainsKey(IDHash))
		{
			this.attackedList.Add(new List<TemplateUnits>());
			index = this.attackedList.Count - 1;
			this.attackedDic[IDHash] = index;
		}
		else
		{
			index = this.attackedDic[IDHash];
		}

		if(this.attackedList.Count > index)
		{
			this.attackedList[index].Add(_unit);
		}
	}

	public void ClearAttacked(string _ID)
	{
		int IDHash = _ID.GetHashCode();

		if(!this.attackedDic.ContainsKey(IDHash))
		{
			return;
		}
		
		int index = this.attackedDic[IDHash];

		this.attackedList[index].Clear();
		this.attackedList.RemoveAt(index);
		this.attackedDic.Remove(IDHash);
	}

	public TemplateUnits GetAttacker()
	{ 

		for(int countL = 0; countL < this.attackedList.Count; countL++)
		{
			for(int count = 0; count < this.attackedList[countL].Count; count++)
			{
				if(this.attackedList[countL][count] != null && this.attackedList[countL][count].isAlive)
				{
					return this.attackedList[countL][count];
				}
			}
		}

		return null;
	}

	public bool HasAttackers()
	{
		for(int countL = this.attackedList.Count - 1; countL > -1; countL--)
		{
			for(var count = this.attackedList[countL].Count - 1; count > -1; count--)
			{
				if (this.attackedList[countL][count] == null)
				{
					this.attackedList[countL].RemoveAt(count);
				}
			}

			if(this.attackedList[countL].Count <= 0)
			{
				this.attackedList.RemoveAt(countL);
			}
		}

		return this.attackedList.Count > 0;
	}

	public bool IsBuildAlive(string _ID)
	{
		ConstructionData data = this.FindBuild(_ID);

		return data.currHealth > 0;
	}

	public void AttackBuild(int _damage, string _ID, TemplateUnits _attacker)
	{
		ConstructionData data = this.FindBuild(_ID);

		data.currHealth -= _damage;

		if(data.currHealth <= 0)
		{
			this.DestroyBuild(data);
			data.currHealth = 0;
		}

		data.healthBar.SetHealthBar((float)data.currHealth / (float)data.totalHealth);

		this.AttackedObj(_ID, _attacker);
	}

	public void DestroyBuild(ConstructionData _data)
	{
		for(int count = 0; count < _data.unitsInside.Count; count++)
		{
			this.RemoveFromBuild(_data.ID, _data.unitsInside[count]);
		}

		_data.uiMapElement.SetActive(false);
		_data.obj.SetActive(false);
	}
}

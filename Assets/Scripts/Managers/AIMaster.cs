using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Falcone.Variables;
using Falcone.Events;
using Falcone.BehaviourEditor;

public class AIMaster : MonoBehaviour 
{
	[System.Serializable]
	public struct PrefabData
	{
		public string Name;
		
		public GameObject prefab;

		public float radio;

		public int startUnits;

		public IntScriptable currUnits;
		public IntScriptable totalUnits;
		
		public IntScriptable alive;
		
		public IntScriptable inHouse;
		
		public IntScriptable dead;

		public GameEvent uiEvent;

		public List<Transform> SpawnPosition;

		public void Init()
		{
			this.currUnits.value = this.startUnits;
			this.alive.value = 0;
			this.inHouse.value = 0;
			this.dead.value = 0;
			this.uiEvent.Raise();
		}
		
		public bool HasUnits()
		{
			return this.currUnits.value > 0;
		}

		public Vector3 RandomSpawn()
		{
			Transform spawn = this.SpawnPosition[Random.Range(0, 1000) % this.SpawnPosition.Count];
			Vector3 position = spawn.position;

			position.x += Random.Range(-radio, radio);
			position.z += Random.Range(-radio, radio);

			return position;
		}
	}

	[SerializeField]
	ToolTip toolTip;

	[SerializeField]
	List<PrefabData> prefabs;

	[SerializeField]
	List<TemplateUnits> units;

	// Use this for initialization
	void Start () 
	{
		for(int count = 0; count < this.prefabs.Count; count++)
		{
			this.prefabs[count].Init();
		}

		for(int count = 0; count < this.units.Count; count++)
		{
			this.units[count].Init();
		}

		for(int count = 0; count < 4; count++)
		{
			this.CreateUnit(1, false);
		}

		for(int count = 0; count < 2; count++)
		{
			this.CreateUnit(2, false);
		}
		

		for(int count = 0; count < 20; count++)
		{
			this.CreateUnit(4, false);
		}
		

		for(int count = 0; count < 2; count++)
		{
			this.CreateUnit(3, false);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

		for(int count = 0; count < this.units.Count; count++)
		{
			if(this.units[count] == null)
			{
				continue;
			}

			this.units[count].Tick();
		}	
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		for(int count = 0; count < this.units.Count; count++)
		{
			if(this.units[count] == null)
			{
				continue;
			}

			this.units[count].LateTick();
		}	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		for(int count = 0; count < this.units.Count; count++)
		{
			if(this.units[count] == null)
			{
				continue;
			}
			
			this.units[count].FixedTick();
		}	
	}

	public void CreateUnit(int _index)
	{
		this.CreateUnit(_index, true);
	}

	public void CreateUnit(int _index, bool _checkSize = true)
	{
		if(_checkSize && !this.prefabs[_index].HasUnits())
		{
			return;
		}

		Vector3 spawn = this.prefabs[_index].RandomSpawn();

		GameObject obj = Instantiate(this.prefabs[_index].prefab, spawn, Quaternion.identity);

		TemplateUnits unit = obj.GetComponent<TemplateUnits>();
		unit.Init();

		this.units.Add(unit);

		this.UpdateToolTip(_index);

		if(_checkSize)
		{
			this.prefabs[_index].currUnits.value--;
		}

		this.prefabs[_index].uiEvent.Raise();
	}

	public void UpdateToolTip(int _index)
	{
		this.toolTip.UpdateToolTip(this.prefabs[_index].Name, 
								   this.prefabs[_index].alive.value,
								   this.prefabs[_index].inHouse.value,
								   this.prefabs[_index].dead.value);
	}
}

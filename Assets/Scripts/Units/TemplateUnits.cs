using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Falcone.BehaviourEditor;
public enum TargetType
{
	Close,
	Attacker,
	Construction
}

[System.Serializable]
public class TargetData
{
	public GameObject obj;
	public TargetType type;
}

public class TemplateUnits : TemplateControllerCustom 
{
	[SerializeField]
	public NavMeshAgent agent;

	[SerializeField]
	public Vector3 targetPosition;

	[SerializeField]
	public string targetBuild;

	[HideInInspector]
	public ConstructionData targetBuildData;

	[SerializeField]
	public float TimeSinceLastEnemy;

	[HideInInspector]
	public bool isHidden;

	[SerializeField]
	public float attackCoolDown;
	
	[HideInInspector]
	public float currAttackCoolDown;

	[SerializeField]
	public int attackDamage;

	[SerializeField]
	public float attackDistance;

	[HideInInspector]
	public TemplateUnits targetEnemy;

	[SerializeField]
	public float totalHealth;

	[SerializeField]
	public Vector3 offsetUI;

	public float currHealth;

	public TemplateUnits lastAttacker;

	[SerializeField]
	public List<TargetData> targetEnemys;

	public bool isAlive
	{
		get
		{
			return currHealth > 0;
		}
	}

	public float HealthRatio
	{
		get
		{
			return this.currHealth / this.totalHealth;
		}
	}

	public override void Init()
	{
		base.Init();
		this.currHealth = this.totalHealth;
	}

	public virtual void ApplyDamage(TemplateUnits _attacker, float _damage)
	{
		this.lastAttacker = _attacker;
		
		this.currHealth -= _damage;

		if(!this.isAlive)
		{
			this.Die();
		}
	}

	public virtual void Die()
	{
		//Destroy(gameObject);
	}

	public void AddTarget(TargetType _type, GameObject _obj)
	{
		TargetData newData = new TargetData
		{
			obj = _obj,
			type = _type
		};

		this.targetEnemys.Add(newData);
	}

	public bool HasTarget(TargetType _type, GameObject _obj)
	{
		return this.targetEnemys.Find(x => x.obj == _obj && x.type == _type) != null;
	}
}

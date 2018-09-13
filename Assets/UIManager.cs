using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MiniMapData
{
	public Transform unit;
	public RectTransform uiRect;
}

public class UIManager : Singleton<UIManager> 
{

	[SerializeField]
	GameObject healthBarPrefab;

	[SerializeField]
	GameObject uiMapPrefab;

	[SerializeField]
	GameObject uiBuildPrefab;

	[SerializeField]
	GameObject uiCameraPrefab;

	[SerializeField]
	Transform uiMapHolder;
	
	[SerializeField]
	Vector2 miniMapTranslator;
	
	[SerializeField]
	Vector2 maxMapTranslator;
	
	[SerializeField]
	Vector2 minMiniMap;
	
	[SerializeField]
	Vector2 maxMiniMap;
	
	[SerializeField]
	List<UIElement> elements;

	[SerializeField]
	List<MiniMapData> minimapData;

	// Use this for initialization
	void Awake () {
		instance = this;
	}

	void Start()
	{
		GameObject uiUnit = Instantiate(this.uiCameraPrefab, this.uiMapHolder);

		Image image = uiUnit.GetComponent<Image>();

		MiniMapData data = new MiniMapData
		{
			unit = Camera.main.transform,
			uiRect = uiUnit.GetComponent<RectTransform>()
		};

		data.uiRect.anchoredPosition = this.RemapVector(Camera.main.transform.position);

		this.minimapData.Add(data);
	}
	
	// Update is called once per frame
	void Update () 
	{
		float delta = Time.deltaTime;

		for(int count = this.elements.Count - 1; count >= 0; count--)
		{
			if(this.elements[count].HasToDestroy())
			{
				Destroy(this.elements[count].gameObject);
				this.elements.RemoveAt(count);
			}

			if(this.elements[count] != null)
			{
				this.elements[count].Tick(delta);
			}
		}

		this.UpdateMiniMap();
	}

	public void AddUnit(TemplateUnits _unit, Color _color, Vector3 _offset)
	{
		GameObject uiUnit = Instantiate(this.uiMapPrefab, this.uiMapHolder);
		GameObject healthBar = Instantiate(this.healthBarPrefab);
		healthBar.transform.SetParent(transform, false);

		Image image = uiUnit.GetComponent<Image>();
		image.color = _color;

		MiniMapData data = new MiniMapData
		{
			unit = _unit.transform,
			uiRect = uiUnit.GetComponent<RectTransform>()
		};

		this.minimapData.Add(data);

		HealthBarLocal healthBarController = healthBar.GetComponent<HealthBarLocal>();

		healthBarController.SetTarget(_unit, _offset);
		
		healthBar.SetActive(false);

		this.elements.Add(healthBarController);
	}

	public GameObject AddConstruction(Transform _build, Color _color)
	{
		GameObject uiUnit = Instantiate(this.uiBuildPrefab, this.uiMapHolder);

		Image image = uiUnit.GetComponent<Image>();
		image.color = _color;

		MiniMapData data = new MiniMapData
		{
			unit = _build,
			uiRect = uiUnit.GetComponent<RectTransform>()
		};

		this.minimapData.Add(data);

		data.uiRect.anchoredPosition = this.RemapVector(data.unit.transform.position);

		return uiUnit;
	}

	void UpdateMiniMap()
	{
		for(int count = this.minimapData.Count - 1; count >= 0; count--)
		{
			if(this.minimapData[count].unit == null)
			{
				Destroy(this.minimapData[count].uiRect.gameObject);
				this.minimapData.RemoveAt(count);
			}
		}

		for(int count = 0; count < this.minimapData.Count; count++)
		{
			this.minimapData[count].uiRect.anchoredPosition = this.RemapVector(this.minimapData[count].unit.transform.position);
		}
	}

	public Vector3 RemapVector(Vector3 _position)
	{
		_position.x = this.Remap(_position.x, this.miniMapTranslator.x, this.maxMapTranslator.x, this.minMiniMap.x, this.maxMiniMap.x);
		_position.z = this.Remap(_position.z, this.miniMapTranslator.y, this.maxMapTranslator.y, this.minMiniMap.y, this.maxMiniMap.y);

		_position.y = _position.z;

		return _position;
	}

	public float Remap (float value, float from1, float to1, float from2, float to2) 
	{
    	return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}

	public void ShowHealthBar()
	{
		for(int count = 0; count < this.elements.Count; count++)
		{
			if(this.elements[count] is HealthBarLocal)
			{
				this.elements[count].gameObject.SetActive(true);
			}
		}
	}

	public void HideHealthBar()
	{
		for(int count = 0; count < this.elements.Count; count++)
		{
			if(this.elements[count] is HealthBarLocal)
			{
				this.elements[count].gameObject.SetActive(false);
			}
		}
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void UnPauseGame()
	{
		Time.timeScale = 1;
	}
}

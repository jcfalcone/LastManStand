using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneGameManager : MonoBehaviour 
{
	[SerializeField]
	Image overlay;

	bool startLoad;

	AsyncOperation operation;

	// Update is called once per frame
	void Update () 
	{

		if(this.startLoad)
		{
			Color color = this.overlay.color;
			color.a += Time.unscaledDeltaTime;
			this.overlay.color = color;

			if(color.a >= 1)
			{
				FinishLevel();
			}
		}
	}

	public void StartLoading()
	{
		this.startLoad = true;
		StartCoroutine(LoadLevel());
	}

	IEnumerator LoadLevel()
	{
		this.operation = SceneManager.LoadSceneAsync("MainMenu");
		this.operation.allowSceneActivation = false;

		while(!this.operation.isDone && this.operation.progress <= 0.8)
		{
			yield return null;
		}
	}

	void FinishLevel()
	{
		Time.timeScale = 1;
		this.operation.allowSceneActivation = true;
	}
}

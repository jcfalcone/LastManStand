using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour 
{
	[SerializeField]
	Image overlay;

	bool startLoad;

	AsyncOperation operation;

	// Update is called once per frame
	void Update () 
	{
		if(Input.anyKeyDown)
		{
			this.startLoad = true;
			StartCoroutine(LoadLevel());
		}

		if(this.startLoad)
		{
			Color color = this.overlay.color;
			color.a += Time.deltaTime;
			this.overlay.color = color;

			if(color.a >= 1)
			{
				FinishLevel();
			}
		}
	}

	IEnumerator LoadLevel()
	{
		this.operation = SceneManager.LoadSceneAsync("Level1");
		this.operation.allowSceneActivation = false;

		while(!this.operation.isDone && this.operation.progress <= 0.8)
		{
			yield return null;
		}
	}

	void FinishLevel()
	{
		this.operation.allowSceneActivation = true;
	}
}

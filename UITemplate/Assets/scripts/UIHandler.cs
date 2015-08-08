using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIHandler : MonoBehaviour {

	public static UIHandler UI;

	public Menu[] menus = new Menu[10];
	public bool pause = false;
	
	// Use this for initialization
	void Start () 
	{
		menus = this.gameObject.GetComponentsInChildren<Menu>();
	}

	void Awake() //Ensures only 1 instance of UI exists at any given time. 
	{
		if(UI == null)
		{
			DontDestroyOnLoad(gameObject);
			UI = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update () 
	{
//		foreach (Menu M in menus)
//		{
//			Debug.Log(M.name);
//		}
		if (Input.GetKeyUp(KeyCode.Escape) && Application.loadedLevel != 0)
		{
			pause = !pause;
			pauseMenu(pause);
		}
	}
	

	public void openMenu(string Menu) //Displays all of the Canvas' associated with the nextMenu tag
	{
		foreach (Menu M in menus)
		{
			if (M.name == Menu)
			{
				M.gameObject.GetComponent<Canvas>().enabled = true;
				M.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
				M.gameObject.GetComponent<CanvasGroup>().interactable = true;
			}
		}
	}
	
	public void closeMenu(string Menu)//hides all canvas' with the menu tag. 
	{
		foreach (Menu M in menus)
		{
			if (M.name == Menu)
			{
				M.gameObject.GetComponent<Canvas>().enabled = false;
				M.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
				M.gameObject.GetComponent<CanvasGroup>().interactable = false;
			}
		}
	}

	public void changeSceneString(string scene)
	{
		Application.LoadLevel(scene);
	}

	public void changeSceneIndex(int scene)
	{
		Application.LoadLevel(scene);
	}

	public void pauseMenu(bool pause)
	{
		if (pause)
		{
			Time.timeScale = 0.0f;
			openMenu("pause");
		}
		if (!pause)
		{
			Time.timeScale = 1.0f;
			closeMenu("pause");
		}
	}
}

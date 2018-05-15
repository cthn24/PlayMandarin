using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public Menu currentMenu;

	public void Start()
	{
		ShowMenu (currentMenu);
	}

	public void ShowMenu (Menu menu)
	{
		if (currentMenu != null) 
		{
			currentMenu.IsOpen = false;
		}

		currentMenu = menu;
		currentMenu.IsOpen = true;
		}


    /*
	public void StartHome()
	{
		SceneManager.LoadScene("Home");
	}

	public void StartLevel()
	{
		SceneManager.LoadScene("SelectLevel");
	}

	public void StartLevel1E1()
	{
		SceneManager.LoadScene("Level1E1");
	}


	public void StartLevel1E2()
	{
		SceneManager.LoadScene ("Level1E2");
	}

	public void StartLevel2E1()
	{
		SceneManager.LoadScene ("Level2E1");
	}

	public void StartLevel2E2()
	{
		SceneManager.LoadScene ("Level2E2");
	}


	public void StartLevel1()
	{
		SceneManager.LoadScene ("Level1");
	}

	public void StartLevel2()
	{
		SceneManager.LoadScene ("Level2");
	}

	public void StartLevel3()
	{
		SceneManager.LoadScene ("Level3");
	}
     * 
     * */
}

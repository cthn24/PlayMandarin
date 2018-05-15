using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour {

    public CanvasGroup uiCG;
    public CanvasGroup confirmQuitCG;

    private void Awake()
    {
        backToGame();//disable to confirmation quit panel
    }

    public void backToGame()
    {
        Debug.Log("Back to Game");


        //back to ui
        uiCG.alpha = 1;
        uiCG.interactable = true;
        uiCG.blocksRaycasts = true;


        //disable quit
        confirmQuitCG.alpha = 0;
        confirmQuitCG.interactable = false;
        confirmQuitCG.blocksRaycasts = false;
    }


	public void doquit()
	{
		Debug.Log ("Has Quit Game");
		Application.Quit ();
	}


    public void clickQuitButton()
    {
        Debug.Log("Click QUit Button");

        //reduce the visibility of normal ui, and disable all interaction
        uiCG.alpha = 0.5f;
        uiCG.interactable = false;
        uiCG.blocksRaycasts = false;


        //enable interaction with yes and no (quit game)
        confirmQuitCG.alpha = 1;
        confirmQuitCG.interactable = true;
        confirmQuitCG.blocksRaycasts = true;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    public CanvasGroup uiCG;
    // public CanvasGroup uiCG1;
    public CanvasGroup confirmReset;
    //public CanvasGroup confirmReset;

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
        confirmReset.alpha = 0;
        confirmReset.interactable = false;
        confirmReset.blocksRaycasts = false;
    }


    public void clickResetButton()
    {
        Debug.Log("Click QUit Button");

        //reduce the visibility of normal ui, and disable all interaction
        uiCG.alpha = 0.5f;
        uiCG.interactable = false;
        uiCG.blocksRaycasts = false;
        //enable interaction with yes and no (quit game)
        confirmReset.alpha = 1;
        confirmReset.interactable = true;
        confirmReset.blocksRaycasts = true;
    }
    /*
    public void clickResetButton()
    {
        Debug.Log("Click Reset Button");

        //reduce the visibility of normal ui, and disable all interaction
        uiCG1.alpha = 0.5f;
        uiCG1.interactable = false;
        uiCG1.blocksRaycasts = false;
        //enable interaction with yes and no (quit game)
        confirmReset.alpha = 1;
        confirmReset.interactable = true;
        confirmReset.blocksRaycasts = true;
    }

    public void backToGame2()
    {
        Debug.Log("Back to Game");
        //back to ui
        uiCG1.alpha = 1;
        uiCG1.interactable = true;
        uiCG1.blocksRaycasts = true;


        //disable quit
        confirmOK.alpha = 0;
        confirmOK.interactable = false;
        confirmOK.blocksRaycasts = false;
    }
    */

    public void resetAll()
    {
        PlayerPrefs.DeleteAll();
        backToGame();
    }
     
}

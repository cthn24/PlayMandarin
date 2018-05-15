using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelInstruction : MonoBehaviour
{
    public CanvasGroup uiCG;
    public CanvasGroup confirmOK;
 
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
        confirmOK.alpha = 0;
        confirmOK.interactable = false;
        confirmOK.blocksRaycasts = false;
    }


    public void clickLockButton()
    {
        Debug.Log("Click Lock Button");

        //reduce the visibility of normal ui, and disable all interaction
        uiCG.alpha = 0.5f;
        uiCG.interactable = false;
        uiCG.blocksRaycasts = false;
        //enable interaction with yes and no 
        confirmOK.alpha = 1;
        confirmOK.interactable = true;
        confirmOK.blocksRaycasts = true;
    }
   
}

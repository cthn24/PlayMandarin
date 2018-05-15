using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changeScene : MonoBehaviour {

    
    public void StartHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("SelectLevel");  
    }


    public void StartLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

 
    public void StartLevel1E1()
    {
        SceneManager.LoadScene("Level1E1");
    }


    public void StartLevel1E2()
    {
        SceneManager.LoadScene("Level1E2");
    }


    public void StartLevel1E3()
    {
        SceneManager.LoadScene("Level1E3");
    }


    public void StartLevel2()
    {
        SceneManager.LoadScene("Level2");
    }


    public void StartLevel2E1()
    {
        SceneManager.LoadScene("Level2E1");
    }

    public void StartLevel2E2()
    {
        SceneManager.LoadScene("Level2E2");
    }


    public void StartLevel2E3()
    {
        SceneManager.LoadScene("Level2E3");
       // StartCoroutine(Fading());
    }


    public void StartLevel3()
    {
        SceneManager.LoadScene("Level3");
    }


    public void StartLevel3E1()
    {
        SceneManager.LoadScene("Level3E1");
    }

    public void StartLevel3E2()
    {
        SceneManager.LoadScene("Level3E2");
    }


    public void StartLevel3E3()
    {
        SceneManager.LoadScene("Level3E3");
    }

    public void resetLevel()
    {
        PlayerPrefs.DeleteAll();
    }

    public void CheckAnswer1()
    {
        SceneManager.LoadScene("CheckAnswer1");
    }

    public void CheckAnswer2()
    {
        SceneManager.LoadScene("CheckAnswer2");
    }

    public void CheckAnswer3()
    {
        SceneManager.LoadScene("CheckAnswer3");
    }

    public void CheckAnswer4()
    {
        SceneManager.LoadScene("CheckAnswer4");
    }

    public void CheckAnswer5()
    {
        SceneManager.LoadScene("CheckAnswer5");
    }

    public void CheckAnswer6()
    {
        SceneManager.LoadScene("CheckAnswer6");
    }

    public void check()
    {
        SceneManager.LoadScene("New Scene");
    }

}

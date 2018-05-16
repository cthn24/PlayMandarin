using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelLock : MonoBehaviour
{
    private int final1Score;
    private int final2Score;
    private int finallevel1e3;

    private int final3Score;
    private int final4Score;
    private int finallevel2e3;

    private int finallevel3e1;
    private int finallevel3E1;
    private int finallevel3e3;

    private int overallLevel1Score;
    private int overallLevel2Score;

    public GameObject level1Unlock;
    public GameObject level2Unlock;
    public GameObject level3Unlock;

    // Use this for initialization
    void Start()
    {
       // PlayerPrefs.DeleteAll();

        final1Score = PlayerPrefs.GetInt("highScore");
        final2Score = PlayerPrefs.GetInt("highScore2");
        finallevel1e3 = PlayerPrefs.GetInt("memory1");

        final3Score = PlayerPrefs.GetInt("highScore3");
        final4Score = PlayerPrefs.GetInt("highScore4");
        finallevel2e3 = PlayerPrefs.GetInt("memory2");

        finallevel3e1 = PlayerPrefs.GetInt("Drag1");
        finallevel3E1 = PlayerPrefs.GetInt("Drag2");
        finallevel3e3 = PlayerPrefs.GetInt("memory3");
    }

    // Update is called once per frame
    void Update()
    {

        final1Score = PlayerPrefs.GetInt("highScore");
        final2Score = PlayerPrefs.GetInt("highScore2");
        finallevel1e3 = PlayerPrefs.GetInt("memory1");

        final3Score = PlayerPrefs.GetInt("highScore3");
        final4Score = PlayerPrefs.GetInt("highScore4");
        finallevel2e3 = PlayerPrefs.GetInt("memory2");

        finallevel3e1 = PlayerPrefs.GetInt("Drag1");
        finallevel3E1 = PlayerPrefs.GetInt("Drag2");
        finallevel3e3 = PlayerPrefs.GetInt("memory3");

        overallLevel1Score = final1Score + final2Score + finallevel1e3;
        overallLevel2Score = final3Score + final4Score + finallevel2e3;

        if(overallLevel1Score >39)
        {
            level1Unlock.SetActive(false);
            level2Unlock.SetActive(true);
            level3Unlock.SetActive(false);

            if (overallLevel2Score > 39)
            {
                level1Unlock.SetActive(false);
                level2Unlock.SetActive(false);
                level3Unlock.SetActive(true);
            }
            else
            {
                level1Unlock.SetActive(false);
                level2Unlock.SetActive(true);
                level3Unlock.SetActive(false);
            }
        }
        else
        {
            level1Unlock.SetActive(true);
            level2Unlock.SetActive(false);
            level3Unlock.SetActive(false);
        }
    }
}
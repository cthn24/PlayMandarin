using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreBoard : MonoBehaviour {

    public Text scoreL1E1;
    public Text scoreL1E2;
    public Text scoreL1E3;
   
    public Text scoreL2E1;
    public Text scoreL2E2;
    public Text scoreL2E3;
    
    public Text scoreL3E1;
    public Text scoreL3E2;
    public Text scoreL3E3;

    private int sL1E1;
    private int sL1E2;
    private int sL1E3;
    
    private int sL2E1;
    private int sL2E2;
    private int sL2E3;
    
    private int sL3E1;
    private int sL3E2;
    private int sL3E3;


	// Use this for initialization
	void Start () {

        scoreL1E1.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        scoreL1E2.text = PlayerPrefs.GetInt("highScore2", 0).ToString();
        scoreL1E3.text = PlayerPrefs.GetInt("memory1", 0).ToString();

        scoreL2E1.text = PlayerPrefs.GetInt("highScore3", 0).ToString();
        scoreL2E2.text = PlayerPrefs.GetInt("highScore4", 0).ToString();
        scoreL2E3.text = PlayerPrefs.GetInt("memory2", 0).ToString();

        scoreL3E1.text = PlayerPrefs.GetInt("Drag1", 0).ToString();
        scoreL3E2.text = PlayerPrefs.GetInt("Drag2", 0).ToString();
        scoreL3E3.text = PlayerPrefs.GetInt("memory3", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {

        scoreL1E1.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        scoreL1E2.text = PlayerPrefs.GetInt("highScore2", 0).ToString();
        scoreL1E3.text = PlayerPrefs.GetInt("memory1", 0).ToString();

        scoreL2E1.text = PlayerPrefs.GetInt("highScore3", 0).ToString();
        scoreL2E2.text = PlayerPrefs.GetInt("highScore4", 0).ToString();
        scoreL2E3.text = PlayerPrefs.GetInt("memory2", 0).ToString();

        scoreL3E1.text = PlayerPrefs.GetInt("Drag1", 0).ToString();
        scoreL3E2.text = PlayerPrefs.GetInt("Drag2", 0).ToString();
        scoreL3E3.text = PlayerPrefs.GetInt("memory3", 0).ToString();
	
		
	}
}

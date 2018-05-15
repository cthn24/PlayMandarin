using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class DataController2 : MonoBehaviour {

	public RoundData2[] allRData;


	// Use this for initialization
	void Start () {


		DontDestroyOnLoad (gameObject);//when we load new scene, it won't destroy

		//SceneManager.LoadScene("Level1");

	}

	public RoundData2 GetCurrentRData()
	{
		return allRData [0];
	}

	// Update is called once per frame
	void Update () {

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class DataController4 : MonoBehaviour {

	public RoundData4[] allRData;


	// Use this for initialization
	void Start () {


		DontDestroyOnLoad (gameObject);//when we load new scene, it won't destroy

		//SceneManager.LoadScene("Level1");

	}

	public RoundData4 GetCurrentRData()
	{
		return allRData [0];
	}

	// Update is called once per frame
	void Update () {

	}
}

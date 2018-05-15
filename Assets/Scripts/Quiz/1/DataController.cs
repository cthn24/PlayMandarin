using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {

	public RoundData[] allRData;

	//private PlayerProgress playerProgress;



	// Use this for initialization
	void Start () {


		DontDestroyOnLoad (gameObject);//when we load new scene, it won't destroy

		//SceneManager.LoadScene("Level1");

	}

	public RoundData GetCurrentRData()
	{
		return allRData [0];
	}
		




}

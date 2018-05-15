using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AButton2 : MonoBehaviour {

	public Text answerT;
	private AnswerQuizL1E2 ansData;//need variable to store it
	private GameController2 gameController;


	// Use this for initialization
	void Start ()
	{
		//find reference
		gameController = FindObjectOfType<GameController2>();
	}

	public void SetAnsButton(AnswerQuizL1E2 data)
	{
		ansData = data;
		answerT.text = ansData.answerT;
	}


	public void ClickHandle()
	{
		gameController.ClickAnswerButton (ansData.isTrue);
		// when we call answer button click, game controller will going to tell the answer is click is correct or not
	}


}

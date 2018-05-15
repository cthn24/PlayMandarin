using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AButton4 : MonoBehaviour {

	public Text answerT;
	private AnswerQuizL2E2 ansData;//need variable to store it
	private GameController4 gameController;


	// Use this for initialization
	void Start ()
	{
		//find reference
		gameController = FindObjectOfType<GameController4>();
	}

	public void SetAnsButton(AnswerQuizL2E2 data)
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

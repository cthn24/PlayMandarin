using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController2 : MonoBehaviour{

    public Text questionT;
	public Text showScoreText; 
	public Text remainingTimeText;
	public SimpleObjectPool2 ansButPool;
	public Transform ansButParent;
	public GameObject showQuestion;
	public GameObject showRoundOver;
    public Text showHighScore2;
    public Text showSameScoreText2;
    private DataController2 dataControl;
	private RoundData2 currRData;
	private QuestionQuizL1E2[] qPool;//this gonna be the question we gonna be working on the round
    private bool roundIsActive;// is the game going or timer round out, or questions finished
	private float remainingTime;
	private int qIndex;
    public int userScore2;
    private int qNumber2 = 1;
    public List<int> qIndexChosen2 = new List<int>();
    private List<GameObject> ansButGameObjects = new List<GameObject>();//gonna check this list


	void Start()
	{

		dataControl = FindObjectOfType<DataController2> ();//high degree of confidence
		currRData = dataControl.GetCurrentRData();
		qPool = currRData.questions;//store questions gonna be asked
		remainingTime = currRData.TimerSeconds;
		UpdateRemainingTime ();

		userScore2 = 0;
		qIndex = 0;

		DisplayQuestions ();
		roundIsActive = true;

        showHighScore2.text = PlayerPrefs.GetInt("highScore2", 0).ToString();
	}
	//first thing want to do is load the first question
	//but before load question need to clear any existing answer button
	private void DisplayQuestions()
	{
		RemoveAnsButton ();
        questionChosen2();
		QuestionQuizL1E2 qData = qPool [qIndex];//get from question pool and stores it to question data
		questionT.text = qData.questionT;
		//going to reach into our question, from question get string, and display that using text
		//loop over all of the answers and display those and added buttons as needed

		for (int i = 0; i < qData.answer.Length; i++) 
		{
			GameObject ansButGameObject = ansButPool.GetObject ();
			ansButGameObjects.Add (ansButGameObject);
			ansButGameObject.transform.SetParent (ansButParent);
            AButton2 ansButton = ansButGameObject.GetComponent<AButton2> ();
			ansButton.SetAnsButton (qData.answer [i]);
		}
	}

	private void RemoveAnsButton()
	{
		while (ansButGameObjects.Count > 0) 
		{
			ansButPool.ReturnObject (ansButGameObjects [0]);
			//whatever object element return zero, it gonna be object pool, meaning it gonna be deactivated, recycle and reuse 
			ansButGameObjects.RemoveAt (0);
			//send it back to the object pool to be going to be reused and removed it from the list of active answer button game object
         }
	}

    void questionChosen2()
    {
        bool qChosen = false;

        while (qChosen != true)
        {
            int random = Random.Range(0, qPool.Length - 1);



            if (!qIndexChosen2.Contains(random))
            {
                qIndexChosen2.Add(random);
                qIndex = random;
                qChosen = true;
            }
        }
    }

	public void ClickAnswerButton(bool isTrue)//call by answer button themselves
	{
		if (isTrue) 
		{
			userScore2 += currRData.marksForTrueAnswer;
			showScoreText.text = "Score: " + userScore2.ToString ();
            showSameScoreText2.text = "Score: " + userScore2.ToString() + "/20";
			//convert player score from integer to string and append it to score

            if (userScore2 > PlayerPrefs.GetInt("highScore2", 0))
            {
                PlayerPrefs.SetInt("highScore2", userScore2);
                showHighScore2.text = userScore2.ToString();
                showSameScoreText2.text = "Score: " + userScore2.ToString() + "/20";
            }
		}


        if (qNumber2 < qPool.Length - 1)
        {
            qNumber2++;
            DisplayQuestions();
        }
		else 
		{
			EndRound ();
		}
	}


	public void EndRound()
	{
		roundIsActive = false;
		showQuestion.SetActive (false);
		showRoundOver.SetActive (true);
	}

	private void UpdateRemainingTime()
	{
		remainingTimeText.text = "Time: " + Mathf.Round (remainingTime).ToString ();
	}

	void Update()
	{
		if (roundIsActive)
		{
			remainingTime -= Time.deltaTime;
			UpdateRemainingTime ();

			if (remainingTime <= 0f) 
			{
				EndRound ();
			}
		}
	}
}
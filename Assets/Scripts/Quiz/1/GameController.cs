using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour{

	public Text questionT;
	public Text showScoreText; 
	public Text remainingTimeText;
	public SimpleObjectPool ansButPool;
	public Transform ansButParent;
	public GameObject showQuestion;
	public GameObject showRoundOver;
	public Text showHighScore;
    public Text showSameScoreText;
	private DataController dataControl;
	private RoundData currRData;
	private QuestionQuizL1E1[] qPool;//this gonna be the question we gonna be working on the round
	private bool roundIsActive;// is the game going or timer round out, or questions finished
	private float remainingTime;
	private int qIndex;
	public int userScore;
    private int qNumber=1;
    public List<int> qIndexChosen = new List<int>();
	private List<GameObject> ansButGameObjects = new List<GameObject>();//gonna check this list


	void Start()
	{
		
		dataControl = FindObjectOfType<DataController> ();//high degree of confidence
		currRData = dataControl.GetCurrentRData();
		qPool = currRData.questions;//store questions gonna be asked
		remainingTime = currRData.TimerSeconds;
		UpdateRemainingTime ();

		userScore = 0;
		qIndex = 0;

        DisplayQuestions ();
		roundIsActive = true;

        showHighScore.text = PlayerPrefs.GetInt("highScore",0).ToString();

	}
	//first thing want to do is load the first question
	//but before load question need to clear any existing answer button

	private void DisplayQuestions()
	{
		RemoveAnsButton ();
        questionChosen();
        QuestionQuizL1E1 qData = qPool[qIndex];
        questionT.text = qData.questionT;


            //going to reach into our question, from question get string, and display that using text
            //loop over all of the answers and display those and added buttons as needed

            for (int i = 0; i < qData.answer.Length; i++)
            {
                GameObject ansButGameObject = ansButPool.GetObject();
                ansButGameObjects.Add(ansButGameObject);
                //  ansButGameObjects.RemoveAt(qIndex);

                ansButGameObject.transform.SetParent(ansButParent);


                AButton ansButton = ansButGameObject.GetComponent<AButton>();
                ansButton.SetAnsButton(qData.answer[i]);

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
    
    
    void questionChosen()
    {
        bool qChosen = false;

        while (qChosen != true)
        {
            int random = Random.Range(0, qPool.Length-1);

        

            if (!qIndexChosen.Contains(random))
            {
                qIndexChosen.Add(random);
                qIndex = random;
                qChosen = true;
            }
        }
    }

	public void ClickAnswerButton(bool isTrue)//call by answer button themselves
	{
		if (isTrue) 
		{
			userScore += currRData.marksForTrueAnswer;

            showScoreText.text = "Score: " + userScore.ToString ();
            showSameScoreText.text = "Score: " + userScore.ToString() + "/20";


            if (userScore > PlayerPrefs.GetInt("highScore",0))
            {
                PlayerPrefs.SetInt("highScore", userScore);
                showHighScore.text = userScore.ToString();
            }
        }

        else
        {
            QuestionQuizL1E1 questionData = qPool[qIndex];
            for(int i=0;i<questionData.answer.Length;i++)
            {
                AnswerQuizL1E1 ansData = questionData.answer[i];
                if(ansData.isTrue)
                {
                    
                    Debug.Log(ansData.answerT);
                //    ColorBlock colours = GetComponent<AButton>()
                  //  colours.normalColor = Color.red;
                    //GetComponent<Button>().colors = colours;
                
                   
                }
            }
        }


        if(qNumber < qPool.Length-1)
        {
            qNumber++;
		    DisplayQuestions ();
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


	public void ReturnLevel1Menu()
	{
		SceneManager.LoadScene ("Level1");
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

    public void ResetLevel1()
    {
        PlayerPrefs.DeleteKey("highScore");
        showHighScore.text = "0";
    }
}
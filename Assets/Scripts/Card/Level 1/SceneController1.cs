
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController1 : MonoBehaviour {
 
    public const int gridRows =4;
    public const int gridCols = 5;
    public const float offsetX = 1.1f;
    public const float offsetY = 1.4f;

    public AudioSource audioSource;
    public AudioSource applause2;
    public AudioClip correctAns;

    public AudioClip applause;

    [SerializeField] private MainCard1 originalCard;
    [SerializeField] private Sprite[] images;
    [SerializeField]

    private int _score = 0;
   
    private void Start()
    {
        Vector3 startPos = originalCard.transform.position;

        //add cards element into this array
        int[] words_1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
       
        words_1 = ShuffleArray(words_1); 

        for(int i = 0; i < gridCols; i++)
        {
            for(int j = 0; j< gridRows; j++)
            {
                MainCard1 card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MainCard1;
                }
                //if i is 0, j is 0,gridCols is 0,the index is 0 as well
                int index = j * gridCols + i;
                //assign words_1 elements array position as id of card
                int id = words_1[index];

                //if id is 1, the images is 1 as well, for example the Card_Animal_1 element in UNITY is 1, then the id in Script is 1 also
                card.ChangeSprite(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }

        highScore.text = "Highest Score: " + PlayerPrefs.GetInt("memory1", 0).ToString();
        audioSource.clip = correctAns;

        applause2.clip = applause;
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for(int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    private MainCard1 _firstRevealed;
    private MainCard1 _secondRevealed;

    private int _match = 0;
    
    private int _movement = 0;
    [SerializeField]
    private TextMesh numberOfMovement;

    [SerializeField]
    private TextMesh scoreT;


    [SerializeField]
    private TextMesh highScore;


    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public void CardRevealed(MainCard1 card)
    {
        if(_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }

        
    }

    private IEnumerator CheckMatch()
    {
        if((_firstRevealed.id ==1 && _secondRevealed.id ==2) ||
           (_firstRevealed.id == 3 && _secondRevealed.id == 4) ||  
           (_firstRevealed.id == 5 && _secondRevealed.id == 6) ||  
           (_firstRevealed.id == 7 && _secondRevealed.id == 8) ||  
           (_firstRevealed.id == 9 && _secondRevealed.id == 10)  ||  
           (_firstRevealed.id == 11 && _secondRevealed.id == 12) ||  
           (_firstRevealed.id == 13 && _secondRevealed.id == 14) ||
           (_firstRevealed.id == 15 && _secondRevealed.id == 16) ||
           (_firstRevealed.id == 17 && _secondRevealed.id == 18) ||
           (_firstRevealed.id == 19 && _secondRevealed.id == 20))
        {
            yield return new WaitForSeconds(1.0f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }
       
        //For example Card_Animal_1 and Card_Animal_2 is identical, their id is 0 and 1 respectively
        else if ((_secondRevealed.id - _firstRevealed.id) == 1)   
        {
            _match++;
            audioSource.Play();
        }
        
        else
        {
            yield return new WaitForSeconds(1.0f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;

        _movement++;
        numberOfMovement.text = "Step Used: " + _movement;
        PlayerPrefs.SetInt("step1", _movement);


        if(_match==10)
        {
            finalScore();
            applause2.Play();
        }

    }

    public void finalScore()
    {
       
            Debug.Log("Complete");

            if (_movement < 25)
            {
                _score = 10;
               
            }

            else if (_movement < 30)
            {
                _score = 9;
              
            }

            else if (_movement < 35)
            {
                _score = 8;
               
            }

            else if (_movement < 40)
            {
                _score = 7;
               
            }

            else if (_movement < 45)
            {
                _score = 6;
              
            }

            else
            {
                _score = 4;
               
            }

          scoreT.text = "Score: " + _score.ToString();


        if (_score > PlayerPrefs.GetInt("memory1", 0))
        {
            PlayerPrefs.SetInt("memory1", _score);
            highScore.text = "Highest Score: " + _score.ToString();
        } 
    }

}

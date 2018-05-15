
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public const int gridRows = 4;
    public const int gridCols = 5;
    public const float offsetX = 1.1f;
    public const float offsetY = 1.4f;

    public AudioSource audioSource;
    public AudioClip correctAns;
    public AudioSource applause2;
    public AudioClip applause;

    [SerializeField]
    private MainCard originalCard;
    [SerializeField]
    private Sprite[] images;
    [SerializeField]


    private int _score3 = 0;

    private void Start()
    {
        Vector3 startPos = originalCard.transform.position;

        //add cards element into this array
        int[] words_1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };

        words_1 = ShuffleArray(words_1);

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MainCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MainCard;
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

        highScore3.text = "Highest Score: " + PlayerPrefs.GetInt("memory3", 0).ToString();
        audioSource.clip = correctAns;
        applause2.clip = applause;
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    private MainCard _firstRevealed;
    private MainCard _secondRevealed;




    private int _match3 = 0;

    private int _movement3 = 0;
    [SerializeField]
    private TextMesh numberOfMovement3;

    [SerializeField]
    private TextMesh scoreT3;


    [SerializeField]
    private TextMesh highScore3;


    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public void CardRevealed(MainCard card)
    {
        if (_firstRevealed == null)
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
        if ((_firstRevealed.id == 1 && _secondRevealed.id == 2) ||
           (_firstRevealed.id == 3 && _secondRevealed.id == 4) ||
           (_firstRevealed.id == 5 && _secondRevealed.id == 6) ||
           (_firstRevealed.id == 7 && _secondRevealed.id == 8) ||
           (_firstRevealed.id == 9 && _secondRevealed.id == 10) ||
           (_firstRevealed.id == 11 && _secondRevealed.id == 12) ||
           (_firstRevealed.id == 13 && _secondRevealed.id == 14) ||
           (_firstRevealed.id == 15 && _secondRevealed.id == 16) ||
           (_firstRevealed.id == 17 && _secondRevealed.id == 18) ||
           (_firstRevealed.id == 19 && _secondRevealed.id == 20))
        {
            yield return new WaitForSeconds(0.5f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        //For example Card_Animal_1 and Card_Animal_2 is identical, their id is 0 and 1 respectively
        else if ((_secondRevealed.id - _firstRevealed.id) == 1)
        {
            _match3++;
            audioSource.Play();
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;

        _movement3++;
        numberOfMovement3.text = "Step Used: " + _movement3;
        PlayerPrefs.SetInt("step3", _movement3);


        if (_match3 == 10)
        {
            finalScore();
            applause2.Play();
        }

    }

    public void finalScore()
    {

        Debug.Log("Complete");

        if (_movement3 < 24)
        {
            _score3 = 10;

        }

        else if (_movement3 < 28)
        {
            _score3 = 9;

        }

        else if (_movement3 < 33)
        {
            _score3 = 8;

        }

        else if (_movement3 < 36)
        {
            _score3 = 7;

        }

        else if (_movement3 < 41)
        {
            _score3 = 6;

        }

        else
        {
            _score3 = 4;

        }
        scoreT3.text = "Score: " + _score3.ToString();

        if (_score3 > PlayerPrefs.GetInt("memory3", 0))
        {
            PlayerPrefs.SetInt("memory3", _score3);
            highScore3.text = "Highest Score: " + _score3.ToString();
        }

    }

}

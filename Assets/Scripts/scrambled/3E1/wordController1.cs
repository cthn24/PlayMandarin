using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


[System.Serializable]
public class Word1
{
    public string pinyin;
    public string word;
    public string desiredRandom;//optional properties

    public float limitedTime;

    public string GetString()
    {
        if(!string.IsNullOrEmpty(desiredRandom))
        {
            return desiredRandom;
        }

        string result = word;
        while(result == word)
        {
            result = "";         
            List<char> characters = new List<char>(word.ToCharArray());
          

            while (characters.Count > 0 )
            { 
                int indexChar = Random.Range(0, characters.Count - 1);
                result += characters[indexChar];

                

                characters.RemoveAt(indexChar);
                
                //if already used that character then removed that so that it wont replicated
            }
        }
        return result;
       
    }

}

public class wordController1: MonoBehaviour {

    //public AudioSource audioSource;
    //public AudioClip correctAns;

    [SerializeField]
    public Text timer;
    
    [SerializeField]
    public Text scoreText;

    [SerializeField]
    public Text highScore3e1;

    public int level3E1Score = 0;

    public Word[] words;

  
    public CharObject1 prefab;
    public Transform container;
    public float space;
    public float lerpSpeed = 3;

    List<CharObject1> charObjects = new List<CharObject1>();
    CharObject1 firstSelected;

    public int currentWord;

    public static wordController1 main;

    public GameObject checkAnswer;

    void Awake()
    {
        main = this;
    }

	// Use this for initialization
	void Start () {
        ShowScramble(currentWord);

        highScore3e1.text = "Highest Score: " + PlayerPrefs.GetInt("Drag1", 0).ToString();
       // audioSource.clip = correctAns;
       
 	}
	
	// Update is called once per frame
	void Update () {
        RearrangeWord();

        scoreText.text = "Score: " + level3E1Score.ToString();

	}

    void RearrangeWord()
    {
        if(charObjects.Count==0)
        {
            return;
        }

        float center = (charObjects.Count - 1) / 2;
        for (int i=0 ; i<charObjects.Count ; i++)
        {
            charObjects[i].rectTransform.anchoredPosition
                = Vector2.Lerp(charObjects[i].rectTransform.anchoredPosition,
                new Vector2((i - center) * space, 0),lerpSpeed*Time.deltaTime);
            charObjects[i].charIndex = i;
        }
    }


    // show a random word to the screen
    public void ShowScramble()
    {
        ShowScramble(Random.Range(0, words.Length - 1));
    }

    // show word from collection with desired index
    public void ShowScramble(int index)
    {
        charObjects.Clear();
        foreach(Transform child in container)
        {
            Destroy(child.gameObject);
        }

        if(index>words.Length -1)
        {
            gameDone();
            return;
        }

        char[] chars = words[index].GetString().ToCharArray();
        foreach(char c in chars)
        {
            CharObject1 clone = Instantiate(prefab.gameObject).GetComponent<CharObject1>();
            clone.transform.SetParent(container);

            charObjects.Add(clone.Init(c));
        }

        currentWord = index;
        StartCoroutine(TimeLeft());
    }

    public void SwapCharObject(int indexA, int indexB)
    {
        CharObject1 tmpA = charObjects[indexA];

        charObjects[indexA] = charObjects[indexB];

        charObjects[indexB] = tmpA;

        charObjects[indexA].transform.SetAsLastSibling();
        //top one, if setAsFirstSibling means bottom one
        charObjects[indexB].transform.SetAsLastSibling();

        CheckWord();
    }

    public void Select(CharObject1 charObject)
    {
        if(firstSelected)
        {
            SwapCharObject(firstSelected.charIndex, charObject.charIndex);

            firstSelected.Select();
            charObject.Select();
        }

        else
        {
            firstSelected = charObject;
        }
    }

    public void UnSelect()
    {
        firstSelected = null;
    }

    public void CheckWord()
    {
        StartCoroutine(CoCheckedWord());
    }

    IEnumerator CoCheckedWord()
    {
        //yield return new WaitForSeconds(1f);

        string word = "";
        foreach (CharObject1 charObject in charObjects)
        {
            word += charObject.charButton;
        }

        if(timeLimit<=0)
        {
            currentWord++;
            ShowScramble(currentWord);
            yield break;
        }

        if (word == words[currentWord].word)
        {
            level3E1Score++;
            scoreText.text = "Score: " + level3E1Score.ToString() ;
            

            if (level3E1Score > PlayerPrefs.GetInt("Drag1", 0))
            {
                PlayerPrefs.SetInt("Drag1", level3E1Score);
                highScore3e1.text = "Highest Score: " + level3E1Score.ToString();
            }

            yield return new WaitForSeconds(4f);
            currentWord++;
            
            Debug.Log("Testing");
            
            ShowScramble(currentWord);
        }


    }
    float timeLimit;
    IEnumerator TimeLeft()
    {
        //audioSource.Play();
        timeLimit = words[currentWord].limitedTime;

        timer.text = Mathf.RoundToInt(timeLimit).ToString();

        int myWord = currentWord;
        yield return new WaitForSeconds(1);



        while(timeLimit>0)
        {
            if(myWord!=currentWord)
            {
                yield break;
            }

            timeLimit -= Time.deltaTime;
            timer.text = Mathf.RoundToInt(timeLimit).ToString();
            yield return null;
        }

        CheckWord();
    }


    public void gameDone()
    {
        checkAnswer.SetActive(true);
    }
}

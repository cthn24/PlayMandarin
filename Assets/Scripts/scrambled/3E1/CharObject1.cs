using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharObject1: MonoBehaviour {

    public char charButton;
    public Text charText;
    public Image image;
    public RectTransform rectTransform;
    public int charIndex;


    public char charPinyin;
    public Text pinyinText;



    public Color normalColour;
    public Color pressedColour;


    bool isSelected = false;

    public CharObject1 Init (char c)
    {
        charButton = c;
        charText.text = c.ToString();
        gameObject.SetActive(true);
        return this;
    }


    public CharObject1 Init1(char p)
    {
        charPinyin = p;
        pinyinText.text = p.ToString();
        gameObject.SetActive(true);
        return this;

    }


    public void Select()
    {
        isSelected = !isSelected;

        image.color = isSelected ? pressedColour : normalColour;
        if(isSelected)
        {
            wordController1.main.Select(this);
        }
        
        else
        {
            wordController1.main.UnSelect();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharObject: MonoBehaviour {

    public char charButton;
    public Text charText;
    public Image image;
    public RectTransform rectTransform;
    public int charIndex;


    
    public Color normalColour;
    public Color pressedColour;


    bool isSelected = false;

    public CharObject Init (char c)
    {
        charButton = c;
        charText.text = c.ToString();
        gameObject.SetActive(true);
        return this;
    }

    public void Select()
    {
        isSelected = !isSelected;

        image.color = isSelected ? pressedColour : normalColour;
        if(isSelected)
        {
            wordController.main.Select(this);
        }
        
        else
        {
            wordController.main.UnSelect();
        }
    }
}

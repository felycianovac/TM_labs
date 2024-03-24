using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using System;

public class DialogueChoice : MonoBehaviour
{
    [SerializeField] private GameObject[] _choices;
    private TextMeshProUGUI[] _choicesText;

    public void Init(){ 
        _choicesText = new TextMeshProUGUI[_choices.Length];
        ushort i = 0;
        foreach (GameObject choice in _choices)
        {
            _choicesText[i++] = choice.GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public bool DisplayChoices(Story story){
        Choice[] currentChoices = story.currentChoices.ToArray();
        if(currentChoices.Length>_choices.Length){
            throw new ArgumentException("The number of choices is greater than the number of choices available");
        }

        HideChoices();
        ushort i = 0;
        foreach(Choice choice in currentChoices){
            _choices[i].SetActive(true);
            _choicesText[i++].text = choice.text;
        }

        return currentChoices.Length>0;
   
    }


    public void HideChoices(){
        foreach(var button in _choices){
            button.SetActive(false);
        }
        Array.ForEach(_choices, (button) => {button.SetActive(false);});

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset _inkJson;
    [SerializeField] private DialogueController _dialogueController;
    public void ChangeField(int value){
        Story story = new Story(_inkJson.text);
        story.variablesState["field"] = value;
        Debug.Log(story.variablesState["field"]);
        var CurrentStory = _dialogueController.CurrentStory;
        CurrentStory.variablesState["field"] = value;
        Debug.Log(CurrentStory.variablesState["field"]);
    }

}

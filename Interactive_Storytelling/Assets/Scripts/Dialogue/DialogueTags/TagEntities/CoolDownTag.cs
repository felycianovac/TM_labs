using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CoolDownTag : MonoBehaviour, ITag
{
 
    public void Calling(string value){
        float number = (float)Convert.ToDouble(value.Replace('.', ','));
        var dialogueWindow = GetComponent<DialogueWindow>();
        try{
            dialogueWindow.SetCooldown(number);
        }
        catch(ArgumentException e){
            Debug.LogError(e.Message);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpeakerTag : MonoBehaviour, ITag
{
   public void Calling(string value){
      var dialogueWindow = GetComponent<DialogueWindow>();
      dialogueWindow.SetName(value);
   }
}

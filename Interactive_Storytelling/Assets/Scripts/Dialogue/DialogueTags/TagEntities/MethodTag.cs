using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MethodTag : MonoBehaviour, ITag
{
   public void Calling(string value){
    var dialogueMethods = GetComponent<DialogueMethods>();
    var method = dialogueMethods.GetType().GetMethod(value);
    method.Invoke(dialogueMethods, null);

   }
}

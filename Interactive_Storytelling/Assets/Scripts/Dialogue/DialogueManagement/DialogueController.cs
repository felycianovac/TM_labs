using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

[RequireComponent(typeof(DialogueWindow), typeof(DialogueTag))]
public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON; // Assign your Ink JSON in the inspector.
   private DialogueWindow _dialogueWindow;
   private DialogueTag _dialogueTag;

   public Story CurrentStory{get; private set;}
   private Coroutine _displayLineCoroutine;

   private void Awake()
   {
       _dialogueWindow = GetComponent<DialogueWindow>();
       _dialogueTag = GetComponent<DialogueTag>();

       _dialogueTag.Init();
       _dialogueWindow.Init();
       _dialogueWindow = GetComponent<DialogueWindow>();
        _dialogueTag = GetComponent<DialogueTag>();

        _dialogueTag.Init();
        _dialogueWindow.Init();

        if (inkJSON != null)
        {
            EnterDialogueMode(inkJSON);
        }
   }


    void Update(){
    if(_dialogueWindow.IsStatusAnswer == true || _dialogueWindow.IsPlaying == false
    || _dialogueWindow.CanContinueToNextLine == false){
        return;
    }
    if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
        ContinueStory();
    }
   }
   
    public void EnterDialogueMode(TextAsset inkJSON){
        CurrentStory = new Story(inkJSON.text);
        _dialogueWindow.SetActive(true);
        ContinueStory();
    }


    private IEnumerator ExitDialogueMode(){
       yield return new WaitForSeconds(_dialogueWindow.CoolDownNewLetter);
       _dialogueWindow.SetActive(false);
       _dialogueWindow.ClearText();
    
    }
 

    public void ContinueStory(){

        if(CurrentStory.canContinue == false){
            StartCoroutine(ExitDialogueMode());
            return;
         }
         if(_displayLineCoroutine != null){
            StopCoroutine(_displayLineCoroutine);
         }

         _displayLineCoroutine = StartCoroutine(_dialogueWindow.DisplayLine(CurrentStory));
        try{
            _dialogueTag.HandleTags(CurrentStory.currentTags);
        }
        catch(System.Exception e){
            Debug.LogError(e.Message);
        }
    }
   
     public void MakeChoice(int choiceIndex){
       _dialogueWindow.MakeChoice();
       CurrentStory.ChooseChoiceIndex(choiceIndex);
       ContinueStory();
    
    }
}
       


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

[RequireComponent(typeof(DialogueChoice))]
public class DialogueWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _displayName; // Ensure only one _displayName field exists
    [SerializeField] private TextMeshProUGUI _displayText; // Assuming this is the correct name for text display
    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField, Range(0f, 20f)] private float _cooldownNewLetter;

    private DialogueChoice _dialogueChoice;

    public bool IsStatusAnswer { get; private set; }
    public bool IsPlaying { get; private set; }
    public bool CanContinueToNextLine { get; private set; }

    public float CoolDownNewLetter
    {
        get => _cooldownNewLetter;
        private set
        {
            _cooldownNewLetter = CheckCooldown(value);
        }
    }

    private float CheckCooldown(float value)
    {
        if (value < 0)
        {
            throw new System.Exception("Cooldown can't be less than 0");
        }
        return value;
    }

    public void Init()
    {
        IsStatusAnswer = false;
        CanContinueToNextLine = false;
        _dialogueChoice = GetComponent<DialogueChoice>();
        _dialogueChoice.Init();
    }

    public void SetActive(bool active)
    {
        IsPlaying = active;
        _dialogueWindow.SetActive(active);
    }

    public void SetText(string text)
    {
        _displayText.text = text;
    }

    public void Add(char letter) // Corrected parameter type
    {
        _displayText.text += letter;
    }

    public void ClearText()
    {
        SetText(""); // Added missing semicolon
    }

    public void SetName(string namePerson)
    {
        _displayName.text = namePerson;
    }

    public void SetCooldown(float value)
    {
        CoolDownNewLetter = value;
    }

    public void MakeChoice()
    {
        if (!CanContinueToNextLine)
        {
            return;
        }

        IsStatusAnswer = false;
    }

    public IEnumerator DisplayLine(Story story)
    {
        string line = story.Continue();
        ClearText();
        _dialogueChoice.HideChoices();
        CanContinueToNextLine = false;
        bool isAddingRichText = false;
        yield return new WaitForSeconds(0.001f);

        foreach (char letter in line.ToCharArray())
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetText(line);
                break;
            }

            isAddingRichText = letter == '<' || isAddingRichText;
            if (letter == '>')
            {
                isAddingRichText = false;
            }

            Add(letter);

            if (!isAddingRichText)
            {
                yield return new WaitForSeconds(_cooldownNewLetter); // Corrected typo
            }
        }

        CanContinueToNextLine = true;
        IsStatusAnswer = _dialogueChoice.DisplayChoices(story);
    }
}

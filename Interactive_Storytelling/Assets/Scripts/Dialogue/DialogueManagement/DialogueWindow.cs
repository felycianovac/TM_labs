using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.Analytics;

[RequireComponent(typeof(DialogueChoice))]
public class DialogueWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _displayName; // Ensure only one _displayName field exists
    [SerializeField] private TextMeshProUGUI _displayText; // Assuming this is the correct name for text display
    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField, Range(0f, 20f)] private float _cooldownNewLetter;
    [SerializeField] private TextMeshProUGUI _displayEngineering;
    [SerializeField] private TextMeshProUGUI _displayCombat;
    [SerializeField] private TextMeshProUGUI _displayDiplomacy;
    [SerializeField] private AudioSource _changeSceneMusic;
    [SerializeField] private AudioClip intro;
    [SerializeField] private AudioClip artifactintro;
    [SerializeField] private AudioClip varekIntro;
    [SerializeField] private AudioClip worstending;
    [SerializeField] private AudioClip zarastealing;
    [SerializeField] private Image _changeBackgroundImage; // Reference to the UI Image component for the background
    [SerializeField] private Image _changeBlurImage;
    [SerializeField] private Sprite introduction;
    [SerializeField] private Sprite introductionBlurr;
    [SerializeField] private Sprite artefactIntro;
    [SerializeField] private Sprite artefactIntroBlurr;
    [SerializeField] private Sprite varekintro;
    [SerializeField] private Sprite varekintroBlurr;
    [SerializeField] private Sprite giveArtefact;
    [SerializeField] private Sprite giveArtefactBlurr;
    [SerializeField] private Sprite worstEnding;
    [SerializeField] private Sprite worstEndingBlurr;
    [SerializeField] private Sprite zaraStealing;
    [SerializeField] private Sprite zaraStealingBlurr;
    [SerializeField] private Sprite trackVarek;
    [SerializeField] private Sprite trackVarekBlurr;
    [SerializeField] private Sprite investigateArtefact;
    [SerializeField] private Sprite investigateArtefactBlurr;
    [SerializeField] private Sprite acceptOffer;
    [SerializeField] private Sprite acceptOfferBlurr;
    [SerializeField] private Sprite declineOffer;
    [SerializeField] private Sprite declineOfferBlurr;
    [SerializeField] private Sprite developTool;
    [SerializeField] private Sprite developToolBlurr;
    [SerializeField] private Sprite integrateShip;
    [SerializeField] private Sprite integrateShipBlurr;
    [SerializeField] private Sprite pirates;
    [SerializeField] private Sprite piratesBlurr;
    [SerializeField] private Sprite trickPirates;
    [SerializeField] private Sprite trickPiratesBlurr;
    [SerializeField] private Sprite fightPirates;
    [SerializeField] private Sprite fightPiratesBlurr;
    [SerializeField] private Sprite negotiatePeace;
    [SerializeField] private Sprite negotiatePeaceBlurr;
    [SerializeField] private Sprite combatUpgrade;
    [SerializeField] private Sprite combatUpgradeBlurr;
    [SerializeField] private Sprite recruitPirate;
    [SerializeField] private Sprite recruitPirateBlurr;
    [SerializeField] private Sprite developCounter;
    [SerializeField] private Sprite developCounterBlurr;


    private DialogueChoice _dialogueChoice;
    private DialogueController _dialogueController;

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
        UpdateSkillDisplays(story);
        UpdateBackgroundImage(story);
        UpdateMusic(story);
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

    public void UpdateSkillDisplays(Story story)
{
    // Attempt to retrieve each skill value. If the variable doesn't exist, it will return null.
    object engValue = story.variablesState["eng"];
    object comValue = story.variablesState["com"];
    object dipValue = story.variablesState["dip"];

    // Update the display if the variable exists and is not null.
    if (_displayEngineering != null && engValue != null)
    {
        _displayEngineering.text = engValue.ToString();
    }
    
    if (_displayCombat != null && comValue != null)
    {
        _displayCombat.text = comValue.ToString();
    }
    
    if (_displayDiplomacy != null && dipValue != null)
    {
        _displayDiplomacy.text =  dipValue.ToString();
    }

}


    public void UpdateBackgroundImage(Story story){
        object sceneSettingObj = story.variablesState["sceneSetting"];
        string sceneSetting = sceneSettingObj.ToString();
        Debug.Log($"Current sceneSetting: {sceneSetting}");
        if (sceneSetting != null) {
            switch (sceneSetting) {
                case "default":
                    break;
                case "introduction":
                    _changeBackgroundImage.sprite = introduction;
                    _changeBlurImage.sprite = introductionBlurr;
                    break;
                case "artefactIntro":
                    _changeBackgroundImage.sprite = artefactIntro;
                    _changeBlurImage.sprite = artefactIntroBlurr;
                    break;
                case "varekintro":
                    _changeBackgroundImage.sprite = varekintro;
                    _changeBlurImage.sprite = varekintroBlurr;
                    break;
                case "giveArtefact":
                    _changeBackgroundImage.sprite = giveArtefact;
                    _changeBlurImage.sprite = giveArtefactBlurr;
                    break;
                case "worstEnding":
                    _changeBackgroundImage.sprite = worstEnding;
                    _changeBlurImage.sprite = worstEndingBlurr;
                    break;
                case "zaraStealing":
                    _changeBackgroundImage.sprite = zaraStealing;
                    _changeBlurImage.sprite = zaraStealingBlurr;
                    break;
                case "trackVarek":
                    _changeBackgroundImage.sprite = trackVarek;
                    _changeBlurImage.sprite = trackVarekBlurr;
                    break;
                case "investigateArtefact":
                    _changeBackgroundImage.sprite = investigateArtefact;
                    _changeBlurImage.sprite = investigateArtefactBlurr;
                    break;
                case "acceptOffer":
                    _changeBackgroundImage.sprite = acceptOffer;
                    _changeBlurImage.sprite = acceptOfferBlurr;
                    break;
                case "declineOffer":
                    _changeBackgroundImage.sprite = declineOffer;
                    _changeBlurImage.sprite = declineOfferBlurr;
                    break;
                case "developTool":
                    _changeBackgroundImage.sprite = developTool;
                    _changeBlurImage.sprite = developToolBlurr;
                    break;
                case "integrateShip":
                    _changeBackgroundImage.sprite = integrateShip;
                    _changeBlurImage.sprite = integrateShipBlurr;
                    break;
                case "pirates":
                    _changeBackgroundImage.sprite = pirates;
                    _changeBlurImage.sprite = piratesBlurr;
                    break;
                case "trickPirates":
                    _changeBackgroundImage.sprite = trickPirates;
                    _changeBlurImage.sprite = trickPiratesBlurr;
                    break;
                case "fightPirates":
                    _changeBackgroundImage.sprite = fightPirates;
                    _changeBlurImage.sprite = fightPiratesBlurr;
                    break;
                case "negotiatePeace":
                    _changeBackgroundImage.sprite = negotiatePeace;
                    _changeBlurImage.sprite = negotiatePeaceBlurr;
                    break;
                case "combatUpgrade":
                    _changeBackgroundImage.sprite = combatUpgrade;
                    _changeBlurImage.sprite = combatUpgradeBlurr;
                    break;
                case "recruitPirate":
                    _changeBackgroundImage.sprite = recruitPirate;
                    _changeBlurImage.sprite = recruitPirateBlurr;
                    break;
                case "developCounter":
                    _changeBackgroundImage.sprite = developCounter;
                    _changeBlurImage.sprite = developCounterBlurr;
                    break;
            }
        } else {
            Debug.LogWarning("sceneSetting variable not found or is null in Ink story.");
        }

    }
    public void UpdateMusic(Story story)
    {
        object sceneMusicObj = story.variablesState["music"];
        string sceneMusic = sceneMusicObj.ToString();
        Debug.Log($"Current sceneMusic: {sceneMusic}");
        if (sceneMusic != null)
        {
            switch (sceneMusic)
            {
                case "intro":
                    _changeSceneMusic.clip = intro;
                    _changeSceneMusic.Play();
                    break;
                case "artifactintro":
                    _changeSceneMusic.clip = artifactintro;
                    _changeSceneMusic.Play();
                    break;
                case "varekintro":
                    _changeSceneMusic.clip = varekIntro;
                    _changeSceneMusic.Play();
                    break;
                case "giveartefact":
                    break;
                case "worstending":
                    _changeSceneMusic.clip = worstending;
                    _changeSceneMusic.Play();
                    break;
                case "zaraStealing":
                    _changeSceneMusic.clip = zarastealing;
                    _changeSceneMusic.Play();
                    break;
            }
        }
        else
        {
            Debug.LogWarning("sceneMusic variable not found or is null in Ink story.");
        }
    }
}
                    

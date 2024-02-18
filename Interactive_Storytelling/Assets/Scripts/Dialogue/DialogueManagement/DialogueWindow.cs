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
    [SerializeField] private AudioClip trackvarek;
    [SerializeField] private AudioClip investigateartefact;
    [SerializeField] private AudioClip acceptoffer;
    [SerializeField] private AudioClip declineoffer;
    [SerializeField] private AudioClip developtool;
    [SerializeField] private AudioClip integrateship;
    [SerializeField] private AudioClip pirates_;
    [SerializeField] private AudioClip trickirates;
    [SerializeField] private AudioClip fightpirates;
    [SerializeField] private AudioClip negotiatepeace;
    [SerializeField] private AudioClip combatupgrade;
    [SerializeField] private AudioClip recruitpirate;
    [SerializeField] private AudioClip developcounter;
    [SerializeField] private AudioClip improveship;
    [SerializeField] private AudioClip planvarek;
    [SerializeField] private AudioClip strategicsabotage;
    [SerializeField] private AudioClip directassult;
    [SerializeField] private AudioClip collabgalactic;
    [SerializeField] private AudioClip collabbene;
    [SerializeField] private AudioClip collabpirates;
    [SerializeField] private AudioClip collabboth;
    [SerializeField] private AudioClip goodend;
    [SerializeField] private AudioClip fight1vs1;
    [SerializeField] private AudioClip becomeanti;
    [SerializeField] private AudioClip loseartefact;
    [SerializeField] private AudioClip artefactvszara;
    [SerializeField] private AudioClip neutralending1;
    [SerializeField] private AudioClip neutralending2;
    [SerializeField] private AudioClip neutralending3;
    [SerializeField] private AudioClip useartefact;
    [SerializeField] private AudioClip savezara;
    [SerializeField] private AudioClip badend1;
    [SerializeField] private AudioClip badend2;


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
    [SerializeField] private Sprite improveShip;
    [SerializeField] private Sprite improveShipBlurr;
    [SerializeField] private Sprite planVarek;
    [SerializeField] private Sprite planVarekBlurr;
    [SerializeField] private Sprite strategicSabotage;
    [SerializeField] private Sprite strategicSabotageBlurr;
    [SerializeField] private Sprite directAssult;
    [SerializeField] private Sprite directAssultBlurr;
    [SerializeField] private Sprite collabGalactic;
    [SerializeField] private Sprite collabGalacticBlurr;
    [SerializeField] private Sprite collabBenef;
    [SerializeField] private Sprite collabBenefBlurr;
    [SerializeField] private Sprite collabPirates;
    [SerializeField] private Sprite collabPiratesBlurr;
    [SerializeField] private Sprite collabBoth;
    [SerializeField] private Sprite collabBothBlurr;
    [SerializeField] private Sprite goodEnd;
    [SerializeField] private Sprite goodEndBlurr;
    [SerializeField] private Sprite fight1vs1_;
    [SerializeField] private Sprite fight1vs1Blurr;
    [SerializeField] private Sprite fight_;
    [SerializeField] private Sprite fightBlurr;
    [SerializeField] private Sprite becomeAnti;
    [SerializeField] private Sprite becomeAntiBlurr;
    [SerializeField] private Sprite loseArtefact;
    [SerializeField] private Sprite loseArtefactBlurr;
    [SerializeField] private Sprite artefactVSzara;
    [SerializeField] private Sprite artefactVSzaraBlurr;
    [SerializeField] private Sprite neutralEnding1;
    [SerializeField] private Sprite neutralEnding1Blurr;
    [SerializeField] private Sprite neutralEnding2;
    [SerializeField] private Sprite neutralEnding2Blurr;
    [SerializeField] private Sprite neutralEnding3;
    [SerializeField] private Sprite neutralEnding3Blurr;
    [SerializeField] private Sprite useArtefact;
    [SerializeField] private Sprite useArtefactBlurr;
    [SerializeField] private Sprite saveZara;
    [SerializeField] private Sprite saveZaraBlurr;
    [SerializeField] private Sprite badEnd1;
    [SerializeField] private Sprite badEnd1Blurr;
    [SerializeField] private Sprite badEnd2;
    [SerializeField] private Sprite badEnd2Blurr;

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
                case "improveShip":
                    _changeBackgroundImage.sprite = improveShip;
                    _changeBlurImage.sprite = improveShipBlurr;
                    break;
                case "planVarek":
                    _changeBackgroundImage.sprite = planVarek;
                    _changeBlurImage.sprite = planVarekBlurr;
                    break;
                case "strategicSabotage":
                    _changeBackgroundImage.sprite = strategicSabotage;
                    _changeBlurImage.sprite = strategicSabotageBlurr;
                    break;
                case "directAssult":
                    _changeBackgroundImage.sprite = directAssult;
                    _changeBlurImage.sprite = directAssultBlurr;
                    break;
                case "collabGalactic":
                    _changeBackgroundImage.sprite = collabGalactic;
                    _changeBlurImage.sprite = collabGalacticBlurr;
                    break;
                case "collabBenef":
                    _changeBackgroundImage.sprite = collabBenef;
                    _changeBlurImage.sprite = collabBenefBlurr;
                    break;
                case "collabPirates":
                    _changeBackgroundImage.sprite = collabPirates;
                    _changeBlurImage.sprite = collabPiratesBlurr;
                    break;
                case "collabBoth":
                    _changeBackgroundImage.sprite = collabBoth;
                    _changeBlurImage.sprite = collabBothBlurr;
                    break;
                case "goodEnd":
                    _changeBackgroundImage.sprite = goodEnd;
                    _changeBlurImage.sprite = goodEndBlurr;
                    break;
                case "fight1vs1":
                    _changeBackgroundImage.sprite = fight1vs1_;
                    _changeBlurImage.sprite = fight1vs1Blurr;
                    break;
                case "fight":
                    _changeBackgroundImage.sprite = fight_;
                    _changeBlurImage.sprite = fightBlurr;
                    break;
                case "becomeAnti":
                    _changeBackgroundImage.sprite = becomeAnti;
                    _changeBlurImage.sprite = becomeAntiBlurr;
                    break;
                case "loseArtefact":
                    _changeBackgroundImage.sprite = loseArtefact;
                    _changeBlurImage.sprite = loseArtefactBlurr;
                    break;
                case "artefactVSzara":
                    _changeBackgroundImage.sprite = artefactVSzara;
                    _changeBlurImage.sprite = artefactVSzaraBlurr;
                    break;
                case "neutralEnding1":
                    _changeBackgroundImage.sprite = neutralEnding1;
                    _changeBlurImage.sprite = neutralEnding1Blurr;
                    break;
                case "neutralEnding2":  
                    _changeBackgroundImage.sprite = neutralEnding2;
                    _changeBlurImage.sprite = neutralEnding2Blurr;
                    break;
                case "neutralEnding3":
                    _changeBackgroundImage.sprite = neutralEnding3;
                    _changeBlurImage.sprite = neutralEnding3Blurr;
                    break;
                case "useArtefact":
                    _changeBackgroundImage.sprite = useArtefact;
                    _changeBlurImage.sprite = useArtefactBlurr;
                    break;
                case "saveZara":
                    _changeBackgroundImage.sprite = saveZara;
                    _changeBlurImage.sprite = saveZaraBlurr;
                    break;
                case "badEnd1":
                    _changeBackgroundImage.sprite = badEnd1;
                    _changeBlurImage.sprite = badEnd1Blurr;
                    break;
                case "badEnd2":
                    _changeBackgroundImage.sprite = badEnd2;
                    _changeBlurImage.sprite = badEnd2Blurr;
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
                    _changeSceneMusic.Stop();
                    _changeSceneMusic.clip = artifactintro;
                    _changeSceneMusic.Play();
                    break;
                case "varekintro":
                    _changeSceneMusic.Stop();
                    _changeSceneMusic.clip = varekIntro;
                    _changeSceneMusic.Play();
                    break;
                case "giveartefact":
                    break;
                case "worstending":
                    _changeSceneMusic.Stop();
                    _changeSceneMusic.clip = worstending;
                    _changeSceneMusic.Play();
                    break;
                case "zarastealing":
                    _changeSceneMusic.Stop();
                    _changeSceneMusic.clip = zarastealing;
                    _changeSceneMusic.Play();
                    break;
                case "trackVarek":
                    _changeSceneMusic.clip = trackvarek;
                    _changeSceneMusic.Play();
                    break;
                case "investigateArtefact":
                    _changeSceneMusic.clip = investigateartefact;
                    _changeSceneMusic.Play();
                    break;
                case "acceptOffer":
                    _changeSceneMusic.clip = acceptoffer;
                    _changeSceneMusic.Play();
                    break;
                case "declineOffer":
                    _changeSceneMusic.clip = declineoffer;
                    _changeSceneMusic.Play();
                    break;
                case "developTool":
                    _changeSceneMusic.clip = developtool;
                    _changeSceneMusic.Play();
                    break;
                case "integrateShip":
                    _changeSceneMusic.clip = integrateship;
                    _changeSceneMusic.Play();
                    break;
                case "pirates":
                    _changeSceneMusic.clip = pirates_;
                    _changeSceneMusic.Play();
                    break;
                case "trickPirates":
                    _changeSceneMusic.clip = trickirates;
                    _changeSceneMusic.Play();
                    break;
                case "fightPirates":
                    _changeSceneMusic.clip = fightpirates;
                    _changeSceneMusic.Play();
                    break;
                case "negotiatePeace":
                    _changeSceneMusic.clip = negotiatepeace;
                    _changeSceneMusic.Play();
                    break;
                case "combatUpgrade":
                    _changeSceneMusic.clip = combatupgrade;
                    _changeSceneMusic.Play();
                    break;
                case "recruitPirate":
                    _changeSceneMusic.clip = recruitpirate;
                    _changeSceneMusic.Play();
                    break;
                case "developCounter":
                    _changeSceneMusic.clip = developcounter;
                    _changeSceneMusic.Play();
                    break;
                case "improveShip":
                    _changeSceneMusic.clip = improveship;
                    _changeSceneMusic.Play();
                    break;
                case "planVarek":
                    _changeSceneMusic.clip = planvarek;
                    _changeSceneMusic.Play();
                    break;
                case "strategicSabotage":
                    _changeSceneMusic.clip = strategicsabotage;
                    _changeSceneMusic.Play();
                    break;
                case "directAssult":
                    _changeSceneMusic.clip = directassult;
                    _changeSceneMusic.Play();
                    break;
                case "collabGalactic":
                    _changeSceneMusic.clip = collabgalactic;
                    _changeSceneMusic.Play();
                    break;
                case "collabBenef":
                    _changeSceneMusic.clip = collabbene;
                    _changeSceneMusic.Play();
                    break;
                case "collabPirates":
                    _changeSceneMusic.clip = collabpirates;
                    _changeSceneMusic.Play();
                    break;
                case "collabBoth":
                    _changeSceneMusic.clip = collabboth;
                    _changeSceneMusic.Play();
                    break;
                case "goodEnd":
                    _changeSceneMusic.clip = goodend;
                    _changeSceneMusic.Play();
                    break;
                case "fight1vs1":
                    _changeSceneMusic.clip = fight1vs1;
                    _changeSceneMusic.Play();
                    break;
                case "fight":   
                    break;
                case "becomeAnti":
                    _changeSceneMusic.clip = becomeanti;
                    _changeSceneMusic.Play();
                    break;
                case "loseArtefact":
                    _changeSceneMusic.clip = loseartefact;
                    _changeSceneMusic.Play();
                    break;
                case "artefactVSzara":
                    _changeSceneMusic.clip = artefactvszara;
                    _changeSceneMusic.Play();
                    break;
                case "neutralEnding1":
                    _changeSceneMusic.clip = neutralending1;
                    _changeSceneMusic.Play();
                    break;
                case "neutralEnding2":
                    _changeSceneMusic.clip = neutralending2;
                    _changeSceneMusic.Play();
                    break;
                case "neutralEnding3":
                    _changeSceneMusic.clip = neutralending3;
                    _changeSceneMusic.Play();
                    break;
                case "useArtefact":
                    _changeSceneMusic.clip = useartefact;
                    _changeSceneMusic.Play();
                    break;
                case "saveZara":
                    _changeSceneMusic.clip = savezara;
                    _changeSceneMusic.Play();
                    break;
                case "badEnd1":
                    _changeSceneMusic.clip = badend1;
                    _changeSceneMusic.Play();
                    break;
                case "badEnd2":
                    _changeSceneMusic.clip = badend2;
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
                    

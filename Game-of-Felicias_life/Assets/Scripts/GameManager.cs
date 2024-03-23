using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private static int SCREEN_WIDTH = 86;
    private static int SCREEN_HEIGHT = 48;
    private static Color DEFAULT_DAY_COLOR = new Color(1f, 0.4f, 0.7f); // Pink for flowers
    private static Color DEFAULT_NIGHT_COLOR = Color.yellow; // Yellow for fireflies
    private static Color TOXIC_DAY_COLOR = new Color(0.4f, 0.3f, 0.2f); // Dull brownish-green for decay
    private static Color TOXIC_NIGHT_COLOR = new Color(0.5f, 0f, 0f); // Dark red for danger at night
    private static Color FRIENDLY_DAY_COLOR = new Color(0.6f, 1f, 0.6f); // Brighter light green for vibrant safety
    private static Color FRIENDLY_NIGHT_COLOR = new Color(0.2f, 0.5f, 1f); // Soft blue for peaceful night sky

    public Color dayBgColor = new Color(0.6f, 0.8f, 0.6f); // Pale green for day
    private Color nightBgColor = new Color(0.05f, 0.05f, 0.2f); // Dark blue for night
    public Color toxicColor, defaultColor, friendlyColor;

    public float dayDuration = 20f; // Duration of the day phase in seconds
    public float nightDuration = 10f; // Duration of the night phase in seconds
    private float dayNightTimer = 0f; // Timer for the day/night cycle
    public bool isDayTime = true; // To track if it's currently day or night
    public float speed = 0.05f;
    private float timer = 0.0f;
    public int updateCounter = 0;


    private int nrOfGenerations = int.MaxValue;
    Grid grid; 
    PopulationController populationController;
    Zone toxicZone, friendlyZone;

    void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // set instance
        Camera.main.backgroundColor = dayBgColor;

        toxicColor = isDayTime ? TOXIC_DAY_COLOR : TOXIC_NIGHT_COLOR;
        defaultColor = isDayTime ? DEFAULT_DAY_COLOR : DEFAULT_NIGHT_COLOR;
        friendlyColor = isDayTime ? FRIENDLY_DAY_COLOR : FRIENDLY_NIGHT_COLOR;
        grid = new Grid(SCREEN_WIDTH, SCREEN_HEIGHT, defaultColor);
        populationController = new PopulationController(toxicColor, friendlyColor, defaultColor);
        toxicZone = new Zone(toxicColor, defaultColor, friendlyColor);
        friendlyZone = new Zone(toxicColor, defaultColor, friendlyColor);

        if (GameMode.Mode == GameMode.Modes.Random)
        {
            grid.PopulateRandomly();
        }
    }

    // Update is called once per frame
    void Update()
    {
        nrOfGenerations = (SetNrGenerations.nrOfGenerations != 0) ? SetNrGenerations.nrOfGenerations : nrOfGenerations;
        if (updateCounter >= nrOfGenerations)
        {
            return;
        }
        if (GameMode.Mode == GameMode.Modes.Custom)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                grid.PopulateWithDeadCells();
                GameMode.Mode = GameMode.Modes.Random;
            }
            grid.PopulateCustom();

        }
        else if (GameMode.Mode == GameMode.Modes.Random)
        {
            if (timer >= speed)
            {
                timer = 0.0f;
                grid.CountNeighbors();
                if (ToggleHandler.ExplosionHandler)
                    populationController.ExplosionRules(grid);
                populationController.GeneralRules(grid);
                if (ToggleHandler.ToxicZone)
                {
                    toxicZone.ToxicZone(grid, 10, 5, 25, 20);
                    if (updateCounter % 5 == 0) populationController.KillRandomToxicCells(grid);
                }
                else toxicZone.ResetZone(grid, toxicColor);
                if (ToggleHandler.FriendlyZone)
                    friendlyZone.FriendlyZone(grid, 40, 30, 66, 40);
                else friendlyZone.ResetZone(grid, friendlyColor);
                updateCounter++;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }

        // Increment the day/night cycle timer
        dayNightTimer += Time.deltaTime;

        if (isDayTime && dayNightTimer > dayDuration)
        {
            // Transition to night
            StartCoroutine(TransitionToNight());
            isDayTime = false;
            dayNightTimer = 0f; // Reset timer for the next cycle
        }
        else if (!isDayTime && dayNightTimer > nightDuration)
        {
            // Transition to day
            StartCoroutine(TransitionToDay());
            isDayTime = true;
            dayNightTimer = 0f; // Reset timer for the next cycle
        }
    }

    IEnumerator TransitionToDay()
    {
        float transitionDuration = 5f; // Length of transition in seconds
        for (float t = 0; t < transitionDuration; t += Time.deltaTime)
        {
            // Adjust lighting, background color, etc. for day
            // Example: Gradually change the background color to a day color
            // gradually change the background color to a day color
            Camera.main.backgroundColor = Color.Lerp(nightBgColor, dayBgColor, t / transitionDuration);
            yield return null;
        }
        toxicColor = TOXIC_DAY_COLOR;
        defaultColor = DEFAULT_DAY_COLOR;
        friendlyColor = FRIENDLY_DAY_COLOR;

        updateColors(toxicColor, defaultColor, friendlyColor);
    }

    IEnumerator TransitionToNight()
    {
        float transitionDuration = 5f; // Length of transition in seconds
        for (float t = 0; t < transitionDuration; t += Time.deltaTime)
        {
            // Adjust lighting, background color, etc. for night
            // Example: Gradually change the background color to a night color
            Camera.main.backgroundColor = Color.Lerp(dayBgColor, nightBgColor, t / transitionDuration);
            yield return null;
        }
        toxicColor = TOXIC_NIGHT_COLOR;
        defaultColor =  DEFAULT_NIGHT_COLOR;
        friendlyColor = FRIENDLY_NIGHT_COLOR;

        updateColors(toxicColor, defaultColor, friendlyColor);
    }

    void updateColors(Color toxicColor, Color defaultColor, Color friendlyColor) {
        grid.updateColors(defaultColor);
        friendlyZone.updateColors(toxicColor, defaultColor, friendlyColor);
        toxicZone.updateColors(toxicColor, defaultColor, friendlyColor);
        populationController.updateColors(toxicColor, friendlyColor, defaultColor);
    }
}

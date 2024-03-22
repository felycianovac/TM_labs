using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int SCREEN_WIDTH = 86;
    private static int SCREEN_HEIGHT = 48;

    public float dayDuration = 30f; // Duration of the day phase in seconds
    public float nightDuration = 20f; // Duration of the night phase in seconds
    private float dayNightTimer = 0f; // Timer for the day/night cycle
    private bool isDayTime = true; // To track if it's currently day or night

    private Color dayColor = new Color(0.6f, 0.8f, 0.6f); // Pale green for day
  // Daytime color
    private Color nightColor = new Color(0.05f, 0.05f, 0.2f);

    public float speed = 0.05f;
    private float timer = 0.0f;
    private int updateCounter = 0;
    private int nrOfGenerations = int.MaxValue;
    Grid grid = new Grid(SCREEN_WIDTH, SCREEN_HEIGHT);
    PopulationController populationController = new PopulationController();
    Zone toxicZone = new Zone();
    Zone friendlyZone = new Zone();
    void Start()
    {
        
        Camera.main.backgroundColor = dayColor;
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
                else toxicZone.ResetZone(grid, Color.green);
                if (ToggleHandler.FriendlyZone)
                    friendlyZone.FriendlyZone(grid, 40, 30, 66, 40);
                else friendlyZone.ResetZone(grid, Color.blue);
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
            Camera.main.backgroundColor = Color.Lerp(Color.black, Color.white, t / transitionDuration);
            yield return null;
        }
    }

    IEnumerator TransitionToNight()
    {
        float transitionDuration = 5f; // Length of transition in seconds
        for (float t = 0; t < transitionDuration; t += Time.deltaTime)
        {
            // Adjust lighting, background color, etc. for night
            // Example: Gradually change the background color to a night color
            Camera.main.backgroundColor = Color.Lerp(dayColor, nightColor, t / transitionDuration);
            yield return null;
        }
    }
}

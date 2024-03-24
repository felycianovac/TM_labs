using System;
using UnityEngine;
using UnityEngine.UI;

public class RegionSelector : MonoBehaviour
{
    private bool selectionEnabled = false;
    public RectTransform selectionBox;
    public Button startSelectionButton; // Button to start the selection process
    private Vector2 startPosition;
    private Vector2 endPosition;
    private bool isSelecting = false;
    public GameManager gameManager;
    float worldWidth = 1.52f - (-0.37f);
    float worldHeight = 0.55f - (-0.5f);



    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        // Add click listener to the button
        if (startSelectionButton != null)
        {
            startSelectionButton.onClick.AddListener(EnableSelection);
        }
        else
        {
            Debug.LogError("Start Selection Button not assigned in Inspector.");
        }
    }

    void Update()
    {
        // Only start selecting if selection has been enabled
        if (!isSelecting && selectionEnabled && Input.GetMouseButtonDown(0))
        {
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isSelecting = true; // Now actively selecting
            selectionEnabled = false; // Prevent re-entry
            selectionBox.gameObject.SetActive(true);
        }

        // If we're actively in selection mode, update the selection box
        if (isSelecting && Input.GetMouseButton(0))
        {
            endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UpdateSelectionBox(startPosition, endPosition);
        }

        // Complete the selection process
        if (Input.GetMouseButtonUp(0) && isSelecting)
        {
            endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UpdateSelectionBox(startPosition, endPosition);
            selectionBox.gameObject.SetActive(false);
            isSelecting = false;
            OnSelectionComplete();
        }
    }



    void UpdateSelectionBox(Vector2 start, Vector2 end)
    {
        if (!selectionBox.gameObject.activeInHierarchy)
            selectionBox.gameObject.SetActive(true);

        Vector2 anchorMin = Vector2.Min(start, end);
        Vector2 anchorMax = Vector2.Max(start, end);

        // Convert to screen space if necessary
        anchorMin = Camera.main.WorldToScreenPoint(anchorMin);
        anchorMax = Camera.main.WorldToScreenPoint(anchorMax);

        // Normalize coordinates since UI uses normalized positions
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        selectionBox.anchorMin = anchorMin;
        selectionBox.anchorMax = anchorMax;
    }



    // OnSelectionComplete method remains unchanged
    private void OnSelectionComplete()
    {
        float worldWidth = 1.52f - (-0.37f); // = 1.89
        float worldHeight = 0.55f - (-0.5f); // = 1.05

        float gridWidth = 86f;
        float gridHeight = 48f;

        float scaleX = gridWidth / worldWidth;
        float scaleY = gridHeight / worldHeight;

        Vector2 min = Camera.main.ScreenToWorldPoint(startPosition);
        Vector2 max = Camera.main.ScreenToWorldPoint(endPosition);
        Debug.Log($"Region selected from {min} to {max}");


        int startX = Mathf.FloorToInt((min.x - (-0.37f)) * scaleX);
        int startY = Mathf.FloorToInt((min.y - (-0.5f)) * scaleY);
        int endX = Mathf.CeilToInt((max.x - (-0.37f)) * scaleX);
        int endY = Mathf.CeilToInt((max.y - (-0.5f)) * scaleY);

        // Clamp values to grid size
        startX = Mathf.Clamp(startX, 0, 85); // Grid indices range from 0 to 85 (86 units wide)
        startY = Mathf.Clamp(startY, 0, 47); // Grid indices range from 0 to 47 (48 units tall)
        endX = Mathf.Clamp(endX, 0, 85);
        endY = Mathf.Clamp(endY, 0, 47);

        Debug.Log(min);
        Debug.Log(max);

        Debug.Log(startX);
        Debug.Log(startY);
        Debug.Log(endX);
        Debug.Log(endY);

        Debug.Log(gameManager);
        Debug.Log(gameManager.speed);
        //gameManager.ToxicZoneManager(startX, startY, endX, endY);

    }

    // Call this method when the button is clicked
    public void EnableSelection()
    {
        Debug.Log("Selection enabled.");
        selectionEnabled = true; isSelecting = false;
    }

    //void ApplyToxicBehaviorToRegion(int startX, int startY, int endX, int endY)
    //{
    //    for (int x = startX; x <= endX; x++)
    //    {
    //        for (int y = startY; y <= endY; y++)
    //        {
    //            // Assuming your grid can access cells by grid coordinates.
    //            Cell cell = grid.GetCell(x, y); // You'll need a method in your Grid class that allows fetching cells by coordinates.
    //            if (cell != null)
    //            {
    //                // Apply toxic behavior
    //                cell.isPoisoned = true;
    //                cell.SetColor(Color.green); // Assuming you use SetColor to visually indicate the toxic state.
    //            }
    //        }
    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    // toxicColor from GameManager.cs
    private Color toxicColor, defaultColor, friendlyColor;

    public Zone(Color toxicColor, Color defaultColor, Color friendlyColor)
    {
        this.toxicColor = toxicColor;
        this.defaultColor = defaultColor;
        this.friendlyColor = friendlyColor;
    }

    public void updateColors(Color toxicColor, Color defaultColor, Color friendlyColor)
    {
        this.toxicColor = toxicColor;
        this.defaultColor = defaultColor;
        this.friendlyColor = friendlyColor;
    }

    public void ToxicZone(Grid grid, int x1, int y1, int x2, int y2)
    {
        for (int y = y1; y < y2; y++)
        {
            for (int x = x1; x < x2; x++)
            {
                // if cell is alive, make it poisoned and change color to green
                if (grid.GetCells()[x, y].isAlive)
                {
                    grid.GetCells()[x, y].isPoisoned = true;
                    grid.GetCells()[x, y].SetColor(toxicColor);
                }
            }
        }
    }

    public void FriendlyZone(Grid grid, int x1, int y1, int x2, int y2)
    {
        for (int y = y1; y < y2; y++)
        {
            for (int x = x1; x < x2; x++)
            {
                if (!grid.GetCells()[x, y].isAlive)
                {
                    grid.GetCells()[x, y].isFriendly = true;
                    grid.GetCells()[x, y].SetColor(friendlyColor);
                }
            }
        }
    }

    public void ResetZone(Grid grid, Color color)
    {
        for (int y = 0; y < grid.height; y++)
        {
            for (int x = 0; x < grid.width; x++)
            {
                if (grid.GetCells()[x, y].isAlive)
                {
                    if (color == toxicColor && grid.GetCells()[x, y].isPoisoned == true)
                    {
                        grid.GetCells()[x, y].isPoisoned = false;
                        grid.GetCells()[x, y].SetColor(defaultColor);
                    }
                    else if (color == friendlyColor && grid.GetCells()[x, y].isFriendly == true)
                    {
                        grid.GetCells()[x, y].isFriendly = false;
                        grid.GetCells()[x, y].SetColor(defaultColor);
                    }
                }
            }
        }
    }
}

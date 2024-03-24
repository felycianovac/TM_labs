using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NrGenerationsText : MonoBehaviour
{
    public TMP_Text nrGenerations;
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        int counter = gameManager.updateCounter;
        nrGenerations.text = "Number of Generations: " + counter.ToString();
    }
}
